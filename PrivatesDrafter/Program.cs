﻿using PrivatesDrafter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Privates_Drafter
{
    /// <summary>
    /// The main class for the program
    /// </summary>
    class Program
    {
        #region Properties
        /// <summary>
        /// The queue of available privates
        /// </summary>
        public static Queue<int> AvailablePrivates = new Queue<int>();
        #endregion

        /// <summary>
        /// Where all things magical begin
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // randomize
            AvailablePrivates = new PrivateDraftServices().SetupGame();

            // start the drafting process
            StartUI();
        }

        /// <summary>
        /// Starts the UI to begin the drafring process
        /// </summary>
        private static void StartUI()
        {
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

                // get the private
                Privates selectedPrivate = 0;
                while (!Enum.TryParse(Console.ReadLine().Replace(' ', '_'), out selectedPrivate))
                    // they input invalid input
                    Console.WriteLine("Invalid private selection. Try again");

                // remove the selected private from list
                privatesSelection.Remove(selectedPrivate);

                // shuffle
                PrivateDraftServices.Shuffle(privatesSelection, new Random());

                // add the available private to queue
                foreach (int I in privatesSelection)
                    AvailablePrivates.Enqueue(I);

                // buffer space
                Console.Clear();
            }
        }
    }
}