using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameRuls.Models;
using System.Drawing;
using GameRuls.Assistant;

namespace GameRuls.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Game");
        }

        [HttpPost]
        public IActionResult Index(string room, int sizePlaingFaild, int sizeWin)
        {
            string[] game = new string[] { room, sizePlaingFaild.ToString(), sizeWin.ToString() };
            return View("Index", game);
        }


        public JsonResult InitMap(int sizePlaingFaild)
        {
            WorkingMap.InitMap(sizePlaingFaild);
            return new JsonResult("");
        }

        public JsonResult Move(int player, string coordinat, int sizePlaingFaild, int sizeWin)
        {
            var coordinats = coordinat.Split('x');
            int x = int.Parse(coordinats[0]);
            int y = int.Parse(coordinats[1]);
            GameRuls.Assistant.Move.PlayerMove(player, x, y, sizePlaingFaild);

            if (Rule.CheckWin(player, sizePlaingFaild, sizeWin))
            {
                return new JsonResult("Win player - " + player + " !!!");
            }
            return new JsonResult("");
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
