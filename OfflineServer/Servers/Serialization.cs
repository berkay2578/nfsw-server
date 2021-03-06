﻿using OfflineServer.Data;
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

                using (StringWriter stringWriter = new StringWriter())
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = false, OmitXmlDeclaration = true }))
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
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                log.Error("An exception occured while serializing the following object: " + obj.GetType().AssemblyQualifiedName, ex);
                MessageBox.Show("Please look at " + DataEx.log_Events + " for more information.", "An exception occured!",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
            return "";
        }
        public static T DeserializeObject<T>(this String plainXml)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                using (StringReader stringReader = new StringReader(plainXml))
                using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings()))
                {
                    T obj = default(T);
                    obj = (T)xmlSerializer.Deserialize(xmlReader);
                    return obj;
                }
            }
            catch (Exception ex)
            {
                log.Error("An exception occured while deserializing the following xml: " + plainXml, ex);
                MessageBox.Show("Please look at " + DataEx.log_Events + " for more information.", "An exception occured!",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
            return default(T);
        }
    }
}