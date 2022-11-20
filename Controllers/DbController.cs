using full_curd_operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace full_curd_operation.Controllers
{
    public class DbController : Controller
    {
        curdEntities obj = new curdEntities();
        // GET: Db
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult insert(curd e)
        {
            obj.curds.Add(e);
            obj.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Show()
        {
            List <curd> list = obj.curds.ToList();
            return View("list", list);
        }
        public ActionResult update(int id)
        {
            curd ob = obj.curds.Find(id);
            return View(ob);
        }
        
        public ActionResult updatedata(curd newdata)
        {

            curd olddata = obj.curds.Find(newdata.Id);
            olddata.name = newdata.name;
            olddata.address = newdata.address;
            olddata.hobbies = newdata.hobbies;
            olddata.language = newdata.language;
            obj.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult delete(int id)
        {
            curd d = obj.curds.Find(id);
            obj.curds.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}