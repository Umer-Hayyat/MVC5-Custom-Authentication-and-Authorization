using MVCAuthAndAuthoWithDotNetFramework.CustomAttributes;
using MVCAuthAndAuthoWithDotNetFramework.CustomFilters;
using MVCAuthAndAuthoWithDotNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthAndAuthoWithDotNetFramework.Controllers
{
    [CustomAuthenticationFilter]
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(new UsersModel().GetAllUsers());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(new UsersModel().GetUserByID(id));
        }

        // GET: User/Create
        [CustomAuthorizeAttribute(Roles = "SuperUser")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UsersModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.AddUser();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Invalid Data", "Data not received in proper format");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new UsersModel().GetUserByID(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UsersModel model)
        {
            try
            {
                model.UpdateUser();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new UsersModel().GetUserByID(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UsersModel model)
        {
            try
            {
                model.DeleteUser();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
