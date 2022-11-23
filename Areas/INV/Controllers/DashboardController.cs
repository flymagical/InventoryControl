﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Controllers
{
    [Area("INV")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ActiveClass = "link-dashboard";
            return View();
        }
    }
}
