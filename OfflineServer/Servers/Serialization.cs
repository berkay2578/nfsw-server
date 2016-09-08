using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace OfflineServer.Servers
{
    public static class Serialization
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static String SerializeObject<T>(this T obj, Boolean forceNoNamespaces = false)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

                using (StringWriter textWriter = new StringWriter())
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, new XmlWriterSettings { Indent = false, OmitXmlDeclaration = true }))
                {
                    if (forceNoNamespaces)
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");
                        xmlSerializer.Serialize(xmlWriter, obj, ns);
                    }
                    else
                    {
                        xmlSerializer.Serialize(xmlWriter, obj);
                    }
                    return textWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("An exception occured while serializing the following object: " + obj.GetType().AssemblyQualifiedName, ex);
                MessageBox.Show("Please look at Logs\\EventLog.txt for more information.", "An exception occured!", MessageBoxButton.OK, MessageBoxImage.Error);

                log.Info("Shutting down offline server.");

                if (Access.sHttp != null && Access.sXmpp != null)
                {
                    // https://github.com/foxglovesec/Potato/blob/master/source/NHttp/NHttp/HttpServer.cs#L261
                    Access.sHttp.nServer.Stop();
                    Access.sHttp.nServer.Dispose();
                    log.Info("Shutdown of HttpServer has been completed.");

                    Access.sXmpp.shutdown();
                }

                NfswSession.dbConnection.Close();
                NfswSession.dbConnection.Dispose();

                log.Info("Killing main thread.");
                Environment.Exit(0);
            }
            return "";
        }
        public static T DeserializeObject<T>(this String plainXml)
        {
            try
            {
                T obj = default(T);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                
                using (StringReader stringReader = new StringReader(plainXml))
                {
                    obj = (T)xmlSerializer.Deserialize(stringReader);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                log.Error("An exception occured while deserializing the following xml: " + plainXml, ex);
                MessageBox.Show("Please look at Logs\\EventLog.txt for more information.", "An exception occured!", MessageBoxButton.OK, MessageBoxImage.Error);

                log.Info("Shutting down offline server.");

                if (Access.sHttp != null && Access.sXmpp != null)
                {
                    // https://github.com/foxglovesec/Potato/blob/master/source/NHttp/NHttp/HttpServer.cs#L261
                    Access.sHttp.nServer.Stop();
                    Access.sHttp.nServer.Dispose();
                    log.Info("Shutdown of HttpServer has been completed.");

                    Access.sXmpp.shutdown();
                }

                NfswSession.dbConnection.Close();
                NfswSession.dbConnection.Dispose();

                log.Info("Killing main thread.");
                Environment.Exit(0);
            }
            return default(T);
        }
    }
}