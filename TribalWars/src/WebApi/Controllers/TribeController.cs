﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class TribeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
