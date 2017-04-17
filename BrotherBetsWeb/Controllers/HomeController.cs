﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrotherBetsLibrary;
using BrotherBetsLibrary.Models;

namespace BrotherBetsWeb.Controllers
{
    public class HomeController : Controller
    {
        private BookMaker _bookMaker;
        private BookMaker Bookie => _bookMaker ?? (_bookMaker = new BookMaker());
        private BrotherManager _broManager;
        private BrotherManager BrotherManager => _broManager ?? (_broManager = new BrotherManager());
        private BettorManager _bettorManager;
        private BettorManager BettorManager => _bettorManager ?? (_bettorManager = new BettorManager());

        public ActionResult Index()
        {
            var bets = Bookie.GetBets();

            return View(bets);
        }


        public ActionResult Guess(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Bet newBet, string bettorName, string brotherName, string[] outcomes)
        {
            try
            {
                var brother = BrotherManager.Get(brotherName);
                var bettor = BettorManager.Get(bettorName);
                if (bettor == null)
                {
                    BettorManager.Add(bettorName);
                    bettor = BettorManager.Get(bettorName);
                }
                
                Bookie.AddBet(newBet, bettor, brother, outcomes);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View(newBet);
            }
            
            return RedirectToAction("Index");
        }
    }
}