using Code_Challenge.Data;
using Code_Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace Code_Challenge.Controllers
{
    public class UserController : Controller
    {

        // GET : Users
        public IActionResult Index()                // URL = /user/index
        {
            List<UserModel> user = new List<UserModel>();
            
            UserDAO userDAO = new UserDAO();

            user = userDAO.GetAll();

            return View("Index", user);
        }

        public IActionResult Details(int Id)         // URL = /user/Details/1
        {
            UserDAO userDAO = new UserDAO();
            UserModel user = userDAO.GetOne(Id);

            return View("Details", user);
        }


        public IActionResult Create()
        {
            return View("UserForm");
        }
        public IActionResult ProcessCreate(UserModel userModel)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.Create(userModel);

            return View("Details", userModel.UserId);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
