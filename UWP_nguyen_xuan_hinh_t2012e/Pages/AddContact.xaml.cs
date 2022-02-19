using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_nguyen_xuan_hinh_t2012e.DB;
using UWP_nguyen_xuan_hinh_t2012e.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_nguyen_xuan_hinh_t2012e.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContact : Page
    {
        public AddContact()
        {
            this.InitializeComponent();
        }

        private async void Handle_Create(object sender, RoutedEventArgs e)
        {
            var contacts = new Contact()
            {
                name = Name.Text,
                phoneNumber = PhoneNumber.Text
            };

            var database = new DatabaseMigration();
            var result = database.Save(contacts);
            var dialog = new ContentDialog();
            if (result)
            {
                dialog.Title = "Success";
                dialog.Content = "Insert data success !!";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
            }
            else
            {
                dialog.Title = "Failed";
                dialog.Content = "Insert data failed !!";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
            }
        }
    }
}
