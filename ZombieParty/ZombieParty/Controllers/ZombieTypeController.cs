﻿using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {

        private BaseDonnees _baseDonnees { get; set; }

        public ZombieTypeController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }


        public IActionResult Index()
        {
            this.ViewBag.MaListe = _baseDonnees.ZombieTypes.ToList();
            {
                //new ZombieType(){TypeName= "Virus", Id=1},
                //new ZombieType(){TypeName= "Contact", Id=2}
            };

            return View();
        }

        //GET CREATE
        public IActionResult Create()
        {


            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _baseDonnees.ZombieTypes.Add(zombieType);
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");

            }

            return this.View(zombieType);
        }

    }
}
