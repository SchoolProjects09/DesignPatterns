using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SunriseSunsetWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Uri uri = new Uri("/MainWindow.xaml", UriKind.Relative);

            if (e.Args.Length > 0)
            {
                if (e.Args[0] == "small")
                {
                    uri = new Uri("/SmallWindow.xaml", UriKind.Relative);
                }
            }

            StartupUri = uri;
        }
    }
}
