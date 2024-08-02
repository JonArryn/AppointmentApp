using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp { 
    public class TranslationService
    {
        public string CurrentCulture { get; set; }
        public TranslationService()
        {
            CurrentCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        public string GetCulture() {             
            return CurrentCulture;
        }

        public Dictionary<string, string> EnglishLogin = new Dictionary<string, string> { 

            { "Username", "Username" },
            {"Password", "Password" },
            {"Login", "Login" },
            {"InvalidLogin", "Login Credentials Invalid" }
        };

        public Dictionary<string, string> SpanishLogin = new Dictionary<string, string> {

            {"Username", "Nombre de Usario" },
            {"Password", "Contraseña" },
            {"Login", "Acceso" },
            {"InvalidLogin", "Credenciales de usuario no válidas" }

        };
      
        
          
        
    }
}
