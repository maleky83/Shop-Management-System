using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class beforerefreshf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "ram 6 , memory 128", "Mobile Sumsung" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "ram 16 , memory 1T", "lap top lenovo" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "PictureName" },
                values: new object[] { " AMOLED،GPS ", "Watch sport X-200", "3.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "پیراهن شیک با جنس ترکیبی پنبه و پلی‌استر، مناسب مهمانی‌ها و مجالس رسمی. دارای ۴ سایز و ۳ رنگ مختلف.", "پیراهن آستین‌بلند مجلسی طرح‌دار" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "مانتو سبک و خنک با طرح گل‌های ظریف، جنس نخی درجه یک و رنگ‌بندی شاد. دارای دو جیب کاربردی و قد بلند.", "مانتو نخی بهاره طرح گل‌های کوچک" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "PictureName" },
                values: new object[] { "ساعت هوشمند با صفحه نمایش AMOLED، حسگرهای پیشرفته سلامت، GPS داخلی و مقاومت در برابر آب تا عمق ۵۰ متر.", "ساعت هوشمند اسپرت پرو مدل X-200", "1.jpg" });
        }
    }
}
