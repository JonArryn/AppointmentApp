using AppointmentApp.Constant;
using AppointmentApp.Database;
using AppointmentApp.Dialogs;
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

        public event EventHandler CustomerUpdated;
        public event EventHandler CancelUpdateCustomer;
        public event EventHandler<CustomerFormErrorEventArgs> CustomerFormError;



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
            _isInitializing = false;
        }

        private int ValidateForm(CustomerCreateDTO customer)
        {
            CustomerFormValidator validator = new CustomerFormValidator(customer);
            List<string> errors = validator.ValidateCustomerForm();

            if (errors.Count > 0)
            {
                CustomerFormErrorEventArgs errorArgs = new CustomerFormErrorEventArgs(errors);
                CustomerFormError?.Invoke(this, errorArgs);
                
            }
            return errors.Count;
        }

        // INITIALIZERS //

        private void PopulateForm()
        {
            PopulateCountries();

            if (_isNewCustomer == false)
            {
                PopulateCustomerData();
                _selectedCountry = new CountryReadDTO { CountryId = _customer.CountryId, CountryName = _customer.Country };
                PopulateCities(_selectedCountry.CountryId);
                _selectedCity = new CityReadDTO { CityId = _customer.CityId, CityName = _customer.City, CountryId = _customer.CountryId };
            }
            else
            {
                _customer = new CustomerFullReadDTO();
                _selectedCountry = _countries[0];
                this.countryComboBox.SelectedValue = _selectedCountry.CountryId;
                PopulateCities(_selectedCountry.CountryId);
                _selectedCity = _cities[0];
                this.cityComboBox.SelectedValue = _selectedCity.CityId;
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
                else
                {
                    _selectedCity = _cities[0];
                    _customer.CityId = _selectedCity.CityId;
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

        // EVENT SUBSCRIPTION HANDLERS //

        private void ManageCityControl_CityUpdated(object sender, EventArgs e)
        {
            _isInitializing = true;
            PopulateCities(_selectedCountry.CountryId);
            this.cityComboBox.SelectedValue = _selectedCity.CityId;
            _isInitializing = false;
        }



        private void ManageCityControl_CityCreated(object sender, CityEventArgs e)
        {
            if(_isNewCustomer == false)
            {
                RefreshCustomer();
            }
            else
            {
                PopulateCities(_selectedCountry.CountryId);
            }
            this.cityComboBox.SelectedValue = e.City.CityId;
            this.countryComboBox.SelectedValue = e.City.CountryId;

        }

        private void ManageCountryControl_CountryUpdated(object sender, EventArgs e) 
        {
            _isInitializing = true;
            PopulateCountries();
            this.countryComboBox.SelectedValue = _selectedCountry.CountryId;
            _isInitializing = false;
        }

        private void ManageCountryControl_CountryCreated(object sender, CountryEventArgs e)
        {
            _isInitializing = true;
            PopulateCountries();
            PopulateCities(e.Country.CountryId);
            this.cityComboBox.DataSource = null;
            this.cityComboBox.Refresh();
            _selectedCountry = e.Country;
            this.countryComboBox.SelectedValue = e.Country.CountryId;
            _isInitializing = false;
        }

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
            _manageCityControl = new ManageCityControl(_selectedCity.CityId);
            _manageCityControl.CityUpdated += ManageCityControl_CityUpdated;
            ManageEntityDialog dialog = new ManageEntityDialog("Edit City", _manageCityControl);
            dialog.ShowDialog();
        }


        private void newCountryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCountryControl = new ManageCountryControl();
            _manageCountryControl.CountryCreated += ManageCountryControl_CountryCreated;
            ManageEntityDialog dialog = new ManageEntityDialog("New Country", _manageCountryControl);
            dialog.Show();
        }

        private void newCityLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCityControl = new ManageCityControl(_selectedCountry.CountryId);
            _manageCityControl.CityCreated += ManageCityControl_CityCreated;
            ManageEntityDialog dialog = new ManageEntityDialog("New City", _manageCityControl);
            dialog.Show();
        }

        private void editCountryLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _manageCountryControl = new ManageCountryControl(_selectedCountry.CountryId);
            _manageCountryControl.CountryUpdated += ManageCountryControl_CountryUpdated;
            ManageEntityDialog dialog = new ManageEntityDialog("Edit Country", _manageCountryControl);
            dialog.ShowDialog();
        }

        // BUTTON EVENT HANDLERS //

        private void cancelSaveCustomerButton_Click(object sender, EventArgs e)
        {
                CancelUpdateCustomer?.Invoke(this, EventArgs.Empty);
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
                        CustomerUpdated?.Invoke(this, EventArgs.Empty);
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
                        CustomerUpdated?.Invoke(this, EventArgs.Empty);
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
