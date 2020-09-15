﻿
using System;
using System.Collections.Generic;

namespace YieldDemos
{
    class Program
    {
        static List<int> myList = new List<int>() { 1, 2, 3, 4, 5 };

        static void Main(string[] args)
        {
            // this is bad, you cann't put static and access modifiers with variables in a method.
            //static List<int> myPrivateList = new List<int>();
            //public List<int> myPrivateList = new List<int>();

            //foreach (var item in Filter())
            foreach (var item in RunningTotal())
            {
                Console.WriteLine(item);
            }

            GalaxyClass.ShowGalaxies();

            Console.WriteLine();
        }


        static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;

            foreach (var item in myList)
            {
                runningTotal += item;
                yield return runningTotal;
            }
        }

        static IEnumerable<int> Filter()
        {
            //List<int> temp = new List<int>();

            foreach (var item in myList)
            {
                if (item > 3)
                    yield return item;
            }

            //return temp;
        }
    }

    public static class GalaxyClass
    {
        public static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }

        public class Galaxies
        {
            public IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }
        }

        public class Galaxy
        {
            public string Name { get; set; }
            public int MegaLightYears { get; set; }
        }
    }
}
