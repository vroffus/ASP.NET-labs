using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        [Route("File/DownloadFile")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("File/DownloadFile")]
        public async Task<IActionResult> DownloadFile(string firstName, string lastName, string fileName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(fileName))
            {
                ModelState.AddModelError("", "Please fill in all fields.");
                return View("Index");
            }

            string content = $"First Name: {firstName}\nLast Name: {lastName}";

            byte[] byteArray = Encoding.UTF8.GetBytes(content);

            MemoryStream stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", $"{fileName}.txt");
        }
    }

}
