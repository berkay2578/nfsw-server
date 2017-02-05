using System;

namespace OfflineServer.Servers.Database.Entities
{
    public class CarEntity
    {
        public virtual Int32 id { get; protected set; }
        public virtual Int64 baseCarId { get; set; }
        public virtual Int64 carClassHash { get; set; }
        public virtual String name { get; set; }
        public virtual String paints { get; set; }
        public virtual String performanceParts { get; set; }
        public virtual Int64 physicsProfileHash { get; set; }
        public virtual Int32 rating { get; set; }
        public virtual Int32 resalePrice { get; set; }
        public virtual String skillModParts { get; set; }
        public virtual String vinyls { get; set; }
        public virtual String visualParts { get; set; }
        public virtual Int16 durability { get; set; }
        public virtual String expirationDate { get; set; }
        public virtual Int16 heatLevel { get; set; }
        public virtual PersonaEntity ownerPersona { get; set; }
    }
}