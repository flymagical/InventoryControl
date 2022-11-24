using InventoryControl.Data;
using InventoryControl.Models;
using InventoryControl.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace InventoryControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly InventoryControlContext _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, InventoryControlContext context)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<IActionResult> Index(string returnUrl = "")
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId != null)
            {
                var password = HttpContext.Session.GetString("Password");
                var model = new MstUser { Id = Guid.Parse(userId), Password = password };
                //await AccessingUserService(ActionType.DeleteTokenCMS, ServiceType.POST, model);
                var user = _context.MstUser.SingleOrDefault(x => x.Id == Guid.Parse(userId));
                if(user.Token != null)
                {
                    user.Token = null;
                    _context.MstUser.Update(user);
                    await _context.SaveChangesAsync();
                }
            }

            HttpContext.Session.Clear();
            foreach (var cookieKey in Request.Cookies.Keys)
                if (cookieKey == "AuthToken" || cookieKey == ".InventoryControl.Session")
                    Response.Cookies.Delete(cookieKey);
            ViewBag.ReturnUrl = returnUrl;

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(MstUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authId = SecurityHelper.GenerateAuthId();
                    Response.Cookies.Append("AuthToken", authId);
                    HttpContext.Session.SetString("AuthId", authId);
                    
                    //var responseExist = await AccessingUserService(ActionType.GetSingleLogin, ServiceType.GET, model);
                    var userExist = _context.MstUser.SingleOrDefault(x => x.Id == user.Id && x.Password == SecurityHelper.Encrypt(user.Password));

                    if (userExist != null)
                    {
                        HttpContext.Session.SetString("UserId", user.Id.ToString());
                        HttpContext.Session.SetString("Password", user.Password);

                        var userAgent = HttpContext.Request.Headers["User-Agent"];
                        var uaParser = Parser.GetDefault();
                        ClientInfo clientInfo = uaParser.Parse(userAgent);
                        var clientUnique = clientInfo.UserAgent.Family + "." + clientInfo.UserAgent.Major + "." + clientInfo.UserAgent.Minor + "." + clientInfo.UserAgent.Patch;
                        //model.LastLogin = DateTime.Now;
                        userExist.Token = SecurityHelper.Encrypt(clientUnique);

                        await _context.SaveChangesAsync();
                        
                        if (string.IsNullOrEmpty(user.ReturnURL))
                            return RedirectToAction("Index", "Dashboard", new { Area = "INV"});
                        else
                            return Redirect(user.ReturnURL);
                    }
                    else
                    {
                        ViewBag.Message = "Incorrect username or password";
                    }

                }

                return View("Index", user);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Login");
            }
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
