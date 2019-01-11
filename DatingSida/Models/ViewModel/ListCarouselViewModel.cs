using DatingSida.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSida.Models.ViewModel
{
    public class ListCarouselViewModel
    {
        public List<CarouselViewModel> carousels = new List<CarouselViewModel>();
        public ListCarouselViewModel(bool FillModel = false) {
            if (FillModel) {
                var userprofile = new UserProfile();
                carousels = userprofile.GetRandomUsers();
            }
        }
    }
}