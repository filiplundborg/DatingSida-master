using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserVisitor
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        //Lägger till ett besök
        public void AddVisit(string visitReceived, string visitSend) {
            try
            {
               
                var visit = new Visitors
                {
                    VisitSendId = visitSend,
                    VisitReceivedId = visitReceived,
                    DateSent = DateTime.Now
                };
                
                db.Visitors.Add(visit);
                db.SaveChanges();
            }
            catch (Exception exc) {
                throw new Exception();
            }
   
        }

        //Hämtar de senaste besöken. Tar bara distinkta värden och sorterar efter datum.
        public List<ApplicationUser> GetVisits(string userId) {
            var users = db.Visitors.Where(i => i.VisitReceivedId == userId).OrderByDescending(i => i.DateSent).Select(i => i.VisitSender).ToList().Distinct();
            List<ApplicationUser> DistinctUser = new List<ApplicationUser>();
            foreach (var item in users) {
                DistinctUser.Add(item);
            }

            return DistinctUser;
        }
    }
}