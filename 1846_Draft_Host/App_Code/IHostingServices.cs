using _1846_Draft_Host.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _1846_Draft_Host
{

    /// <summary>
    /// Registers a new player with the client
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IRegistrationResponse))]
    public interface IRegistration
    {
        /// <summary>
        /// Registers a player to the game
        /// </summary>
        /// <param name="newPlayer"></param>
        [OperationContract]
        void RegisterPlayer(Player newPlayer);

        [OperationContract]
        void StartGame();
    }

    /// <summary>
    /// Displays the message to the console
    /// </summary>
    public interface IRegistrationResponse
    {
        [OperationContract(IsOneWay = true)]
        void DisplayServerMessage(string message);
    }
    /*
    [ServiceContract]
    public interface IServices
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    */
}
