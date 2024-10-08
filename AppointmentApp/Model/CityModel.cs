﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Model
{
    public class CityModel
    {
        public int CityId { get; set; }
        public string City {get; set;}
        public int CountryId {get; set;}
        public DateTime CreateDate {get; set;}
        public string CreatedBy {get; set;}
        public DateTime LastUpdate {get; set;}
        public string LastUpdateBy {get; set;}
    }

    public class CityReadDTO
    {
        public int CityId {get; set;}
        public string CityName {get; set;}
        public int CountryId {get; set;}
    }
}
