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

    }
}
