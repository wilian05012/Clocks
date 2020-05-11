using DigiClock.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigiClock {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public new ClockVM DataContext {
            get { return base.DataContext as ClockVM; }
            set { base.DataContext = value; }
        }

        public MainWindow() {
            InitializeComponent();
        }

        ~MainWindow() {
            DataContext.Dispose();
        }

        private void closeCmd_Executed(object sender, ExecutedRoutedEventArgs e) {
            Close();
        }

        private void showSettingsCmd_Executed(object sender, ExecutedRoutedEventArgs e) {
            SettingsWindow settingsWindow = new SettingsWindow();
            if (settingsWindow.ShowDialog() == true) {
                DataContext.ReloadSettings();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
            e.Handled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            DataContext.Settings.LastPosition = new Point(Left, Top);
            DataContext.Settings.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Left = DataContext.Settings.LastPosition.X;
            Top = DataContext.Settings.LastPosition.Y;
            e.Handled = true;
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e) {
            DataContext.IsMouseOver = true;
            e.Handled = true;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e) {
            DataContext.IsMouseOver = false;
            e.Handled = true;
        }

        private void showAboutBoxCmd_Executed(object sender, ExecutedRoutedEventArgs e) {
            AboutWindow aboutBox = new AboutWindow();
            aboutBox.ShowDialog();
            e.Handled = true;
        }
    }
}

