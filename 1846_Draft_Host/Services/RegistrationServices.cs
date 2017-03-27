using _1846_Draft_Host.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1846_Draft_Host.Services
{
    public static class RegistrationServices
    {
        /// <summary>
        /// The list of registered players
        /// </summary>
        public static List<Player> RegisteredPlayers { get; set; }
    }
}