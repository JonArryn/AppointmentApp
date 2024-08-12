using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp { 
    public class TranslationService
    {
        public string CurrentCultureAbv { get; set; }
        public string CountryName { get; set; }
        public TranslationService()
        {
            CurrentCultureAbv = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            CountryName = RegionInfo.CurrentRegion.EnglishName;
        }

        public string GetCulture() {             
            return CurrentCultureAbv;
        }

        public Dictionary<string, string> EnglishLogin = new Dictionary<string, string> { 

            { "Username", "Username" },
            {"Password", "Password" },
            {"Login", "Login" },
            {"InvalidLogin", "Login Credentials Invalid" },
            {"Location", "Current Country" },
            {"ExitApplication", "Exit Application" }
        };

        public Dictionary<string, string> SpanishLogin = new Dictionary<string, string> {

            {"Username", "Nombre de Usario" },
            {"Password", "Contraseña" },
            {"Login", "Acceso" },
            {"InvalidLogin", "Credenciales de usuario no válidas" },
            {"Location", "País Actual" },
            {"ExitApplication", "Salir de la Aplicación" }

        };
      
        
          
        
    }
}
