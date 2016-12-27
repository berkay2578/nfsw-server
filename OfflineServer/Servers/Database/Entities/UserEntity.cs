using System;

namespace OfflineServer.Servers.Database.Entities
{
    public class UserEntity
    {
        public virtual Int32 id { get; protected set; }
        public virtual Int32 defaultPersonaIdx { get; set; }
    }
}