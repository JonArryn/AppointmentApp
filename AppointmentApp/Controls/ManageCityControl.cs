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
    public partial class ManageCityControl : UserControl
    {
        CountryService _countryService;
        CityService _cityService;
        CityReadDTO _city;
        public ManageCityControl(CityReadDTO city)
        {
            InitializeComponent();
            _countryService = ServiceLocator.Instance.CountryService;
            _cityService = ServiceLocator.Instance.CityService;
            _city = city;
            this.cityNameTextbox.Text = city.CityName;
         
        }

        private void PopulateCountries()
        {
            try
            {
                List<CountryReadDTO> countries = _countryService.GetAllCountries();
                countryComboBox.DataSource = countries;
                countryComboBox.DisplayMember = "CountryName";
                countryComboBox.ValueMember = "CountryId";
            }catch(Exception ex)
            {

                string innerExMessage = "";

                if (ex.InnerException != null)
                {
                    innerExMessage = $"Inner Exception {ex.InnerException.Message}";
                }

                Messages.ShowError("Error Getting Cities", $"{innerExMessage} - Exception {ex.Message}");
            }
        }

        private void editCountryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.countryComboBox.Enabled = true;
        }

        private void cancelEditCityButton_Click(object sender, EventArgs e)
        {
            
        }

        private void saveEditCityButton_Click(object sender, EventArgs e)
        {

        }
    }
}
