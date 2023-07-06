using EsameFabio1.DB;
using EsameFabio1.DB.Entities;
using System;
using System.Collections.Generic;
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
            //select * from persons
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
		 public void UpdateAttivita(Attivita attivita)
		 {
			 this.DBContext.Attivita.Update(attivita);
			 this.DBContext.SaveChanges();
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
    }
}
