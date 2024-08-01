using AppointmentApp.Repository;
using AppointmentApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Service
{
    public class UserService
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }

        private readonly UserRepository _userRepo;

        public bool IsLoggedIn => UserID > 0;

        public UserService()
        {
            _userRepo = new UserRepository();
        }


        public void StartSession(string userName, string password)
        {

            UserModel user = _userRepo.Login(userName, password);
            if(user != null)
            {
                UserID = user.UserId;
                Username = user.UserName;
            }
     

        }

        private void EndSession()
        {
            UserID = 0;
            Username = string.Empty;
        }
    }
}
