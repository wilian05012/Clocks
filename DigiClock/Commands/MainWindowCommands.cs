using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DigiClock.Commands {
    public static class MainWindowCommands {
        private static RoutedUICommand _close = new RoutedUICommand(
            text: "Close",
            name: "CloseCmd",
            ownerType: typeof(MainWindowCommands));

        private static RoutedUICommand _showSettings = new RoutedUICommand(
            text: "Settings",
            name: "ShowSettingsCmd",
            ownerType: typeof(MainWindowCommands));

        private static RoutedUICommand _showAboutBox = new RoutedUICommand(
            text: "Info",
            name: "ShowAboutBoxCmd",
            ownerType: typeof(MainWindowCommands));

        public static RoutedUICommand Close => _close;
        public static RoutedUICommand ShowSettings => _showSettings;
        public static RoutedUICommand ShowAboutBox => _showAboutBox;
    }
}
