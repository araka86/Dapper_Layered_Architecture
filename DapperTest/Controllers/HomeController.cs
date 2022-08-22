using DapperTest.BL.Interfaces;
using DapperTest.Models;
using DapperTest.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBL _userBL;
       static IEnumerable<User> _user = new User[0];

        public HomeController(ILogger<HomeController> logger, IUserBL userBL)
        {
            _logger = logger;
            _userBL = userBL;
        }

        


       
        public IActionResult Index()
        {

            
            if (_user.Count() == 0)
                    return View();

            return View(_user);
        }



        [HttpPost]//получение 2мя методами пользователя(Aunthenticate и GetUserById)
        public IActionResult Index(LoginVM modelLoginVM)
        {
            //получения id пользователя путьем сравнения email из метода UserId
            int? userID = _userBL.Aunthenticate(modelLoginVM.Email, modelLoginVM.Password);

            int findUserId = _userBL.FindIdUser(modelLoginVM.Email); //костиль (в UserBl лoгика dapper)



            //на основе полученого id, получаем обьект User и отправляем его в представление
            if (userID != null)
            {
                return View(_userBL.GetUserById(userID.Value));
            }

            return View(null);
        }

        [HttpPost]//получение одним асинхронным методом пользователя
        public IActionResult FindUser(User loginVM)
        {
            var user = _userBL.Aunthenticate2(loginVM.UserId).Result;

            _user = (IEnumerable<User>)user;
            return RedirectToAction("Index");
        }


        [HttpPost]//получение одним асинхронным методом пользователя
        public IActionResult FindAllUser(LoginVM loginVM)
        {
            IEnumerable<User>  user = _userBL.FindAll(loginVM.Email);

            _user = user;
         
            return RedirectToAction("Index");
        }



      





        [HttpPost]
        public IActionResult Add(User user )
        {

            _userBL.Add(user);

            return RedirectToAction("Index");
          
        }










        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}