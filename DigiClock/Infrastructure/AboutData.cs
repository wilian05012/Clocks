using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DigiClock.Infrastructure {
    public static class AboutData {
        public static string AppTitle => 
            Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;
        public static string Version =>
            Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        public static string Company =>
            Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;
        public static string Author => "William Brito";

    }
}
