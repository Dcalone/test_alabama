using albama.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace albama.Controllers
{
    public class HomeController:Controller
    {
        public HomeController(IClock clock)
        {

        }
    }
}
