using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OceanicAirlines.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Get the connection string getting SqlServerInstance and DbName from Session.
        /// </summary>
        public static string GetConnectionString()
        {

            string sqlServerInstance = "dbs-oa-dk1.database.windows.net";
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["SqlServerInstance"] != null)
                sqlServerInstance = Convert.ToString(HttpContext.Current.Session["SqlServerInstance"]);

            string dbName = "db-oa-dk1";
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["DbName"] != null)
                dbName = Convert.ToString(HttpContext.Current.Session["DbName"]);

            return "Data Source=" + sqlServerInstance + ";Initial Catalog=" + dbName + ";Integrated Security=True";

        }
    }
}