using ReactJs.NetWithMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ReactJs.NetWithMVC.Controllers
{
    [RoutePrefix("")]
    [Route("{action}")]
    public class HomeController : Controller
    {

        private List<CommentModel> commentsList = null;

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Route("react")]
        public ActionResult React()
        {
            commentsList = LoadCommentsList();
            return View(commentsList);
        }

        [Route("comments")]
        public ActionResult Comments()
        {
            return Json(LoadCommentsList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("comments/new")]
        public ActionResult AddComment(CommentModel comment)
        {
            commentsList = Session["comments"] as List<CommentModel>;

            // create a fake ID for this comment
            comment.Id = commentsList.Count + 1;
            commentsList.Add(comment);

            return Content("Success.");
        }

        private List<CommentModel> LoadCommentsList()
        {

            if (Session["comments"] == null)
            {
                commentsList = new List<CommentModel>
                    {
                        new CommentModel
                        {
                            Id = 1,
                            Author = "Daniel Lo Nigro",
                            Text = "Hello ReactJS.NET World!"
                        },
                        new CommentModel
                        {
                            Id = 2,
                            Author = "Pete Hunt",
                            Text = "This is one comment"
                        },
                        new CommentModel
                        {
                            Id = 3,
                            Author = "Jordan Walke",
                            Text = "This is *another* comment"
                        },
                    };

                Session["comments"] = commentsList;
            }
            else
            {
                commentsList = Session["comments"] as List<CommentModel>;
            }

            return commentsList;
        }

    }
}