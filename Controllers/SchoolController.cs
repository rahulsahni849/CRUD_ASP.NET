using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using crud_app.Models;

namespace crud_app.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            List<SchoolModel> list = SchoolModel.getData();
            list.Sort((x,y) => x.order_no.CompareTo(y.order_no));

            ViewData["data"] = list;
            SchoolModel model=null;
            if (TempData["edit"] != null)
            {
                model = TempData["edit"] as SchoolModel;
            }
            
            return View(model);
        }

        // GET: School/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        [HttpPost]
        public ActionResult Create(SchoolModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SchoolModel data = new SchoolModel()
                    {
                        class_name = model.class_name,
                        no_of_year = model.no_of_year,
                        order_no = model.order_no,
                        show = model.show,
                        school_name = model.school_name
                    };
                    int status = SchoolModel.postData(data);
                    ViewData["post_status"] = status;
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: School/Edit/5
        public ActionResult Edit(int id)
        {

            SchoolModel model = SchoolModel.getData(id);
            TempData["edit"] = model;
            return RedirectToAction("Index");
        }

        // POST: School/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SchoolModel model)
        {
            try
            {
                SchoolModel t = model;
                if (ModelState.IsValid)
                {
                    int status = SchoolModel.updateData(id,model);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public HttpStatusCodeResult Delete(int id)
        {
            try
            {
                int status = SchoolModel.deleteData(id);
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

    }
}
