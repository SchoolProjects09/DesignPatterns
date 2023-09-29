using SunriseSunsetLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SunriseSunsetWPF
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyProperty([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private MainModel model = new MainModel();
        public ICommand CalcualteCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public void DoCalcualte()
        {
            SunriseSunsetResults results = model.GetData(Latitude, Longitude, Date);

            Sunrise = results.sunrise.ToString();
            Sunset = results.sunset.ToString();
            Solar_noon = results.solar_noon.ToString();

            TimeSpan dayLength = new TimeSpan(0, 0, results.day_length);
            Day_length = dayLength.ToString();

            Civil_twilight_begin = results.civil_twilight_begin.ToString();
            Civil_twilight_end = results.civil_twilight_end.ToString();
            Nautical_twilight_begin = results.nautical_twilight_begin.ToString();
            Nautical_twilight_end = results.nautical_twilight_end.ToString();
            Astronomical_twilight_begin = results.astronomical_twilight_begin.ToString();
            Astronomical_twilight_end = results.astronomical_twilight_end.ToString();
        }

        public void DoSave()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Sunrise: " + sunrise);
            sb.AppendLine("Sunset: " + sunset);
            sb.AppendLine("Solar Noon: " + solar_noon);
            sb.AppendLine("Day Length: " + day_length);
            sb.AppendLine("Civil Twilight Begins: " + civil_twilight_begin);
            sb.AppendLine("Civil Twilight Ends: " + civil_twilight_end);
            sb.AppendLine("Nautical Twilight Starts: " + nautical_twilight_begin);
            sb.AppendLine("Nautical Twilight Ends: " + nautical_twilight_end);
            sb.AppendLine("Astronomical Twilight Begins: " + astronomical_twilight_begin);
            sb.AppendLine("Astronomical Twilight Ends: " + astronomical_twilight_end);

            File.WriteAllText("Output.txt", sb.ToString());
        }

        #region Properties
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }

        private string sunrise;
        public string Sunrise
        {
            get { return sunrise; }
            set { sunrise = value; NotifyProperty(); }
        }
        private string sunset;
        public string Sunset
        {
            get { return sunset; }
            set { sunset = value; NotifyProperty(); }
        }
        private string solar_noon;
        public string Solar_noon
        {
            get { return solar_noon; }
            set { solar_noon = value; NotifyProperty(); }
        }
        private string day_length;
        public string Day_length
        {
            get { return day_length; }
            set { day_length = value; NotifyProperty(); }
        }
        private string civil_twilight_begin;
        public string Civil_twilight_begin
        {
            get { return civil_twilight_begin; }
            set { civil_twilight_begin = value; NotifyProperty(); }
        }
        private string civil_twilight_end;
        public string Civil_twilight_end
        {
            get { return civil_twilight_end; }
            set { civil_twilight_end = value; NotifyProperty(); }
        }
        private string nautical_twilight_begin;
        public string Nautical_twilight_begin
        {
            get { return nautical_twilight_begin; }
            set { nautical_twilight_begin = value; NotifyProperty(); }
        }
        private string nautical_twilight_end;
        public string Nautical_twilight_end
        {
            get { return nautical_twilight_end; }
            set { nautical_twilight_end = value; NotifyProperty(); }
        }
        private string astronomical_twilight_begin;
        public string Astronomical_twilight_begin
        {
            get { return astronomical_twilight_begin; }
            set { astronomical_twilight_begin = value; NotifyProperty(); }
        }
        private string astronomical_twilight_end;
        public string Astronomical_twilight_end
        {
            get { return astronomical_twilight_end; }
            set { astronomical_twilight_end = value; NotifyProperty(); }
        }
        #endregion

        public MainVM()
        {
            Latitude = 45.321627;
            Longitude = -122.766609;
            Date = new DateTime(2020, 11, 7);

            CalcualteCommand = new RelayCommand(DoCalcualte);
            SaveCommand = new RelayCommand(DoSave);
        }

    }
}
