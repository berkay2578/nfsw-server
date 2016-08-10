using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Personas
    {
        public static String carslots()
        {
            return Access.CurrentSession.ActivePersona.getCompleteGarage();
        }
    }
}
