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
    
    public class HomeController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly DBContext dbContext;
        private readonly Repository repository;
        public HomeController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            DBContext dbContext,
            Repository repository)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.repository = repository;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Attivita()
        {
            //qui manca una parte che devo sistemare per listare solo le attività che sono prenotabili
           List<Attivita> attivita = this.repository.GetAttivita();
            List<AttivitaModel> model = new List<AttivitaModel>();
            foreach (Attivita a in attivita)
            {
                AttivitaModel result = new AttivitaModel()
                {
                    IdAttivita = a.IdAttivita,
                    NomeAttivita = a.NomeAttivita,
                    DescrizioneAttivita = a.DescrizioneAttivita,
                    DataInizio = a.DataInizio,
                    DataFine = a.DataFine,
                    NumeroPosti = a.NumeroPosti,
                    PrezzoAttivita = a.PrezzoAttivita,
                    ImgAtt = a.ImgAtt

                };

                model.Add(result);
            }
            return View(model);
        }
        [Authorize]
        public IActionResult AttivitaPrenotate()
        {
            List<PrenotazioneModel> attivitaPrenotate = repository.GetPrenotazione
                (idUtente);
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
       
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                User user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Redirect("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (signInManager.IsSignedIn(User))
                {
                    await signInManager.SignOutAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

