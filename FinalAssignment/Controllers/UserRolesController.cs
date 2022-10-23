using FinalAssignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalAssignment.Controllers
{ 
    public class UserRolesController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private UserManager<ApplicationUser> userManager; 

        public UserRolesController()
        {
            var userStore = new UserStore<ApplicationUser>(context);
            userManager = new UserManager<ApplicationUser>(userStore);
        }
        // GET: UserRoles
        public ActionResult Index()
        {
            var roles = this.context.Roles.ToList();
            return View(roles);
        }

        //GET: UserRoles/CreateRole
        public ActionResult CreateRole()
        {
            return View();
        }

        //POST: UserRoles/CreateRole
        [HttpPost]
        public ActionResult CreateRole(FormCollection formCollection)
        {
            try{
                var newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = formCollection["RoleName"],
                };
                context.Roles.Add(newRole);
                context.SaveChanges();
                return RedirectToAction("Index");
             }
            catch{
                return View();
            }
        }

        public ActionResult DeleteRole(string roleName)
        {
            var role = context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            context.Roles.Remove(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditRole(String roleName)
        {
            var role = context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult EditRole(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            } catch { return View(role); }
        }
        
        //GET: UserRoles/AddRoleToUser
        public ActionResult AddRoleToUser()
        {
            var rolesList = context.Roles.ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name}).ToList();
            var usersList = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email}).ToList();
            ViewBag.Roles = rolesList;
            ViewBag.Users = usersList;
            return View();
        }

        //Post: UserRoles/AddRoleToUser
        [HttpPost]
        public ActionResult AddRoleToUser(string Email, string Role)
        {
            try{
                var user = userManager.FindByEmail(Email);
                userManager.AddToRole(user.Id, Role);
                ViewBag.Users = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
                ViewBag.Roles = context.Roles.ToList().Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();               
            } catch (Exception e){
                ViewBag.ErrorMessage = e.Message;
            }
            return View();
        }

        //GET:
        public ActionResult GetUserRoles()
        {
            ViewBag.Users = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
            return View();
        }

        //Post:
        [HttpPost]
        public ActionResult GetUserRoles(string Email)
        {
            try
            {
                var user = userManager.FindByEmail(Email);
                ViewBag.Roles = userManager.GetRoles(user.Id);
                ViewBag.Users = context.Users.ToList().Select(u => new SelectListItem { Value = u.Email, Text = u.Email }).ToList();
                ViewBag.Email = Email;
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }
            return View();
        }

        public ActionResult DeleteUserRole(string Email, string Role)
        {
            var user = userManager.FindByEmail(Email);
            if (this.userManager.IsInRole(user.Id,Role))
            {
                this.userManager.RemoveFromRole(user.Id,Role);
            }
            return RedirectToAction("Index");
        }
    }
}