using DatingSida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Repository
{
    public class UserRequest
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public void SaveRequest(string senderId, string receiverId) {
            try
            {
                var request = new Request {
                    RequestSenderId = senderId,
                    RequestReceiverId = receiverId
                };
                
                db.Requests.Add(request);
                db.SaveChanges();

            }
            catch {

                throw new Exception();
            }
        }
    }
}