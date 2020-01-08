using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DataSmart.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            dashboardView.Visibility = Visibility.Visible;
            productView.Visibility = Visibility.Hidden;
            employeeView.Visibility = Visibility.Hidden;
            title.Content = "Tableau de Board";
        }

        private void dashboardView_click(object sender, RoutedEventArgs e)
        {
            if (dashboardView.Visibility != Visibility.Visible)
            {
                dashboardView.Visibility = Visibility.Visible;
                productView.Visibility = Visibility.Hidden; // Make the productView View visible
                employeeView.Visibility = Visibility.Hidden;  // Hide the employeeView view
                title.Content = "Tableau de Board"; // Change the title to the appropriate title
            }
        }

        private void btnProductView_click(object sender, RoutedEventArgs e)
        {
            if (productView.Visibility != Visibility.Visible)
            {
                productView.Visibility = Visibility.Visible; // Make the productView View visible
                employeeView.Visibility = Visibility.Hidden;  // Hide the employeeView view
                dashboardView.Visibility = Visibility.Hidden;
                title.Content = "Produits"; // Change the title to the appropriate title
            }
        }
        private void btnEmployeeView_click(object sender, RoutedEventArgs e)
        {
            if (employeeView.Visibility != Visibility.Visible)
            {
                employeeView.Visibility = Visibility.Visible; // Make the employeeView View visible
                productView.Visibility = Visibility.Hidden; // Hide the productView view
                dashboardView.Visibility = Visibility.Hidden;
                title.Content = "Employés"; // Change the title to the appropriate title
            }
        }


        // Method to drag the window
        public void DragWindow(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Method to drag the window on MouseDown event
            /// </summary>
           
            DragMove();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Method to Maximize or restore the window to the normal state
            /// </summary>
            
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized; // Maximize the window if it is not
                RestoreDown.Kind = PackIconKind.WindowRestore; // Change the icon of the button to restorewindow icon
            }
            else
            if (this.WindowState != WindowState.Normal)
            {
                this.WindowState = WindowState.Normal; // Restore Down the window to the Normal state if it is not 
                RestoreDown.Kind = PackIconKind.WindowMaximize; // Change the icon of the button to Maximize icon
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Method to minimize the window
            /// </summary>
            this.WindowState = WindowState.Minimized;
        }
        private void PowerButton(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Method to Shutdown the application entirely
            /// </summary>
            Application.Current.Shutdown();
        }
    }
}
