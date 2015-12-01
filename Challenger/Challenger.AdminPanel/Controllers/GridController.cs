using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Challenger.AdminPanel.Models;
using System.Data;
using System.Data.Entity;

namespace Challenger.AdminPanel.Controllers
{
    public class GridController : Controller
    {
       ChallengerModelContainer entities= new ChallengerModelContainer();
	
		 public ActionResult Editing()
		{ 
			
        
            return View();
        }
		public ActionResult Editing_Read([DataSourceRequest] DataSourceRequest request)
				{
	//		entities.UserSet.Add( new User());
	//		entities.SaveChanges();
            return Json(entities.UserSet.ToDataSourceResult(request));
        }

       
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editing_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<User> Users)
        {
            var results = new List<User>();

            if (Users != null && ModelState.IsValid)
            {
                foreach (var user in Users)
                {
										entities.UserSet.Add(user);
				  try {
                entities.SaveChanges();
            } catch (Exception e)
            { }
                    results.Add(user);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editing_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<User> Users)
        {
            if (Users != null && ModelState.IsValid)
            {
                foreach (var user in Users)
                {
										entities.UserSet.Attach(user);
										entities.Entry(user).State = EntityState.Modified;
									  try {
                entities.SaveChanges();
            } catch (Exception e)
            { }
                 //   a.Update(product);
                }
            }

            return Json(Users.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Editing_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<User> Users)
        {            
            if (Users.Any())
            {
                foreach (var user in Users)
                {
											entities.UserSet.Attach(user);
											entities.UserSet.Remove(user);
										  try {
                entities.SaveChanges();
            } catch (Exception e)
            { }
             //       a.Destroy(product);
                }
            }

            return Json(Users.ToDataSourceResult(request,ModelState));
        }
    }
}