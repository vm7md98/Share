using Microsoft.AspNetCore.Mvc;
using Share.Models; //Need this to link it with Models

namespace Share.Controllers
{
    public class SharedToolController : Controller //No need to write "ShareToolController" to define it as Controller in .NET Core.
    {
        //https://localhost:7244/sharedtool/index
        public ContentResult Index() //"ContentResult" is same as "String". //"ContentResult" for Text, "EmptyResult" for Null, "ViewResult" for html.
        {
            return Content("مرحبا، هذه نتيجة الدالة المرجعة من الموجه"); //But you need to use "Content" before writing your text.
        }

        //https://localhost:7244/sharedtool/index2
        public ActionResult Index2() //Add Razor View as List and Untick everything. //"ActionResult" will link this "Index2" route to "Index2" page in "Views" under "SharedTool".
        { 
            List<SharedTool> sharedToolList = new List<SharedTool>();
            sharedToolList.Add(new SharedTool("Sugar", "White sugar", 1));
            sharedToolList.Add(new SharedTool("Wheat", "Brown wheat", 0));
            sharedToolList.Add(new SharedTool("Water", "Fiji water ofc", 3));
            sharedToolList.Add(new SharedTool("Oil", "Whatever oil", 4));
            return View(sharedToolList); //This will not work untill you link "Creating an Object" Views with Models with Controllers.
        }

        public String Mohammed() //Weak, use "ContentResult" Instead!
        {
            return "Mohammed";
        }

        public ContentResult PrintName(String name, int age) //Return the name by using "Query string" in the URL.
        {
            return Content("Name: " + name + ", Age: " + age); //https://localhost:7244/sharetool/PrintName?name=Mohammed&&Age=23 //Use "&&" to add another variable to Query.
        }

        [ActionName("Details")] //Create a shortcut for "GetDetails" route. //"ActionName" for shortcutting routes.
        public ContentResult GetDetails() //Long route to write.
        {
            return Content("تفاصيل الاداة المتوفرة للمشاركة");
        }

        [ActionName("Bineid"), NonAction, HttpGet] //You can use more than one Action selector once. 
        //"ActionVerbs" = [HttpGet] (This will be always used by Defualt), [HttpPost], [HttpPut], [HttpDelete], ....etc.
        public String Bineid() //If it was "private" then the page will not load. If you use "[NonAction]" the page will no load but it will still "public".
        {
            return "Bineid";
        }

        public ActionResult RequestTool() 
        {
            return Content("تم طلب الاداة");
        }

        public ActionResult Create()
        {
            return View();
        }

        //To bind Controller with a specific model
        [HttpPost]
        public ActionResult Create(SharedTool shared) 
        {
            if (ModelState.IsValid)
            {
                String toolName = shared.Name;
                String toolDescription = shared.Description;
                int quantity = shared.Quantity.HasValue ? shared.Quantity.Value : 0; //Use "(int)shared.Quantity;" or "shared.Quantity.HasValue ? shared.Quantity.Value : 0;" becuase int quantity may be null. This will fix the [Required] Message Error.
                return RedirectToAction("Index2");
            }
            else 
            {
                return View(shared);
            }
        }

        //To bind Controller with a Forms "Include" ("Exclude" is removed in .NET Core)
        [HttpPost]
        public ActionResult Create2([Bind (include:"Name, Description")] FormCollection values)
        {
            String toolName = values["Name"];
            String toolDescription = values["Description"];
            int quantity;
            int.TryParse(values["Quantity"], out quantity);
            return RedirectToAction("Index2");
        }

    }
}
