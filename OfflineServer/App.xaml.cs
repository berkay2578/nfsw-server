using System;
using System.ComponentModel;
using System.Windows;
using System.Xml.Linq;

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
    public static class ExtraFunctions
    {
        public static string GetString(this Enum EnumEntry)
        {
            StringData[] sdDelegate = (StringData[])(EnumEntry.GetType().GetField(EnumEntry.ToString())).GetCustomAttributes(typeof(StringData), false);
            return sdDelegate[0].sValue == null ? String.Empty : sdDelegate[0].sValue;
        }
        public static void SetDefaultXmlNamespace(this XElement xEntry, XNamespace xmlns)
        {
            if (xEntry.Name.NamespaceName == string.Empty)
                xEntry.Name = xmlns + xEntry.Name.LocalName;
            foreach (XElement _xE in xEntry.Elements())
                _xE.SetDefaultXmlNamespace(xmlns);
        }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}