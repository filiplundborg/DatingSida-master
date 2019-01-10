using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DatingSida.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Extra properties utöver de som finns default
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Description { get; set; }
        public virtual string Image { get; set; } = @"Images\avatar.png";

        //Foreign keys / Navigation properties
        public virtual ICollection<Message> MessageSent { get; set; }
        public virtual ICollection<Message> MessageReceived { get; set; }
        public virtual ICollection<Request> RequestSent { get; set; }
        public virtual ICollection<Request> RequestReceived { get; set; }

        public virtual ICollection<Friends> FriendsReceived { get; set; }
        public virtual ICollection<Friends> FriendsRequested { get; set; }

        //Konstruktor för att instansiera främmande nycklar

        public ApplicationUser() : base()
        {
            MessageSent = new List<Message>();
            MessageReceived = new List<Message>();
            RequestSent = new List<Request>();
            RequestReceived = new List<Request>();
            FriendsReceived = new List<Friends>();
            FriendsRequested = new List<Friends>();
        }


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
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}