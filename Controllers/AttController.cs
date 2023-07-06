using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EsameFabio1.DB;
using EsameFabio1.DB.Entities;
using EsameFabio1.Models;
using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EsameFabio1.Controllers
{
    
    public class AttController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly DBContext dbContext;
        private readonly Repository repository;
        public AttController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            DBContext dbContext,
            Repository repository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.repository = repository;

        }

       
        //public IActionResult Attivita()
        //{
        //    //qui manca una parte che devo sistemare
        //   List<Attivita> attivita = this.repository.GetAttivita();
        //    List<AttivitaModel> model = new List<AttivitaModel>();
        //    foreach (Attivita a in attivita)
        //    {
        //        AttivitaModel result = new AttivitaModel()
        //        {
        //            IdAttivita = a.IdAttivita,
        //            NomeAttivita = a.NomeAttivita,
        //            DescrizioneAttivita = a.DescrizioneAttivita,
        //            DataInizio = a.DataInizio,
        //            DataFine = a.DataFine,
        //            NumeroPosti = a.NumeroPosti,
        //            PrezzoAttivita = a.PrezzoAttivita

        //        };

        //        model.Add(result);
        //    }
        //    return View(model);
        //}
        //[Authorize]
        //public IActionResult HiddenPage()
        //{

        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAttivita()
        {
            List<Attivita> attivita = this.repository.GetAttivita();
            List<AttivitaModel> model = new List<AttivitaModel>();
            foreach (Attivita a in attivita)
                model.Add(new AttivitaModel()
                {
                    IdAttivita = a.IdAttivita,
                    NomeAttivita = a.NomeAttivita,
                    DescrizioneAttivita = a.DescrizioneAttivita,
                    DataInizio = a.DataInizio,
                    DataFine = a.DataFine,
                    NumeroPosti = a.NumeroPosti,
                    PrezzoAttivita = a.PrezzoAttivita
                });
            return View(model);
            
        }
        [Authorize(Roles = "Admin")]
        public IActionResult InsertAttivita()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateAttivita()
        {
            List<Attivita> attivita = this.repository.GetAttivita();
            List<AttivitaModel> model = new List<AttivitaModel>();
            foreach (Attivita a in attivita)
                model.Add(new AttivitaModel()
                {
                    IdAttivita = a.IdAttivita,
                    NomeAttivita = a.NomeAttivita,
                    DescrizioneAttivita = a.DescrizioneAttivita,
                    DataInizio = a.DataInizio,
                    DataFine = a.DataFine,
                    NumeroPosti = a.NumeroPosti,
                    PrezzoAttivita = a.PrezzoAttivita
                });
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

