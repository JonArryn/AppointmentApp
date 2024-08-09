using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.Dialogs;
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

// TODO: Something weird is happening again with city and country population upon update customer
// TODO: The customer's name is not being updated
// TODO: Need to confirm customer save with a dialog and navigate back to Customers. (Event

namespace AppointmentApp.Controls
{
    public partial class CustomerFormControl : UserControl
    {
        private bool _isNewCustomer;
        private bool _isInitializing;

        CustomerFullReadDTO _customer;
        List<CityReadDTO> _cities;
        List<CountryReadDTO> _countries;

        CountryService _countryService;
        CityService _cityService;
        CustomerService _customerService;

        CityReadDTO _selectedCity;
        CountryReadDTO _selectedCountry;

        ManageCityControl _manageCityControl;
        ManageCountryControl _manageCountryControl;



        public CustomerFormControl(CustomerFullReadDTO customer = null)
        {
            InitializeComponent();
            _isInitializing = true;
            _customer = customer;
            _isNewCustomer = customer == null;
            _customerService = ServiceLocator.Instance.CustomerService;
            _countryService = ServiceLocator.Instance.CountryService;
            _cityService = ServiceLocator.Instance.CityService;
            PopulateForm();
            SubscribeToEvents();
            _isInitializing = false;

        }

        private void SubscribeToEvents()
        {
            EventMediator.Instance.Subscribe(COUNTRY_EVENTS.COUNTRY_CREATED, HandleCountryCreated);
            EventMediator.Instance.Subscribe(COUNTRY_EVENTS.COUNTRY_UPDATED, HandleCountryUpdated);
            EventMediator.Instance.Subscribe(CITY_EVENTS.CITY_CREATED, HandleCityCreated);
            EventMediator.Instance.Subscribe(CITY_EVENTS.CITY_UPDATED, HandleCityUpdated);
        }

        private int ValidateForm(CustomerCreateDTO customer)
        {
            CustomerFormValidator validator = new CustomerFormValidator(customer);
            List<string> errors = validator.ValidateCustomerForm();

            if (errors.Count > 0)
            {
                EventMediator.Instance.Publish(CUSTOMER_EVENTS.CUSTOMER_FORM_INVALID, errors);
                
            }
            return errors.Count;
        }

        // INITIALIZERS //

        private void PopulateForm()
        {
            PopulateCountries();

            if (_isNewCustomer == false)
            {
                PopulateCities(_customer.CountryId);
                PopulateCustomerData();
                SetCurrentCountry(_countries.Find(c => c.CountryId == _customer.CountryId));
                SetCurrentCity(_cities.Find(c => c.CityId == _customer.CityId));

            }
            else
            {
                _customer = new CustomerFullReadDTO();
                SetCurrentCountry(_countries[0]);
                PopulateCities(_selectedCountry.CountryId);
                SetCurrentCity(_cities[0]);
            }
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
                _countries = _countryService.GetAllCountries();
                countryComboBox.DataSource = _countries;
                countryComboBox.DisplayMember = "CountryName";
                countryComboBox.ValueMember = "CountryId";
            }
            catch(Exception ex)
            {
                Messages.ShowError("Error Getting Countries", ex.Message);
            }

        }

        private void PopulateCities(int countryId)
        {
            try
            {
                _cities = _cityService.GetCitiesByCountry(countryId);
                cityComboBox.DataSource = _cities;
                this.cityComboBox.DisplayMember = "CityName";
                this.cityComboBox.ValueMember = "CityId";
                if (_cities.Count <= 0)
                {
                    _selectedCity = null;
                    _customer.CityId = -1;
                    this.cityComboBox.SelectedIndex = -1;
                    this.cityComboBox.DisplayMember = "";
                    this.cityComboBox.ValueMember = "";
                }

            }
            catch (Exception ex)
            {

                Messages.ShowError("Error Getting Cities",ex.Message);
               
            }
        }

        private void RefreshCustomer()
        {
            CustomerFullReadDTO customer = _customerService.GetById(_customer.CustomerId);
            if (_customer == null)
            {
                Messages.ShowError("Refresh Customer Error", "The customer was not found by the provided ID");
                return;
            }
            _customer = customer;
            PopulateForm();
        }

        private void SetCurrentCity(CityReadDTO city)
        {
            this.cityComboBox.SelectedValue = city.CityId;
            _selectedCity = city;
            _customer.CityId = city.CityId;
        }

        private void SetCurrentCountry(CountryReadDTO country)
        {
            this.countryComboBox.SelectedValue = country.CountryId;
            _selectedCountry = country;
            _customer.CountryId = country.CountryId;
        }

        // EVENT MEDIATOR HANDLERS //

        private void HandleCountryUpdated(object data = null)
        {
            _isInitializing = true;
            PopulateCountries();
            this.countryComboBox.SelectedValue = _selectedCountry.CountryId;
            _isInitializing = false;
        }

        private void HandleCityUpdated(object data = null)
        {
            _isInitializing = true;
            PopulateCities(_selectedCountry.CountryId);
            this.cityComboBox.SelectedValue = _selectedCity.CityId;
            _isInitializing = false;
        }

