using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.ViewModels;


namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        private LuckySpinDataContext _dbc;
        Random random;

        /***
         * Controller Constructor
         */
        public SpinnerController(LuckySpinDataContext newData)
        {
            random = new Random();
            _dbc = newData;
            //TODO: Inject the LuckySpinDataContext
        }

        /***
         * Entry Page Action
         **/

        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid) { return View(); }

            // TODO: Add the Player to the DB and save the changes
            _dbc.Players.Add(player);
            _dbc.SaveChanges();
            // TODO: BONUS: Build a new SpinItViewModel object with data from the Player and pass it to the View
            Spin_ViewModel spinner = new Spin_ViewModel();
            spinner.balance = player.Balance;
            spinner.Luck = player.Luck;
            spinner.playerNAme = player.FirstName;


            return RedirectToAction("SpinIt", spinner);
        }

        /***
         * Spin Action
         **/  
               
         public IActionResult SpinIt(Spin_ViewModel spin)
        {

           
                //Luck = player.Luck,
                spin.A = random.Next(1, 10);
                spin.B = random.Next(1, 10);
                spin.C = random.Next(1, 10);
         

            spin.IsWinning = (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck);

            //Add to Spin Repository
            //repository.AddSpin(spin);
            Spin spinspinner = new Spin()
            {
                IsWinning = spin.IsWinning
            };
            _dbc.Spins.Add(spinspinner);
            _dbc.SaveChanges();

            //Prepare the View
            if(spin.IsWinning)
                ViewBag.Display = "block";
            else
                ViewBag.Display = "none";

            //ViewBag.FirstName = player.FirstName;

            return View("SpinIt", spin);
        }

        /***
         * ListSpins Action
         **/

         public IActionResult LuckList()
        {
                return View();
        }

    }
}

