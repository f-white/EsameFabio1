using EsameFabio1.DB;
using EsameFabio1.DB.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EsameFabio1.DB
{
    public class Repository
    {
        private DBContext DBContext;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public Repository(DBContext DBContext, SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.DBContext = DBContext;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public List<Attivita> GetAttivita()
        {
            //select * from attività
            List<Attivita> result = this.DBContext.Attivita.ToList();
            return result;
        }

        public List<User> GetUsers()
        {
            //select * from persons
            List<User> result = this.DBContext.Users.ToList();
            return result;
        }
        
		/* public Person GetPersonByID(string id)
		 {
			 //select * from persons where id = "id"
			 Person result = this.DBContext.Persons.Where(p => p.ID.ToString() == id).FirstOrDefault();
			 return result;
		 } 
		 public List<Person> GetPersonWithFilter(string filter)
		 {
			 //select * from persons where nome like "%filter%"
			 //or cognome like "%filter%"
			 List<Person> result = this.DBContext.Persons
				 .Where(p => p.Nome.Contains(filter)
				 || p.Cognome.Contains(filter)).ToList();
			 return result;
		 }
		*/
		 public void InsertAttivita(Attivita attivita)
		 {
			 this.DBContext.Attivita.Add(attivita);
			 this.DBContext.SaveChanges();
		 }
		 public void UpdateAttivita(Attivita attivitaupd)
        {

            this.DBContext.Attivita.Update(attivitaupd);
            this.DBContext.SaveChanges();
    //        Attivita toUpdate = this.DBContext.Attivita
    //        .Where(a => a.IdAttivita == attivitaupd.IdAttivita).FirstOrDefault();
    //        this.DBContext.Attivita.Update(attivitaupd);
			 //this.DBContext.SaveChanges();
		 }
		 public void DeleteAttivita(Guid ID)
		 {
			 Attivita toDelete = this.DBContext.Attivita
					 //.Where(p => p.ID != null && p.ID.Value.ToString() == ID) nel caso fosse nullable
					 .Where(a => a.IdAttivita == ID)
					 .FirstOrDefault();
			 this.DBContext.Attivita.Remove(toDelete);
			 this.DBContext.SaveChanges();    
		 }

        public void AddPrenotazione(string userId, Guid attivitaId)
        {
            var attivita = this.DBContext.Attivita.FirstOrDefault(a => a.IdAttivita == attivitaId);
            Prenotazione prenotazione = new Prenotazione
            {
                IdPrenotazioneAttivita = Guid.NewGuid(), // Genera un nuovo ID per la prenotazione
                IdUtente = userId,
                IdAttivita = attivitaId,
                CrossAttivita = attivita

            };

            this.DBContext.Prenotazioni.Add(prenotazione);
            this.DBContext.SaveChanges();

        }
        //public List<PrenotazioneModel> GetPrenotazione(User user)
        //{
        //    bool isAdmin = signInManager.UserManager.IsInRoleAsync(user, "Admin").Result;
        //    var prenotazioni = this.DBContext.Prenotazioni.Where(p => p.IdUtente == user.Id).AsQueryable();

        //    List<PrenotazioneModel> prenotazioniList = prenotazioni
        //        .Select(p => new PrenotazioneModel
        //        {
        //            IdPrenotazioneAttivita = p.IdPrenotazioneAttivita,
        //            IdUtente = p.IdUtente,
        //            IdAttivita = p.IdAttivita,
        //            CrossAttivita = p.CrossAttivita
        //        }).ToList();

        //    return prenotazioniList;
        //}
        public List<PrenotazioneModel> GetPrenotazione(User user)
        {
            IQueryable<Prenotazione> prenotazioniQuery = this.DBContext.Prenotazioni;

            // Verifica se l'utente ha il ruolo di amministratore
            bool isAdmin = signInManager.UserManager.IsInRoleAsync(user, "Admin").Result;

            if (!isAdmin)
            {
                // Se l'utente non è un amministratore, filtra le prenotazioni per l'ID utente
                prenotazioniQuery = prenotazioniQuery.Where(p => p.IdUtente == user.Id);
            }

            List<PrenotazioneModel> prenotazioniList = prenotazioniQuery
                .Select(p => new PrenotazioneModel
                {
                    IdPrenotazioneAttivita = p.IdPrenotazioneAttivita,
                    IdUtente = p.IdUtente,
                    IdAttivita = p.IdAttivita,
                    CrossAttivita = p.CrossAttivita,
                    CrossUtente = p.CrossUtente
                }).ToList();

            return prenotazioniList;
        }
        public void DeletePrenotazione(Guid idPrenotazioneAttivita)
        {
            Prenotazione toDelete = this.DBContext.Prenotazioni
                    //.Where(p => p.ID != null && p.ID.Value.ToString() == ID) nel caso fosse nullable
                    .Where(p => p.IdPrenotazioneAttivita == idPrenotazioneAttivita)
                    .FirstOrDefault();
            this.DBContext.Prenotazioni.Remove(toDelete);
            this.DBContext.SaveChanges();
        }

    }
}
