using EsameFabio1.DB;
using EsameFabio1.DB.Entities;
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
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
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
            PrenotazioneModel prenotazione = new PrenotazioneModel
            {
                IdPrenotazioneAttivita = Guid.NewGuid(), // Genera un nuovo ID per la prenotazione
                IdUtente = userId,
                IdAttivita = attivitaId,
                CrossAttivita = attivita


            };

            this.DBContext.Prenotazioni.Add(prenotazione);
            this.DBContext.SaveChanges();

        }
        public List<PrenotazioneModel> GetPrenotazione(string userId)
        {
            var prenotazioni = this.DBContext.Prenotazioni.Include(p => p.IdPrenotazioneAttivita);

            return prenotazioni.ToList();
        }
    }
}
