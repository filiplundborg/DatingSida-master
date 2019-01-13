using DatingSida.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models.DBInitilizer
{
    public class ApplicationDbContextSeed : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
           
            var passwordhash = new PasswordHasher();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var applicationUser1 = new ApplicationUser
            {
                Firstname = "Horatio",
                Lastname = "Nelson",
                UserName = "LordNelson",
                Email = "Lord_Nelson@NelsonEnterprises.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "Vem är du ? Vad har du för identitet ? Hur väljer du att beskriva dig själv ? Vilken roll väljer du att identifiera dig med först ?",
                DateOfBirth = "1992-07-12",
                Image = @"Images\Lordnelson.jpg",
                InterestedIn = "Båda"
            };
            var applicationUser2 = new ApplicationUser
            {
                Firstname = "Karl",
                Lastname = "XII",
                UserName = "CarolusRex",
                Email = "CarolusRex@Kungahuset.se",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "Dödade en björn när jag var 8. Spöade skiten ur Danmark, Polen och Ryssen. Samtidigt. Framåt karoliner!",
                DateOfBirth = "1985-07-12",
                Image = @"Images\karltolv.jpg",
                InterestedIn = "Båda"
            };
            var applicationUser3 = new ApplicationUser
            {
                Firstname = "Marie",
                Lastname = "Antoinette",
                UserName = "MarieAntoinette",
                Email = "MarieAntoinette@FranskaRevolutionen.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Kvinna",
                Description = "Varför äter dem inte bakelser ?!?!?!?!?!?!",
                DateOfBirth = "1953-04-27",
                Image = @"Images\maria.jpg",
                InterestedIn = "Kvinnor"
            };
            var applicationUser4 = new ApplicationUser
            {
                Firstname = "Nils",
                Lastname = "Bielke",
                UserName = "Bielke",
                Email = "BielkeCool@slagetvidlund.se",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "min krona hängde på Bielkes värjspets, och att jag näst efter Gud hade min tappre Bielke samt mitt livregemente att tacka för segern",
                DateOfBirth = "1945-02-12",
                Image = @"Images\bielke.jpg",
                InterestedIn = "Kvinnor"
            };
            var applicationUser5 = new ApplicationUser
            {
                Firstname = "Otto",
                Lastname = "Von Bismarck",
                UserName = "VonOtto",
                Email = "Otto@VonBismarck.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "Preussen måste koncentrera och vidmakthålla sin makt för det gynnsamma tillfälle som redan har glidit förbi flera gånger. Preussens gränser i enlighet med Wienkongressens avtal är inte till fördel för ett hälsosamt statsliv.",
                DateOfBirth = "1929-07-12",
                Image = @"Images\otto.jpeg",
                InterestedIn = "Kvinnor"
            };
            var applicationUser6 = new ApplicationUser
            {
                Firstname = "Ivar",
                Lastname = "Kreuger",
                UserName = "Solstickan",
                Email = "Ivar.Kreuger@swedishmatch.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "Låt oss undvika att skaffa fiender. Sådana tar alldeles för lång tid.",
                DateOfBirth = "1935-03-11",
                Image = @"Images\kreuger.jpg",
                InterestedIn = "Män"
            };
            var applicationUser7 = new ApplicationUser
            {
                Firstname = "Drottning",
                Lastname = "Blanka",
                UserName = "QueenOfEverything",
                Email = "QueenOfEverything@hotmail.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Kvinna",
                Description = "Nu skall jag i solen gå ut en stund bland andra stora människor och små som tar tid att vandra runt en stund i Guds natur och i stadens gränder för att märka om och hur något märkligt händer.",
                DateOfBirth = "1982-07-12",
                Image = @"Images\blanka.jpg",
                InterestedIn = "Båda"
            };
            var applicationUser8 = new ApplicationUser
            {
                Firstname = "Marilyn",
                Lastname = "Monroe",
                UserName = "MissUniverse",
                Email = "MissUniverse@Enterprises.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Kvinna",
                Description = "Jag har inga problem med att leva i en mansvärld så länge jag kan vara en kvinna i den.",
                DateOfBirth = "1962-07-12",
                Image = @"Images\marilyn.jpg",
                InterestedIn = "Båda"
            };
            var applicationUser9 = new ApplicationUser
            {
                Firstname = "Mary",
                Lastname = "Wollstonecraft",
                UserName = "Wollstonecraft",
                Email = "Wollstonecraft@gmail.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Kvinna",
                Description = "Men and women must be educated, in a great degree, by the opinions and manners of the society they live in.",
                DateOfBirth = "1972-07-12",
                Image = @"Images\mary.jpg",
                InterestedIn = "Båda"
            };
            var applicationUser10 = new ApplicationUser
            {
                Firstname = "Alfred",
                Lastname = "Nobel",
                UserName = "DynamitAlfred",
                Email = "Alfred@Nobel.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "Hoppet är naturens slöja för att dölja sanningens nakenhet.",
                DateOfBirth = "1945-07-12",
                Image = @"Images\nobel.jpg",
                InterestedIn = "Båda"
            };
            var applicationUser11 = new ApplicationUser
            {
                Firstname = "Margaret",
                Lastname = "Thatcher",
                UserName = "IronLady",
                Email = "Margaret@IronLady.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Kvinna",
                Description = "if you take the tough decisions, people will hate you today, but they will love you in generations.",
                DateOfBirth = "1952-07-12",
                Image = @"Images\maggan.jpg",
                InterestedIn = "Män"
            };
            var applicationUser12 = new ApplicationUser
            {
                Firstname = "Joe",
                Lastname = "Rogan",
                UserName = "LordRogan",
                Email = "LordRogan@ufc.com",
                PasswordHash = passwordhash.HashPassword("Samuel22."),
                Gender = "Man",
                Description = "Once you understand what excellence is all about…you see how excellence manifests itself in any discipline.",
                DateOfBirth = "1985-07-12",
                Image = @"Images\rogan.jpg",
                InterestedIn = "Båda"
            };
            manager.Create(applicationUser1);
            manager.Create(applicationUser2);
            manager.Create(applicationUser3);
            manager.Create(applicationUser4);
            manager.Create(applicationUser5);
            manager.Create(applicationUser6);
            manager.Create(applicationUser7);
            manager.Create(applicationUser8);
            manager.Create(applicationUser9);
            manager.Create(applicationUser10);
            manager.Create(applicationUser11);
            manager.Create(applicationUser12);
            
            db.SaveChanges();
            base.Seed(db);
        }
    }
}