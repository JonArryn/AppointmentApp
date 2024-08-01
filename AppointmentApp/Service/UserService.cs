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

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public bool IsLoggedIn => UserID > 0;

        public void StartSession(string userName, string password)
        {

            UserModel user = _userRepo.Login(userName, password);
            if (user == null)
            {
                throw new Exception("Invalid username or password");
            }

            UserID = user.UserId;
            Username = user.UserName;
        }

        public void EndSession()
        {
            UserID = 0;
            Username = string.Empty;
        }
    }
}
