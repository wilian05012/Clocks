using DigiClock.Infrastructure;
using DigiClock.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;
using System.Text;
using System.Timers;

namespace DigiClock.ViewModel {
    public class ClockVM: PropertyChangedNotifier, IDisposable {
        public int CurrentHours { get; private set; }
        public string AM_PM { get; private set; }
        public int CurrentMinutes { get; private set; }
        public int CurrentSeconds { get; private set; }
        public string CurrentDate { get; private set; }
        public bool DisplayAmPmIndicator { get; private set; }

        private bool _isMouseOver = false;
        public bool IsMouseOver { 
            get { return _isMouseOver; }
            set {
                if(_isMouseOver != value) {
                    _isMouseOver = value;
                    NotifyPropertiesChanged(nameof(IsMouseOver));
                }
            }
        }

        private Timer _timer = new Timer(interval: 1000);
        private Settings _settings;
        public Settings Settings => _settings;
        public ClockVM() {
            ReloadSettings();

            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
        }

        private void refresh() {
            DateTime now = DateTime.Now;

            CurrentHours = Settings.Use24H ? now.Hour : (now.Hour == 0 ? 12 : now.Hour % 12);
            AM_PM = now.Hour >= 12 ? "PM" : "AM";
            CurrentMinutes = now.Minute;
            CurrentSeconds = now.Second;

            CurrentDate = now.ToString("ddd MMM dd, yyyy");

            NotifyPropertiesChanged(
                nameof(CurrentHours),
                nameof(AM_PM),
                nameof(CurrentMinutes),
                nameof(CurrentSeconds),
                nameof(CurrentDate));
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e) {
            refresh();
        }

        public void ReloadSettings() {
            _settings = Settings.Load();
            DisplayAmPmIndicator = !Settings.Use24H;
            NotifyPropertiesChanged(nameof(Settings), nameof(DisplayAmPmIndicator));
        }

        #region Disposable pattern
        private bool _disposed = false;
        protected virtual void Dispose(bool dispose) {
            if(!_disposed) {
                if(dispose) {
                    _timer.Enabled = false;
                    _timer.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose() {
            Dispose(true);
        }
        #endregion
    }
}
