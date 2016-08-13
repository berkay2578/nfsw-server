using FluentNHibernate.Mapping;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Mappings
{
    public class UserEntityMap : ClassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Table("User");
            Id(u => u.id);
            Map(u => u.defaultPersonaIdx);
        }
    }
}
