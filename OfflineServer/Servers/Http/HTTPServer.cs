using NHttp;
using OfflineServer.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;

namespace OfflineServer.Servers.Http
{
    public class HttpServer
    {
        // for easy development and debug, will be removed later when everything is coded
        private List<String> supportedMethods = new List<string>() {
            /* Catalog */ "categories", "productsInCategory",
            /* DriverPersona */ "createPersona", "deletePersona", "getExpLevelPointsMap", "getPersonaInfo", "getPersonaBaseFromList", "reserveName", "updateStatusMessage",
            /* Matchmaking */ "launchevent",
            /* Personas */ "baskets", "carslots", "commerce", "defaultcar",
            /* Powerups */ "activated", "getrebroadcasters", "getregioninfo", "loginAnnouncements",
            /* Root */ "carclasses", "systeminfo",
            /* Session */ "getChatInfo",
            /* User */ "getPermanentSession", "secureLoginPersona", "secureLogoutPersona"
        };
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public NHttp.HttpServer nServer = new NHttp.HttpServer();
        public Int32 port;
        public HttpRequest request;
        public HttpServer()
        {
            nServer.RequestReceived += nServer_RequestReceived;
            nServer.Start();
            port = nServer.EndPoint.Port;
            log.InfoFormat("Successfully setup HttpServer on port {0}.", port);
        }

        private void nServer_RequestReceived(object sender, HttpRequestEventArgs e)
        {
            e.Response.Headers.Add("Connection", "close");
            e.Response.Headers.Add("Content-Encoding", "gzip");
            e.Response.Headers.Add("Content-Type", "application/xml;charset=utf-8");
            e.Response.Headers.Add("Status-Code", "200");

            log.InfoFormat("Received Http-{0} request from {1}.", e.Request.HttpMethod, e.Request.RawUrl);

            Byte[] baResponseArray = null;
            List<String> splittedPath = new List<String>(e.Request.Path.Split('/'));

            String ioPath = Path.Combine(DataEx.dir_ServerFilesFallback, e.Request.Path.Substring(1) + ".xml");

            if (splittedPath.Count >= 3)
            {
                String targetClassString = changeCaseFirst(splittedPath[2], true);
                if (splittedPath.Count == 3)
                {
                    splittedPath.Insert(0, "");
                    targetClassString = "Root";
                }
                Double dummy;
                Boolean isNumber = Double.TryParse(splittedPath[3], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out dummy);
                String targetMethodString = changeCaseFirst(isNumber ? splittedPath[4] : splittedPath[3], false);
                if (supportedMethods.Contains(targetMethodString))
                {
                    Type targetClass = Type.GetType("OfflineServer.Servers.Http.Classes." + targetClassString);
                    MethodInfo targetMethod = targetClass.GetMethod(targetMethodString);
                    request = e.Request;
                    log.InfoFormat("Processing OfflineServer.HttpServer.Classes.{0}.{1}().", targetClassString, targetMethodString);
                    baResponseArray = getResponseData((string)targetMethod.Invoke(null, null));
                }
                else
                {
                    log.WarnFormat("Method for {0} wasn't found, using fallback XML method.", targetMethodString);
                    if (File.Exists(ioPath))
                    {
                        log.InfoFormat("Reading XML file {0}.", ioPath);
                        baResponseArray = getResponseData(File.ReadAllText(ioPath, Encoding.UTF8));
                    }
                    else
                    {
                        log.WarnFormat("File {0} wasn't found, sending only 200OK.", ioPath);
                    }
                }
            }
            else
            {
                if (File.Exists(ioPath))
                {
                    log.InfoFormat("Reading XML file {0}.", ioPath);
                    baResponseArray = getResponseData(File.ReadAllText(ioPath, Encoding.UTF8));
                }
                else
                {
                    log.WarnFormat("File {0} wasn't found, sending only 200OK.", ioPath);
                }
            }

            if (baResponseArray == null) baResponseArray = getResponseData("");
            e.Response.OutputStream.Write(baResponseArray, 0, baResponseArray.Length);
            e.Response.OutputStream.Flush();

            // e.Request.RequestType gives the method used, GET - POST - PUSH etc.
            // e.Request.Url gives the full Uri including EVERYTHING
            // e.Request.RawUrl gives the Path following the IP. EX: if 127.0.0.1:4444/test/path.xml?test=true then /test/path.xml?test=true
            // e.Request.Path gives only the Path, not adding the params at the end. EX: if 127.0.0.1:4444/test/path.xml?test=true then /test/path.xml
            // e.Request.Params gives only the Params, not adding anything else.
        }

        private Byte[] getResponseData(String responseText)
        {
            log.DebugFormat("responseText: {0}", responseText);
            using (MemoryStream msResponse = new MemoryStream())
            {
                Byte[] baAnswerData = Encoding.UTF8.GetBytes(responseText);
                using (GZipStream gzip = new GZipStream(msResponse, CompressionMode.Compress, true))
                    gzip.Write(baAnswerData, 0, baAnswerData.Length);

                return msResponse.ToArray();
            }
        }

        private string changeCaseFirst(String input, Boolean upperCase)
        {
            char[] cArray = input.ToCharArray();
            cArray[0] = upperCase ? char.ToUpper(cArray[0]) : char.ToLower(cArray[0]);
            return new string(cArray);
        }

        public String getPostData()
        {
            using (StreamReader reader = new StreamReader(request.InputStream))
                return reader.ReadToEnd();
        }
    }
}