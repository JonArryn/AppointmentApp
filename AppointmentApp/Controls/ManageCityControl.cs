using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.Model;
using AppointmentApp.Service;
using AppointmentApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: need to set up an event for city created so the CustomerFormControl can update the city in its combobox

namespace AppointmentApp.Controls
{
    public partial class ManageCityControl : UserControl
    {
        private readonly bool _isNewCity;
        private readonly bool _isInitializing;
        private readonly CityReadDTO _city;

        private readonly CountryService _countryService;
        private readonly CityService _cityService;


        public event EventHandler CityUpdated;
        public event EventHandler<CityEventArgs> CityCreated;

        public ManageCityControl(int? cityId = null)
        {
            InitializeComponent();
            _isInitializing = true;

            _cityService = ServiceLocator.Instance.CityService;
            _countryService = ServiceLocator.Instance.CountryService;
            PopulateCountries();

            if (cityId.HasValue)
            {
                _city = PopulateCity(cityId.Value);
                this.manageCityTItle.Text = "Edit City";
            }
            else
            {
                _city = new CityReadDTO();
                _city.CountryId = (int)this.countryComboBox.SelectedValue;
                _isNewCity = true;
                this.manageCityTItle.Text = "New City";
                this.countryComboBox.Enabled = true;
                this.editCountryLink.Visible = false;
            }
            _isInitializing = false;
        }

        // INITIALIZERS //
        private CityReadDTO PopulateCity(int cityId)
        {
            CityReadDTO city = _cityService.GetCityById(cityId);
            this.cityNameTextbox.Text = city.CityName;
            this.countryComboBox.SelectedValue = city.CountryId;
           return city;

        }

        private void PopulateCountries()
        {
            try
            {
                countryComboBox.SelectedValueChanged -= countryComboBox_SelectedValueChanged;
                List<CountryReadDTO> countries = _countryService.GetAllCountries();
                countryComboBox.DataSource = countries;
                countryComboBox.DisplayMember = "CountryName";
                countryComboBox.ValueMember = "CountryId";
                countryComboBox.SelectedValueChanged += countryComboBox_SelectedValueChanged;
            }
            catch(Exception ex)
            {

                Messages.ShowError("Error Getting Cities", $"{ex.Message}");
            }
        }

        // EVENTS //

        private void editCountryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.countryComboBox.Enabled = true;
        }

        private void cancelEditCityButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            this.Dispose();
            
        }

        private void saveEditCityButton_Click(object sender, EventArgs e)
        {
            
            if (_isNewCity)
            {
                CityReadDTO city;
                city = _cityService.CreateCity(_city.CityName, _city.CountryId);
                
                if(city != null)
                {
                    CityCreated?.Invoke(this, new CityEventArgs(city));
                }else
                {
                    Messages.ShowError("Error Creating City", "There was an error creating the city");
                    return;
                }
            }
            else
            {
                bool cityUpdated;
                cityUpdated = _cityService.UpdateCity(_city);
                CityUpdated?.Invoke(this, EventArgs.Empty);
                if (!cityUpdated)
                {
                    Messages.ShowError("Error Updating City", "There was an error updating the city");
                    return;
                }
            }

            this.ParentForm.Close();
            this.Dispose();
        }

        private void cityNameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!_isInitializing)
            {
                _city.CityName = cityNameTextbox.Text;
            }
            
        }

        private void countryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_isInitializing)
            {
                _city.CountryId = (int)countryComboBox.SelectedValue;
            }
           
           
        }
    }
}
