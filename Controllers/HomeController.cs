using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using program.Data;
using program.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy; 
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace program.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        private ProgramContext _context;

        public HomeController(ILogger<HomeController> logger, ProgramContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            Product product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            List<Category> categories = _context.Products.Where(p => p.Id == id).SelectMany(c => c.CategoryToProducts).Select(ca => ca.Category).ToList();

            var vm = new DetailsViewModel()
            {
                product = product,
                categories = categories
            };

            return View(vm);
        }
        [Authorize]
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var order = _context.Orders.SingleOrDefault(o => o.UserId == userId && !o.IsFinaly);

                if (order != null)
                {
                    var orderDetail = _context.OrderDetail.FirstOrDefault(d =>
                    d.OrderId == order.OrderId &&
                    d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _context.OrderDetail.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Count = 1,
                            ProductId = product.Id,
                            Price = product.Item.Price
                        });
                        _context.SaveChanges();
                    }
                }
                else
                {
                    order = new Order()
                    {
                        IsFinaly = false,
                        CreateTime = DateTime.Now,
                        UserId = userId
                    };
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    _context.OrderDetail.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = product.Item.Price,
                        Count = 1
                    });
                }
                _context.SaveChanges();
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var order = _context.Orders.Where(o => o.UserId == userId && !o.IsFinaly).
                Include(o => o.OrderDetails).
                ThenInclude(c => c.Product).FirstOrDefault();
            return View(order);
        }
        [Authorize]
        public IActionResult ReduceCart(int detailId)
        {
            var orderDetail = _context.OrderDetail.Find(detailId);
            if (orderDetail.Count == 1)
            {
                return RedirectToAction("RemoveCart", new { detailId });
            }
            if (orderDetail.Count > 1)
            {
                orderDetail.Count -= 1;
            }
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {
            var orderDetail = _context.OrderDetail.Find(detailId);
            var order = _context.Orders.SingleOrDefault(o => o.OrderId == orderDetail.OrderId);
            _context.Remove(orderDetail);
            _context.SaveChanges();
            var orderDetailCount = _context.OrderDetail.Where(o => o.OrderId == order.OrderId).Sum(o => o.Count);
            if (orderDetailCount == 0)
            {
                _context.Orders.Remove(order);
            }
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }
        [Authorize]
        public IActionResult Payment(int orderId)
        {

            _context.Orders.Remove(_context.Orders.Where(o => o.OrderId == orderId).SingleOrDefault());
            _context.SaveChanges();
            return View("_Alert", new AlertViewModel { Title = "پرداخت موفق", Alert = "ممنون از خرید و اعتمادتون", TextColor = "text-success" });
        }

        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