        private void HandleCityCreated(object data)
        {
            var city = data as CityReadDTO;

            if (_isNewCustomer == false)
            {
                RefreshCustomer();
            }
            else
            {
                PopulateCities(_selectedCountry.CountryId);
            }
            SetCurrentCity(city);
            SetCurrentCountry(_countries.Find(c => c.CountryId == city.CountryId));

        }
        private void HandleCountryCreated(object data)
        {
            var country = data as CountryReadDTO;

            PopulateCountries();
            PopulateCities(country.CountryId);
            this.cityComboBox.DataSource = null;
            this.cityComboBox.Refresh();
            SetCurrentCountry(country);

        }

        // EVENT SUBSCRIPTION HANDLERS //



        // COMBO BOX EVENT HANDLERS //
        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_isInitializing == false)
            {
                _selectedCity = (CityReadDTO)cityComboBox.SelectedItem;
            }

        }

        private void countryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing == false)
            {
                _selectedCountry = (CountryReadDTO)countryComboBox.SelectedItem;
                PopulateCities(_selectedCountry.CountryId);
            }
        }

        // LINK LABEL EVENT HANDLERS //
        private void editCityLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCityControl = new ManageCityControl(_selectedCountry.CountryId, _selectedCity.CityId);
            ManageEntityDialog dialog = new ManageEntityDialog("Edit City", _manageCityControl);
            dialog.ShowDialog();
        }


        private void newCountryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCountryControl = new ManageCountryControl();
            ManageEntityDialog dialog = new ManageEntityDialog("New Country", _manageCountryControl);
            dialog.Show();
        }

        private void newCityLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCityControl = new ManageCityControl(_selectedCountry.CountryId);
            ManageEntityDialog dialog = new ManageEntityDialog("New City", _manageCityControl);
            dialog.Show();
        }

        private void editCountryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCountryControl = new ManageCountryControl(_selectedCountry.CountryId);
            ManageEntityDialog dialog = new ManageEntityDialog("Edit Country", _manageCountryControl);
            dialog.ShowDialog();
        }

        // BUTTON EVENT HANDLERS //

        private void cancelSaveCustomerButton_Click(object sender, EventArgs e)
        {
                EventMediator.Instance.Publish(CUSTOMER_EVENTS.CANCEL_MANAGE_CUSTOMER);
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {

            try
            {
                
                if(_isNewCustomer)
                {
                    CustomerCreateDTO customer = new CustomerCreateDTO
                    {
                        CustomerName = _customer.CustomerName,
                        Address = _customer.Address,
                        Address2 = _customer.Address2,
                        CityId = _customer.CityId,
                        PostalCode = _customer.PostalCode,
                        Phone = _customer.Phone
                    };
                    int errorCount = ValidateForm(customer);
                    if (errorCount > 0)
                    {
                        return;
                    }
                    int newCustomerId = _customerService.CreateCustomer(customer);
                    if (newCustomerId > 0)
                    {
                        EventMediator.Instance.Publish(CUSTOMER_EVENTS.CUSTOMER_CREATED);
                    }
                    else
                    {
                        Messages.ShowError("Error Creating Customer", "There was an error creating the customer");
                    }
                    return;
                }
                else
                {
                    CustomerUpdateDTO customer = new CustomerUpdateDTO
                    {
                        CustomerId = _customer.CustomerId,
                        CustomerName = _customer.CustomerName,
                        AddressId = _customer.AddressId,
                        Address = _customer.Address,
                        Address2 = _customer.Address2,
                        CityId = _customer.CityId,
                        PostalCode = _customer.PostalCode,
                        Phone = _customer.Phone

                    };
                    CustomerCreateDTO baseCustomer = new CustomerCreateDTO
                    {
                        CustomerName = customer.CustomerName,
                        Address = customer.Address,
                        Address2 = customer.Address2,
                        CityId = customer.CityId,
                        PostalCode = customer.PostalCode,
                        Phone = customer.Phone
                    };
                    int errorCount = ValidateForm(baseCustomer);
                    if (errorCount > 0) return;
                    bool customerUpdated = _customerService.UpdateCustomerAndAddress(customer);
                    if (customerUpdated)
                    {
                        EventMediator.Instance.Publish(CUSTOMER_EVENTS.CUSTOMER_UPDATED);
                    }
                    else
                    {
                        Messages.ShowError("Error Updating Customer", "There was an error updating the customer");
                    }
                }

            }catch (Exception ex)
            {

                Messages.ShowError("Error Updating Customer", ex.Message);
            }
            
        }

        // FORM TEXT EVENT HANDLERS //

        private void customerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _customer.CustomerName = this.customerNameTextBox.Text.Trim();
        }

        private void customerPhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            _customer.Phone = this.customerPhoneTextBox.Text.Trim();
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            _customer.Address = this.addressTextBox.Text.Trim();
        }

        private void address2TextBox_TextChanged(object sender, EventArgs e)
        {
            _customer.Address2 = this.address2TextBox.Text.Trim();
        }

        private void postalCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            _customer.PostalCode = this.postalCodeTextBox.Text.Trim();
        }

    }
}
