using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EsameFabio1.DB;
using EsameFabio1.DB.Entities;
using EsameFabio1.Models;

namespace TestFinaleFabio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> logger;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private readonly Repository repository;


        public ApiController(SignInManager<User> signInManager,
           UserManager<User> userManager, Repository repository)
        {
            this.signInManager = signInManager;
			this.userManager = userManager;
			this.repository = repository;
          

        }

      
        // Create User
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    User user = await this.userManager.FindByEmailAsync(userModel.Email);
                    if (user == null)
                    {
                        user = new User
                        {
                            UserName = userModel.UserName,
                            Email = userModel.Email,
                            FirstName = userModel.FirstName,
                            LastName = userModel.LastName
                        };

                        IdentityResult result = await this.userManager.CreateAsync(user, userModel.Password);
                        if (result.Succeeded)
                            return Json("OK");

                        string errors = string.Empty;
                        foreach (IdentityError error in result.Errors)
                            errors += error.Code + ": " + error.Description + "\n";
                        return Json(errors);
                    }
                    else
                        return Json("Email già esistente, riprova.");
                }
            }
            catch (Exception ex)
            {
               
                logger.LogError(ex, ex.Message);
            }

            return Json("Richiesta non valida.");
        }



        // Login User
        [HttpPost("LoginUser")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                User user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, true, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        return Json("OK");
                    }
                    else
                    {

                        return Json("Password errata");
                    }
                  
                }
                else
                {
                    return Json("UserName errato");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return Json("Richiesta non valida.");
        }

        // Logout
        [Authorize]
        [HttpPost("LogoutUser")]
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
            return Json("OK");
        }
        // Inserisci Attività
        [HttpPost("InsertAtt")]
        public async Task<IActionResult> InsertAtt([FromBody] AttivitaModel model)
        {
            Attivita a = new Attivita();
            //chiedere se serve
            a.IdAttivita = System.Guid.NewGuid();
            a.NomeAttivita = model.NomeAttivita;
            a.DescrizioneAttivita = model.DescrizioneAttivita;
            a.DataInizio = model.DataInizio;
            a.DataFine = model.DataFine;
            a.NumeroPosti = model.NumeroPosti;
            a.PrezzoAttivita = model.PrezzoAttivita;
            this.repository.InsertAttivita(a);
            return Ok(200);
        }

        [HttpPost("UpdateAtt")]
        public async Task<IActionResult> UpdateAtt([FromBody] AttivitaModel model)
        {
            Attivita a = new Attivita();
            a.IdAttivita = model.IdAttivita;
            a.NomeAttivita = model.NomeAttivita;
            a.DescrizioneAttivita = model.DescrizioneAttivita;
            a.DataInizio = model.DataInizio;
            a.DataFine = model.DataFine;
            a.NumeroPosti = model.NumeroPosti;
            a.PrezzoAttivita = model.PrezzoAttivita;
            this.repository.UpdateAttivita(a);
            return Ok(200);
        }

        // Cancella Attività
        [HttpPost("DeleteAtt")]
        public async Task<IActionResult> DeleteAtt([FromBody] AttivitaModel model)
        {
            this.repository.DeleteAttivita(model.IdAttivita);
            return Ok(200);
        }




        // Prenota User
        /*  [Authorize]
          [HttpPost("PrenotaUser")]
          public async Task<IActionResult> PrenotaUser([FromBody] CrossAttrazionePeriodoModel crossModel)
          {
              try
              {
                  ClaimsPrincipal currentUser = this.User;

                  string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value; //per avere l'id della persona loggata


                  var result =  AttrazioneService.PrenotaUser(crossModel, userId);

                  if (result == "OK")
                  {
                      return Json("OK");
                  }
                  else
                  {

                      return Json("KO");
                  }


              }
              catch (Exception ex)
              {
                  logger.LogError(ex, ex.Message);
              }

              return Json("Richiesta non valida.");
          }

          // Modifica Posti Prenotati
          [Authorize]
          [HttpPost("ModificaPosti")]
          public async Task<IActionResult> ModificaPosti([FromBody] PrenotazioneModel prenotazioneModel)
          {
              try
              {



                  var result = AttrazioneService.ModificaPosti(prenotazioneModel);

                  if (result == "OK")
                  {
                      return Json("OK");
                  }
                  else
                  {

                      return Json("KO");
                  }


              }
              catch (Exception ex)
              {
                  logger.LogError(ex, ex.Message);
              }

              return Json("Richiesta non valida.");
          }


          [Authorize]
          [HttpPost("CancellaPrenotazione")]
          public async Task<IActionResult> CancellaPrenotazione([FromBody] PrenotazioneModel prenotazioneModel)
          {
              try
              {



                  var result = AttrazioneService.CancellaPrenotazione(prenotazioneModel);

                  if (result == "OK")
                  {
                      return Json("OK");
                  }
                  else
                  {

                      return Json("KO");
                  }


              }
              catch (Exception ex)
              {
                  logger.LogError(ex, ex.Message);
              }

              return Json("Richiesta non valida.");
          }



          [Authorize]
          [HttpPost("CancellaCrossAttrazionePeriodo")]
          public async Task<IActionResult> CancellaCrossAttrazionePeriodo([FromBody] CrossAttrazionePeriodoModel crossModel)
          {
              try
              {



                  var result = AttrazioneService.CancellaCrossAttrazionePeriodo(crossModel);

                  if (result == "OK")
                  {
                      return Json("OK");
                  }
                  else
                  {

                      return Json("KO");
                  }


              }
              catch (Exception ex)
              {
                  logger.LogError(ex, ex.Message);
              }

              return Json("Richiesta non valida.");
          }



          [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
          public IActionResult Error()
          {
              return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
          }

          */




    }
}
