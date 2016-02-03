using System;
using System.ComponentModel;
using System.Windows;

namespace OfflineServer
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class StringData : Attribute
    {
        public string sValue { get; set; }
        public StringData(String StringEquilaventEntry)
        {
            sValue = StringEquilaventEntry;
        }
    }
    public static class GiffInfo
    {
        public static string GetString(this Enum EnumEntry)
        {
            StringData[] sdDelegate = (StringData[])(EnumEntry.GetType().GetField(EnumEntry.ToString())).GetCustomAttributes(typeof(StringData), false);
            return sdDelegate[0].sValue == null ? String.Empty : sdDelegate[0].sValue;
        }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}