using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DigiClock.Commands {
    public static class SettingsWindowCommands {
        private static RoutedUICommand _apply = new RoutedUICommand(
            text: "Apply",
            name: "ApplyCmd",
            ownerType: typeof(SettingsWindowCommands));

        public static RoutedUICommand Apply => _apply;
    }
}
