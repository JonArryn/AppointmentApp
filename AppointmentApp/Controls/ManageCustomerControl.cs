using AppointmentApp.Constant;
using AppointmentApp.Helper;
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

namespace AppointmentApp.Controls
{
    public partial class ManageCustomerControl : UserControl
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



        public ManageCustomerControl(int? customerId = null)
        {
            InitializeComponent();
            _isInitializing = true;
            _customerService = ServiceLocator.Instance.CustomerService;
            _countryService = ServiceLocator.Instance.CountryService;
            _cityService = ServiceLocator.Instance.CityService;
            if (customerId.HasValue) 
            { 
                _isNewCustomer = false;
                _customer = _customerService.GetById(customerId.Value);
            }
            else
            {
                _isNewCustomer = true;
                _customer = new CustomerFullReadDTO();
            }

            PopulateForm();
            SubscribeToEvents();
            this.customerFormPanel.Dock = DockStyle.Fill;
            this.formErrorListLabel.Visible = false;
            _isInitializing = false;

        }

        private void SubscribeToEvents()
        {
            EventMediator.Instance.Subscribe(COUNTRY_EVENTS.COUNTRY_CREATED, HandleCountryCreated);
            EventMediator.Instance.Subscribe(COUNTRY_EVENTS.COUNTRY_UPDATED, HandleCountryUpdated);
            EventMediator.Instance.Subscribe(CITY_EVENTS.CITY_CREATED, HandleCityCreated);
            EventMediator.Instance.Subscribe(CITY_EVENTS.CITY_UPDATED, HandleCityUpdated);
            EventMediator.Instance.Subscribe(CUSTOMER_EVENTS.CUSTOMER_FORM_INVALID, HandleFormInvalid);
        }



        // INITIALIZERS //

        private void PopulateForm()
        {
            PopulateCountries();

            if (_isNewCustomer == false)
            {
                PopulateCities(_customer.CountryId);
                PopulateCustomerData();


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
            _isInitializing = true;
            this.customerNameTextBox.Text = _customer.CustomerName;
            this.customerPhoneTextBox.Text = _customer.Phone;
            this.addressTextBox.Text = _customer.Address;
            this.address2TextBox.Text = _customer.Address2;
            this.postalCodeTextBox.Text = _customer.PostalCode;
            SetCurrentCountry(_countries.Find(c => c.CountryId == _customer.CountryId));
            SetCurrentCity(_cities.Find(c => c.CityId == _customer.CityId));
            _isInitializing = false;
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
            _isInitializing = true;
            try
            {
                _cities = _cityService.GetCitiesByCountry(countryId);
                cityComboBox.DataSource = _cities;
                this.cityComboBox.DisplayMember = "CityName";
                this.cityComboBox.ValueMember = "CityId";
                this.editCityLabel.Enabled = true;
                if (_cities.Count <= 0)
                {
                    _selectedCity = null;
                    _customer.CityId = -1;
                    this.cityComboBox.SelectedIndex = -1;
                    this.cityComboBox.DisplayMember = "";
                    this.cityComboBox.ValueMember = "";
                    this.editCityLabel.Enabled = false;
                }

            }
            catch (Exception ex)
            {

                Messages.ShowError("Error Getting Cities",ex.Message);
               
            }
            _isInitializing = false;
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

        private void SetCurrentCity(CityReadDTO city = null)
        {
            if(city == null)
            {
                _selectedCity = null; ;
                _customer.CityId = -1;
            }
            else
            {
                this.cityComboBox.SelectedValue = city.CityId;
                _selectedCity = city;
                _customer.CityId = city.CityId;
            }

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
            SetCurrentCountry(_countries.Find(c => c.CountryId == city.CountryId));
            SetCurrentCity(city);

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

        private void HandleFormInvalid(object data)
        {
            var errors = (List<string>)data;

            this.formErrorListLabel.Visible = true;
            this.formErrorListLabel.Text = string.Join("\n", errors);
        }

        private void cityComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing == false)
            {
                _selectedCity = (CityReadDTO)cityComboBox.SelectedItem;
                _customer.CityId = _selectedCity.CityId;
            }
        }

        private void countryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_isInitializing == false)
            {
                _selectedCountry = (CountryReadDTO)countryComboBox.SelectedItem;
                _customer.CountryId = _selectedCountry.CountryId;
                PopulateCities(_selectedCountry.CountryId);
                SetCurrentCity((CityReadDTO)this.cityComboBox.SelectedItem);
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
                CustomerCreateDTO customer = new CustomerCreateDTO
                {
                    CustomerName = _customer.CustomerName,
                    Address = _customer.Address,
                    Address2 = _customer.Address2 ?? string.Empty,
                    CityId = _customer.CityId,
                    PostalCode = _customer.PostalCode,
                    Phone = _customer.Phone
                };
                int errorCount = ValidateForm(customer);
                if (errorCount > 0)
                {
                    return;
                }
                if (_isNewCustomer)
                {
                   
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
                    CustomerUpdateDTO updateCustomer = new CustomerUpdateDTO
                    {
                        CustomerId = _customer.CustomerId,
                        CustomerName = _customer.CustomerName,
                        AddressId = _customer.AddressId,
                        Address = _customer.Address,
                        Address2 = _customer.Address2 ?? string.Empty,
                        CityId = _customer.CityId,
                        PostalCode = _customer.PostalCode,
                        Phone = _customer.Phone

                    };
                    bool customerUpdated = _customerService.UpdateCustomerAndAddress(updateCustomer);
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

        private void cancelUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            EventMediator.Instance.Publish(CUSTOMER_EVENTS.CANCEL_MANAGE_CUSTOMER);
        }

        // HELPERS //

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


    }
}
