using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserVisitor
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public void AddVisit(string visitSendId, string visitReceivedId) {
            UserProfile u = new UserProfile();
            var visit = new Visitors
            {
                VisitSendId = visitSendId,
                VisitReceivedId = visitReceivedId,
                DateSent = DateTime.Now
            };
            db.Visitors.Add(visit);
            db.SaveChanges();
        }

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