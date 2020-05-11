using System;
using System.Collections.Generic;
using System.Text;

using Model=DigiClock.Model;
using DigiClock.Infrastructure;
using System.Windows.Media;

namespace DigiClock.ViewModel {
    public class SettingsVM: PropertyChangedNotifier {
        private Model.Settings _settings;

        public SettingsVM() {
            _settings = Model.Settings.Load();
        }

        #region Wrappers
        public bool Use24H {
            get { return _settings.Use24H; }
            set {
                if(_settings.Use24H != value) {
                    _settings.Use24H = value;
                    NotifyPropertiesChanged(nameof(Use24H));
                }
            }
        }

        public bool ShowSeconds {
            get { return _settings.ShowSeconds; }
            set {
                if(value != _settings.ShowSeconds) {
                    _settings.ShowSeconds = value;
                    NotifyPropertiesChanged(nameof(ShowSeconds));
                }
            }
        }

        public bool ShowDate {
            get { return _settings.ShowDate; }
            set {
                if(_settings.ShowDate != value) {
                    _settings.ShowDate = value;
                    NotifyPropertiesChanged(nameof(ShowDate));
                }
            }
        }

        public bool BlinkingDots {
            get { return _settings.BlinkingDots; }
            set {
                if(_settings.BlinkingDots != value) {
                    _settings.BlinkingDots = value;
                    NotifyPropertiesChanged(nameof(BlinkingDots));
                }
            }
        }

        public Color FgColor { 
            get { return _settings.Color; } 
            set {
                if(_settings.Color != value) {
                    _settings.Color = value;
                    NotifyPropertiesChanged(nameof(FgColor));
                }
            }
        }

        public Color BgColor {
            get { return _settings.BgColor; }
            set {
                if(_settings.BgColor != value) {
                    _settings.BgColor = value;
                    NotifyPropertiesChanged(nameof(BgColor));
                }
            }
        }

        public bool ShowOnTop {
            get { return _settings.ShowOnTop; }
            set {
                if(_settings.ShowOnTop != value) {
                    _settings.ShowOnTop = value;
                    NotifyPropertiesChanged(nameof(ShowOnTop));
                }
            }
        }
        #endregion

        public void Save() { _settings.Save(); }
    }
}
