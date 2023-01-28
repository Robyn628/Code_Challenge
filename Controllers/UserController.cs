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

        public IActionResult Details(int userId)         // URL = /user/Details/1
        {
            UserDAO userDAO = new UserDAO();
            UserModel user = userDAO.GetOne(userId);

            return View("Details", user);
        }


        public IActionResult Create()
        {
            return View("UserForm");
        }

        public IActionResult Edit(int userId)
        {
            UserDAO userDAO = new UserDAO();
            UserModel user = userDAO.GetOne(userId);
            return View("UserForm", user);
        }
        public IActionResult Delete(int userId)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.Delete(userId);

            List<UserModel> user = userDAO.GetAll();

            return View("Index", user);
        }


        [HttpPost]
        public IActionResult ProcessCreate(UserModel userModel)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.CreateUpdate(userModel);

            return View("Details", userModel.UserId);
        }
    }
}
