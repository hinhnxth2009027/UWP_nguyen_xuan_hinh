using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ContactMain : Page
    {
        public ContactMain()
        {
            this.InitializeComponent();
        }

        private void nvSample_SelectionChanged(Windows.UI.Xaml.Controls.NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var navigationViewItem = args.SelectedItem as NavigationViewItem;
            switch (navigationViewItem.Tag)
            {
                case "ListContact":
                    this.contentFrame.Navigate(typeof(Pages.ListContact));
                    break;
                case "AddContact":
                    this.contentFrame.Navigate(typeof(Pages.AddContact));
                    break;
                case "SearchContact":
                    this.contentFrame.Navigate(typeof(Pages.SearchContact));
                    break;
            }
        }
    }
}
