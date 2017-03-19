using PrivatesDrafter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Privates_Drafter
{
    class Program
    {
        /// <summary>
        /// THe number of players in the game
        /// </summary>
        public int NumberOfPlayers { get; set; }

        /// <summary>
        /// The queue of available privates
        /// </summary>
        public static Queue<int> AvailablePrivates = new Queue<int>();

        static void Main(string[] args)
        {
            // randomize
            SetupGame();

            // do the ui
            while (AvailablePrivates.Count > 0)
            {
                // write out the privates
                Console.WriteLine("Available Privates:");

                // used as the list of privates selection
                List<Privates> privatesSelection = new List<Privates>();

                // spit out 5 privates
                for (int I = 5; I > 0; I--)
                    // make sure there's one available on queue
                    if (AvailablePrivates.Count > 0)
                    {
                        Privates availablePrivate = (Privates)AvailablePrivates.Dequeue();
                        Console.WriteLine(availablePrivate.ToString().Replace('_', ' '));
                        privatesSelection.Add(availablePrivate);
                    }

                // get the selected private
                Console.WriteLine("Select a private:");
                string selectedPrivate = Console.ReadLine().Replace(' ', '_');

                // get the private
                Privates selectPrivate = 0;
                while (selectPrivate == 0)
                    try
                    {
                        // try to convvert
                        selectPrivate = (Privates)Enum.Parse(typeof(Privates), selectedPrivate);
                    }
                    catch
                    {
                        // they input invalid input
                        Console.WriteLine("Invalid private selection. Try again");
                    }

                // remove the selected private from list
                privatesSelection.Remove(selectPrivate);

                // shuffle
                Shuffle(privatesSelection, new Random());

                // add the available private to queue
                foreach (int I in privatesSelection)
                    AvailablePrivates.Enqueue(I);

                // buffer space
                Console.Clear();
            }
        }

        /// <summary>
        /// Time to setup the game
        /// </summary>
        private static void SetupGame()
        {
            // local var
            Random useMeRandomly = new Random();
            List<int> queueListItems = new List<int>();

            // figure out which blue privates are taken out
            int tempInt = useMeRandomly.Next(4, 7);

            // add the blue private to a list
            queueListItems.Add(tempInt);

            // figure out orage private
            tempInt = useMeRandomly.Next(1, 4);

            // add orange private to list
            queueListItems.Add(tempInt);

            // figure out which company is taken out
            RailRoads inPlayRailroad = (RailRoads)useMeRandomly.Next(1, 4);

            Console.WriteLine($"Railroad chosen for play: {inPlayRailroad.ToString().Replace('_', ' ')}");

            // add the rest of the privates that dont come out
            for (int I = 7; I <= 13; I++)
                queueListItems.Add(I);

            // randomize the list and add to queue
            PrivateDraftServices.Shuffle(queueListItems, useMeRandomly);

            // set queue equal to new randomed list
            AvailablePrivates = new Queue<int>(queueListItems);
        }
    }
}