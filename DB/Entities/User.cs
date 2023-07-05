using Microsoft.AspNetCore.Identity;

namespace EsameFabio1.DB.Entities
{
    public class User : IdentityUser
    {
		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
