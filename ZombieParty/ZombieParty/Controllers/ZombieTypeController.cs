using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.ViewModels;

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
            List<ZombieType> ZombieTypesList = _baseDonnees.ZombieTypes.ToList();
            {
                //new ZombieType(){TypeName= "Virus", Id=1},
                //new ZombieType(){TypeName= "Contact", Id=2}
            };

            return View(ZombieTypesList);
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

        public IActionResult Details(int id)
        {
            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = new(),
                ZombiesList = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).ToList()
            };

            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                zombieTypeVM.ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id);
                return View(zombieTypeVM);
            }

        }


    }
}
