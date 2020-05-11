using DigiClock.Infrastructure;
using DigiClock.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DigiClock {
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window {
        public new SettingsVM DataContext {
            get { return base.DataContext as SettingsVM; }
            set { base.DataContext = value; }
        }

        public SettingsWindow() {
            InitializeComponent();
        }

        private void ApplyCmd_Executed(object sender, ExecutedRoutedEventArgs e) {
            try {
                DataContext.Save();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message, AboutData.AppTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DialogResult = true;
            e.Handled = true;
        }
    }
}
