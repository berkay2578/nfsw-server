using ICSharpCode.AvalonEdit;
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
    public class MVVMSyntax : TextEditor, INotifyPropertyChanged
    {
        public static readonly DependencyProperty _TextProperty = 
            DependencyProperty.Register("_Text", typeof(String), typeof(MVVMSyntax), new PropertyMetadata(String.Empty, OnMVVMTextChanged));

        private static void OnMVVMTextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (MVVMSyntax)sender;
            if (string.Compare(control._Text, e.NewValue.ToString()) != 0)
            {
                //check for current text, cause it's called EVEN WHEN NOT CHANGED FOR SOME RFAHSFISAPFIKMASMFL REASON
                control._Text = e.NewValue.ToString();
            }
        }

        public string _Text
        {
            get { return Text; }
            set { Text = value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            SetCurrentValue(_TextProperty, Text);
            base.OnTextChanged(e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

    }
}