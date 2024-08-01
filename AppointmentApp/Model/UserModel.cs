using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Model
{
    public class UserModel
    {
        public int UserId { get; set; } 
        public string UserName { get; set; } 
        public string Password { get; set; } 
        public bool Active { get; set; } 
        public DateTime CreateDate { get; set; } 
        public string CreatedBy { get; set; } 
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; } 
    }
}
