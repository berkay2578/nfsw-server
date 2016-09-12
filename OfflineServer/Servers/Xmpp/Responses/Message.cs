using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    [XmlRoot("message")]
    public class Message
    {
        [XmlAttribute("from")]
        public String from;
        [XmlAttribute("id")]
        public String id = "JN_123456";
        [XmlAttribute("to")]
        public String to;
        [XmlElement("body")]
        public String body;
        [XmlElement("subject")]
        public Int64 subject;

        public void setBody<T>(T obj)
        {
            String plainMessage = obj.SerializeObject(true);
            body = plainMessage;
            from = String.Format("{0}.engine.engine@127.0.0.1/EA_Chat", Access.sXmpp.jidPrepender);
            to = String.Format("{0}.{1}@127.0.0.1", Access.sXmpp.jidPrepender, Access.CurrentSession.ActivePersona.Id);
            subject = Access.sXmpp.calculateHash(to.ToCharArray(), plainMessage.ToCharArray());
        }
    }
}