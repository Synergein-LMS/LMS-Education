﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
