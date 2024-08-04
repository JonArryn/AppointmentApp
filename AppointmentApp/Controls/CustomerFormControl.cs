using AppointmentApp.Constant;
using AppointmentApp.Database;
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
    public partial class CustomerFormControl : UserControl
    {
        CountryService _countryService;
        CityService _cityService;
        public CustomerFormControl()
        {
            InitializeComponent();
            _countryService = ServiceLocator.Instance.CountryService;
            _cityService = ServiceLocator.Instance.CityService;
            PopulateCities();
            PopulateCountries();
        }

        private void PopulateCountries()
        {
            try
            {
                List<CountryReadDTO> countries = _countryService.GetAllCountries();
                countryComboBox.DataSource = countries;
                countryComboBox.DisplayMember = "CountryName";
                countryComboBox.ValueMember = "CountryId";
            }
            catch(Exception ex)
            {
                Messages.ShowError("Error Getting Countries", ex.Message);
            }

        }

        private void PopulateCities()
        {
            try
            {
                List<CityReadDTO> cities = _cityService.GetAllCities();
                cityComboBox.DataSource = cities;
                cityComboBox.DisplayMember = "CityName";
                cityComboBox.ValueMember = "CityId";
            }
            catch (Exception ex)
            {
                string innerExMessage = "";

                if(ex.InnerException != null)
                {
                    innerExMessage =  $"Inner Exception {ex.InnerException.Message}";
                }

                Messages.ShowError("Error Getting Cities", $"{innerExMessage} - Exception {ex.Message}");
               
            }
        }
    }
}
