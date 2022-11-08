using _02_WpfApp.Models;
using _02_WpfApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ContactTypeService _contactTypeService;
        private readonly ContactService _contactService;

        public MainWindow(ContactTypeService contactTypeService, ContactService contactService)
        {
            InitializeComponent();
            _contactTypeService = contactTypeService;
            PopulateContactTypes().ConfigureAwait(false);
            _contactService = contactService;
        }

        public async Task PopulateContactTypes()
        {
            var collection = new ObservableCollection<KeyValuePair<string,int>>();
            foreach(var item in await _contactTypeService.GetAllAsync())
                collection.Add(new KeyValuePair<string, int>(item.ContactType, item.Id));

            cb_contactTypes.ItemsSource = collection;
        }

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            var contactType = (KeyValuePair<string, int>)cb_contactTypes.SelectedItem;
            var value = contactType.Value;

        }

        private async void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var contactType = (KeyValuePair<string, int>)cb_contactTypes.SelectedItem;
                var key = contactType.Key;

                var contactRequest = new ContactRequest
                {
                    ContactType = key,
                    FirstName = tb_firstName.Text,
                    LastName = tb_lastName.Text,
                    Email = tb_email.Text,
                    PhoneNumber = tb_phoneNumber.Text,
                    StreetName = tb_streetName.Text,
                    PostalCode = tb_postalCode.Text,
                    City = tb_city.Text
                };

                var result = await _contactService.CreateAsync(contactRequest);
                if (result is OkResult)
                {
                    cb_contactTypes.SelectedIndex = -1;
                    tb_firstName.Text = "";
                    tb_lastName.Text = "";
                    tb_email.Text = "";
                    tb_phoneNumber.Text = "";
                    tb_streetName.Text = "";
                    tb_postalCode.Text = "";
                    tb_city.Text = "";
                }

            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}
