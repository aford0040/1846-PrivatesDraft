using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using _1846_Draft_Host.Domain;
using _1846_Draft_Host.Services;

namespace _1846_Draft_Host
{
    /// <summary>
    /// The service that handles registration
    /// </summary>
    public class RegistrationService : IRegistration
    {
        /// <summary>
        /// Registers a player for the game
        /// </summary>
        /// <param name="newPlayer"></param>
        public void RegisterPlayer(Player newPlayer)
        {
            // get the player's callback channel
            newPlayer.CallbackChannel = OperationContext.Current.GetCallbackChannel<IRegistrationResponse>();

            // lock it so 2 threads dont get to it at once
            lock(RegistrationServices.RegisteredPlayers)
                RegistrationServices.RegisteredPlayers.Add(newPlayer);

            // notify the other players of the player's arrival
            foreach (Player existingPlayer in RegistrationServices.RegisteredPlayers.Where(m => m.Name != newPlayer.Name))
                try
                {
                    // attempt to send the message
                    existingPlayer.CallbackChannel.DisplayServerMessage($"{newPlayer.Name} has joined the game!");
                }
                catch
                {
                    // remove this player since somethin's wrong
                    Player removeMe = RegistrationServices.RegisteredPlayers.Where(m => m.Name == existingPlayer.Name).FirstOrDefault();

                    // if it isnt null, remove em
                    if (removeMe != null)
                        RegistrationServices.RegisteredPlayers.Remove(removeMe);
                }
        }

        /// <summary>
        /// Begins the drafting 
        /// </summary>
        public void StartGame()
        {

        }
    }
}
