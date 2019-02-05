using Boots.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;
using System.Configuration;

namespace Boots.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string searchText = "")
        {
            Session["CapturedImage"] = "";

            var model = new ProductDetailsModel
            {
                ProductModel = new ProductModel { ProductName = searchText },
                ProductList = ProductRepository.GetProducts(searchText)
            };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Capture(string imageData)
        {
            string product = string.Empty;
            string imageName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");
            string imagePath = string.Format("~/Captures/{0}.png", imageName);

            using (var fs = new FileStream(Server.MapPath(imagePath), FileMode.Create))
            {
                using (var bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }

            var resultText = ParseJsonToObject(ConfigurationManager.AppSettings["JsonString"]);

            var productTexts = Regex.Split(resultText.TextResult, "1.Detected: ");

            for (int item = 1; item < productTexts.Length - 1; item++)
            {
                var productName = productTexts[item].Split(' ')[0];

                var isProductExists = ProductRepository.GetProducts(productName).Any();

                if (isProductExists)
                {
                    TempData["ProductName"] = productName;
                    product = productName;
                    break;
                }
            }

            var model = new ProductDetailsModel
            {
                ProductModel = new ProductModel { ProductName = product },
                ProductList = ProductRepository.GetProducts(product)
            };

            return View("Index", model);
        }

        [HttpPost]
        public PartialViewResult ProductList(string product)
        {
            var productName = TempData["ProductName"]?.ToString() ?? string.Empty;

            var ProductList = ProductRepository.GetProducts(productName);
            return PartialView(ProductList);
        }

        private JsonResponse ParseJsonToObject(string jsonString)
        {
            var jsonResult = new JavaScriptSerializer().Deserialize<JsonResponse>(jsonString);
            return jsonResult;
        }        
    }
}