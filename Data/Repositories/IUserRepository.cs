using Microsoft.EntityFrameworkCore.Internal;
using program.Models;
using System.Linq;

namespace program.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByName(string name);
        void AddUser(Users user);
        Users GetUserForLogin(string name, string password);
    }
    public class UserRepository : IUserRepository
    {
        private ProgramContext _context;
        public UserRepository(ProgramContext context)
        {
            _context = context;
        }
        public bool IsExistUserByName(string name)
        {
            return _context.Users.Any(u => u.Name == name);
        }
        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
        public Users GetUserForLogin(string name,string password)
        {
            return _context.Users.
                SingleOrDefault(u => u.Name == name && u.Password == password);
        }
    }
}
