using DigiClock.Infrastructure;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;

namespace DigiClock.Model {
    public class Settings {
        public const string SETTINGS_FILENAME = "settings.json";

        public bool Use24H { get; set; }
        public bool ShowSeconds { get; set; }
        public bool ShowDate { get; set; }
        public bool BlinkingDots { get; set; }
        public Color Color { get; set; }
        public Color  BgColor { get; set; }

        public bool ShowOnTop { get; set; }

        public Point LastPosition { get; set; }

        public Settings() {
            LastPosition = new Point(50, 70);
            Use24H = true;
            ShowSeconds = false;
            ShowDate = false;
            BlinkingDots = true;
            Color = Colors.Black;
            BgColor = Colors.LightGray;

            ShowOnTop = false;
        }

        private static string getSettingsFilePath() {
            string settingsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                AboutData.AppTitle);
            if (!Directory.Exists(settingsFolder)) Directory.CreateDirectory(settingsFolder);
            
            return Path.Combine(settingsFolder, SETTINGS_FILENAME);
        }

        private static JsonSerializerOptions serializerOptions = new JsonSerializerOptions() {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public void Save() {
            string jsonString = JsonSerializer.Serialize<Settings>(this, serializerOptions);

            File.WriteAllText(getSettingsFilePath(), jsonString);
        }

        public static Settings Load() {
            string settingsFile = getSettingsFilePath();
            if(File.Exists(settingsFile)) {
                string settingsContent = File.ReadAllText(settingsFile);
                try {
                    return JsonSerializer.Deserialize<Settings>(settingsContent, serializerOptions);
                } catch(Exception e) {
                    System.Diagnostics.Debug.Print(e.Message);
                    File.Delete(settingsFile);
                    return new Settings();
                }
            } else {
                return new Settings();
            }
        }
    }
}
