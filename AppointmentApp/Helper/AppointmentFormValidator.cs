using AppointmentApp.Constant;
using AppointmentApp.EventManager;
using AppointmentApp.Model;
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Helper
{
    public class AppointmentFormValidator
    {
        private List<string> _errors;

        private int CustomerId { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private string Type { get; set; }
        private DateTime Start { get; set; }
        private DateTime End { get; set; }

       

        public AppointmentFormValidator(AppointmentCreateDTO appointment)
        {
            _errors = new List<string>();

            CustomerId = appointment.CustomerId;
            Title = appointment.Title;
            Description = appointment.Description;
            Type = appointment.Type;
            Start = appointment.Start;
            End = appointment.End;

        }

        public List<string> ValidateApptForm()
        {
            if(CustomerId == 0)
            {
                _errors.Add("Customer is required.");
            }
            if(string.IsNullOrWhiteSpace(Title))
            {
                _errors.Add("Title is required.");
            }
            if (!string.IsNullOrWhiteSpace(Title) && Title.Length > 255)
            {
                _errors.Add("Title must be less than 255 characters.");
            }
            if(string.IsNullOrWhiteSpace(Description))
            {
                _errors.Add("Description is required.");
            }
            if (!string.IsNullOrWhiteSpace(Description) && Description.Length > 255)
            {
                _errors.Add("Description must be less than 255 characters.");
            }
            if(string.IsNullOrWhiteSpace(Type))
            {
                _errors.Add("Type is required.");
            }
            if(Start < DateTime.Now)
            {
                _errors.Add("Start date must be in the future.");
            }
            if(End < Start)
            {
                _errors.Add("End date must be after start date.");
            }
            return _errors;
        }




    }
}
