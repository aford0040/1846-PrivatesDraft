using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _1846_Draft_Host.Domain
{
    /// <summary>
    /// Represents a playe rin the drafting process
    /// </summary>
    [DataContract]
    public class Player
    {
        /// <summary>
        /// Name of player
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The privates they've picked
        /// </summary>
        [DataMember]
        public List<string> SelectedPrivates { get; set; }

        /// <summary>
        /// indicates this person is the starter player
        /// </summary>
        [DataMember]
        public bool StarterPlayer { get; set; }

        /// <summary>
        /// The callback channel
        /// </summary>
        public IRegistrationResponse CallbackChannel { get; set; }
    }
}