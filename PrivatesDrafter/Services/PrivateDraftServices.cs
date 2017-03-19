using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatesDrafter.Services
{
    /// <summary>
    /// Service layer for the privates drafting
    /// </summary>
    public class PrivateDraftServices
    {
        #region Big Steps

        /// <summary>
        /// This sets up the game.
        /// 
        /// Begins by picking th enumber of players then figures out which privates
        /// are taken out (if any) automatically
        /// </summary>
        /// <param name="availablePrivates">The queue that gets populated for the available privates</param>
        public void SetupGame(Queue<int> availablePrivates)
        {
            // local var
            Random useMeRandomly = new Random();
            List<int> queueListItems = new List<int>();

            // get players
            int numberOfPlayers = getNumberOfPlayers();

            // figure out what we do based on number of players
            CalculatePrivates(useMeRandomly, queueListItems, numberOfPlayers);

            // figure out which company is taken out
            RailRoads inPlayRailroad = (RailRoads)useMeRandomly.Next(1, 4);

            Console.WriteLine($"Railroad chosen for play: {inPlayRailroad.ToString().Replace('_', ' ')}");

            // add the rest of the privates that dont come out
            for (int I = 7; I <= 13; I++)
                queueListItems.Add(I);

            // randomize the list and add to queue
            Shuffle(queueListItems, useMeRandomly);

            // set queue equal to new randomed list
            availablePrivates = new Queue<int>(queueListItems);
        }
        #endregion

        #region Smaller Steps

        /// <summary>
        /// Calculates the orange and blue privates based on number of players
        /// </summary>
        /// <param name="useMeRandomly">The random number generator</param>
        /// <param name="queueListItems">The list of items to add to the queue</param>
        /// <param name="numberOfPlayers">The number of players decided by the person who input them</param>
        private static void CalculatePrivates(Random useMeRandomly, List<int> queueListItems, int numberOfPlayers)
        {
            int tempInt;
            switch (numberOfPlayers)
            {
                // do what's needed for 4 players (only take out 1 private of each color)
                case (4):

                    // figure out orage private to taken out
                    tempInt = useMeRandomly.Next(1, 4);

                    // add orange privates to list EXCEPT the one chosen to be taken out
                    queueListItems.AddRange(new List<int> { 1, 2, 3 }.Except(new List<int> { tempInt }));

                    // figure out which blue privates are taken out
                    tempInt = useMeRandomly.Next(4, 7);

                    // add the blue private to a list EXCEPT the one chosen to be taken out
                    queueListItems.AddRange(new List<int> { 4, 5, 6 }.Except(new List<int> { tempInt }));

                    break;
                case (3):

                    // figure out orage private
                    tempInt = useMeRandomly.Next(1, 4);

                    // add orange private to list
                    queueListItems.Add(tempInt);

                    // figure out which blue privates are added 
                    tempInt = useMeRandomly.Next(4, 7);

                    // add the blue private to a list
                    queueListItems.Add(tempInt);

                    break;
                case (5):
                    // add all of the privates for 5 players
                    for (int I = 1; I < 7; I++)
                        queueListItems.Add(I);

                    break;
                default:
                    // throw a new exception since this should never get here
                    throw new Exception("Invalid number of players was received");
            }
        }

        /// <summary>
        /// Gets the number of players and validates that it's no more than 5 players and no less than 3
        /// </summary>
        /// <returns>Number of players</returns>
        private int getNumberOfPlayers()
        {
            // verify that it's both a number and at least 3 and no more than 5 players
            int numberOfPlayers;
            while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || (numberOfPlayers < 3 || numberOfPlayers > 5))
                Console.WriteLine("Please enter an appropriate number of players");

            return numberOfPlayers;
        }

        #endregion

        #region Helpers
        /// <summary>
        /// shufflez.  taken from: http://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        #endregion
    }
}
