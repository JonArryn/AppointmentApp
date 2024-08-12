using AppointmentApp.Constant;
using AppointmentApp.Helper;
using AppointmentApp.EventManager;
using AppointmentApp.Helper;
using AppointmentApp.Model;
using AppointmentApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentApp.Controls
{
    public partial class ManageCountryControl : UserControl
    {
        CountryReadDTO _country;
        private readonly bool _isNewCountry;
        private bool _isInitializing;

        CountryService _countryService;


        public ManageCountryControl(int? countryId = null)
        {
            InitializeComponent();
            _isInitializing = true;

            _countryService = ServiceLocator.Instance.CountryService;

            if (countryId.HasValue)
            {
                _isNewCountry = false;
                _country = PopulateCountry(countryId.Value);
                this.manageCountryTItle.Text = "Edit Country";
            }
            else
            {
                _isNewCountry = true;
                _country = new CountryReadDTO();
                this.manageCountryTItle.Text = "New Country";
            }
            _isInitializing = false;
        }

        // INITIALIZERS //

        private CountryReadDTO PopulateCountry(int countryId)
        {
            CountryReadDTO country = _countryService.GetCountryById(countryId);
            this.countryNameTextbox.Text = country.CountryName;
            return country;
        }


        // EVENT HANDLERS //

        private void saveEditCountryButton_Click(object sender, EventArgs e)
        {
            if (_isNewCountry)
            {
                CountryReadDTO country;
                country = _countryService.CreateCountry(_country.CountryName);
                if (country != null)
                {
                    EventMediator.Instance.Publish(COUNTRY_EVENTS.COUNTRY_CREATED, country); 
                }
                else
                {
                    Messages.ShowError("Error Creating Country", "There was an error creating the country.");
                    return;
                }
            }
            else
            {
                bool countryUpdated;
                countryUpdated = _countryService.UpdateCountry(_country);
                EventMediator.Instance.Publish(COUNTRY_EVENTS.COUNTRY_UPDATED);
                if (!countryUpdated)
                {
                    Messages.ShowError("Error Updating Country", "There was an error updating the country.");
                    return;
                }
            }
            this.ParentForm.Close();
            this.Dispose();

        }

        private void cancelEditCountryButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            this.Dispose();
        }

        private void countryNameTextbox_TextChanged(object sender, EventArgs e)
        {
            if(_isInitializing == false)
            {
                _country.CountryName = this.countryNameTextbox.Text;
            }
            
        }
    }
}
