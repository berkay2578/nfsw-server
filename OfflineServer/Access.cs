using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfflineServer
{
    public class Access : ObservableObject
    {
        public static NfswSession CurrentSession { get; set; } = new NfswSession();
        public static HTTPServer sHttp = new HTTPServer();
    }
}
