using AppointmentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Helper
{
    public class CityEventArgs : EventArgs
    {
        public CityReadDTO City { get; set; }

        public CityEventArgs(CityReadDTO city)
        {
            City = city;
        }
    }
}
