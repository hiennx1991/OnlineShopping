using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetActiveContact();

            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name, string mobile, string address, string email, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Phone = mobile;
            feedback.Address = address;
            feedback.Email = email;
            feedback.CreatedDate = DateTime.Now;
            feedback.Content = content;

            var id = new ContactDao().InsertFeedBack(feedback);

            if (id > 0)
            {
                return Json(new
                {
                    status = true
                });
                //send mail
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}