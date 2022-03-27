using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vsexamplerandomiser.src
{
    public sealed class Randomise
    {
        public Random Random;
        private Randomise()
        {
            Random = new Random();
        }


        public static Randomise Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Randomise instance = new Randomise();
        }
    }
}
