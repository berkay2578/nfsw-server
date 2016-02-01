using NHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows;

namespace OfflineServer
{
    public class HTTPServer
    {
        public HttpServer nServer = new HttpServer();
        public HTTPServer()
        {
            nServer.RequestReceived += nServer_RequestReceived;
            nServer.Start();

            System.Diagnostics.Process.Start(String.Format("http://{0}/ServerData/test.xml", nServer.EndPoint));
        }

        private string oldPath;
        private void nServer_RequestReceived(object sender, HttpRequestEventArgs e)
        {
            if (e.Request.Path != "/favicon.ico") oldPath = e.Request.Path.Remove(0,1); // because I'm using Chrome for debug ... it will work without it too since it's Async though
            Console.WriteLine(oldPath);

            if (File.Exists(oldPath))
            {
                e.Response.Headers.Add("Connection", "close");
                e.Response.Headers.Add("Content-Encoding", "gzip");
                e.Response.Headers.Add("Content-Type", "application/xml;charset=utf-8");
                e.Response.Headers.Add("Status-Code", "200");

                Byte[] baResponseArray = GetResponseData(oldPath);

                e.Response.OutputStream.Write(baResponseArray, 0, baResponseArray.Length);
                e.Response.OutputStream.Flush();
            }
            
            // e.Request.RequestType gives the method used, GET - POST - PUSH etc.
            // e.Request.Url gives the full Uri including EVERYTHING
            // e.Request.RawUrl gives the Path following the IP. EX: if 127.0.0.1:4444/test/path.xml?test=true then /test/path.xml?test=true
            // e.Request.Path gives only the Path, not adding the params at the end. EX: if 127.0.0.1:4444/test/path.xml?test=true then /test/path.xml
            // e.Request.Parms gives only the Parms, not adding anything else.
        }

        private Byte[] GetResponseData(String StringOrFilePath)
        {
            Byte[] baAnswerData = File.Exists(StringOrFilePath) ? File.ReadAllBytes(StringOrFilePath) : UTF8Encoding.UTF8.GetBytes(StringOrFilePath);

            using (MemoryStream msResponse = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(msResponse, CompressionMode.Compress, true))
                {
                    gzip.Write(baAnswerData, 0, baAnswerData.Length);
                }
                return msResponse.ToArray();
            }
        }
    }
}