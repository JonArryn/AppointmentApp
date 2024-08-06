using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.Dialogs;
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

// TODO: Need to disable country because the country is directly related to the city - users shouldn't be able to indvidually change both city and country

namespace AppointmentApp.Controls
{
    public partial class CustomerFormControl : UserControl
    {
        CustomerUpdateDTO _customer;

        CountryService _countryService;
        CityService _cityService;
        CustomerService _customerService;

        CityReadDTO _selectedCity;
        CountryReadDTO _selectedCountry;
        ManageCityControl _manageCityControl;



        public CustomerFormControl(CustomerUpdateDTO customer = null)
        {
            InitializeComponent();

            _customer = customer;
            _customerService = ServiceLocator.Instance.CustomerService;
            _countryService = ServiceLocator.Instance.CountryService;
            _cityService = ServiceLocator.Instance.CityService;
            PopulateForm();


        }

        private void PopulateForm()
        {
            PopulateCities();
            _selectedCity = (CityReadDTO)cityComboBox.SelectedItem;
            PopulateCountries();
            _selectedCountry = (CountryReadDTO)countryComboBox.SelectedItem;
            PopulateCustomerData();
        }



        private void PopulateCustomerData()
        {
            this.customerNameTextBox.Text = _customer.CustomerName;
            this.customerPhoneTextBox.Text = _customer.Phone;
            this.addressTextBox.Text = _customer.Address;
            this.address2TextBox.Text = _customer.Address2;
            this.postalCodeTextBox.Text = _customer.PostalCode;
            this.cityComboBox.SelectedValue = _customer.CityId;
            this.countryComboBox.SelectedValue = _customer.CountryId;
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


        private void editCityLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCityControl = new ManageCityControl(_selectedCity.CityId);
            _manageCityControl.CityUpdated += ManageCityControl_CityUpdated;
            ManageEntityDialog dialog = new ManageEntityDialog("Edit City", _manageCityControl);
            dialog.ShowDialog();
        }

        private void ManageCityControl_CityUpdated(object sender, EventArgs e)
        {
            CustomerUpdateDTO customer = _customerService.GetById(_customer.CustomerId);
            if(_customer == null)
            {
                Messages.ShowError("Refresh Customer Error", "The customer was not found by the provided ID");
                return;
            }
            _customer = customer;
            PopulateForm();
        }

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
  
         
                _selectedCity = (CityReadDTO)cityComboBox.SelectedItem;  
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                _selectedCountry = (CountryReadDTO)countryComboBox.SelectedItem;
         
        }

        private void newCityLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCityControl = new ManageCityControl();
            _manageCityControl.CityUpdated += ManageCityControl_CityUpdated;
            ManageEntityDialog dialog = new ManageEntityDialog("New City", _manageCityControl);
            dialog.Show();
        }
    }
}
