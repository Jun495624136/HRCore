using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class MajorController : Controller
    {
        public IActionResult Profession_design()
        {
            return View();
        }

        public IActionResult Major_kind() 
        {
            return View();
        }
     
        public IActionResult Major_Kind_Add() 
        {
            return View();
        }

        public IActionResult Major() 
        {
            return View();
        }
        public IActionResult Major_Add() 
        {
            return View();
        }  
    }
}