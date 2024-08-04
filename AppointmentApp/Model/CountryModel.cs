using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Model
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public DateTime CreateDate {get; set;}
        public string CreatedBy {get; set;}
        public DateTime LastUpdate {get; set;}
        public string LastUpdateBy {get; set;}
    }

    public class CountryReadDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
