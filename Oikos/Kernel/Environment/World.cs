using Oikos.Kernel.Dwellers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oikos.Kernel.Environment
{
    class World
    {
        private static Random rnd = new Random();
        // Bioms of the world
        private Biom center;
        // Maximal average world temperature fluctuation
        private double tempFluct = 15;
        // Average temperature on the equator
        private double aTemp = 20;
        // Difference between average temperature on the poles and on the equator
        private double tempDiff = 20;

        public double TempFluct { get => tempFluct; set => tempFluct = value; }
        public double ATemp { get => aTemp; set => aTemp = value; }
        public double TempDiff { get => tempDiff; set => tempDiff = value; }

        internal List<Species> Species()
        {
            List<Species> ret = new List<Species>();
            List<Biom> biomes = Biomes();
            foreach(var biom in biomes)
            {
                List<Species> biomSpecs = biom.Species();
                ret = ret.Union(biomSpecs).ToList();
            }
            return ret;
        }

        public static readonly double FREEZE_TEMP = -10;
        public static readonly double DESERT_TEMP = 40;
        public static readonly double TFMIN = 0;
        public static readonly double TFMAX = 50;
        public static readonly double ATMIN = -50;
        public static readonly double ATMAX = 50;
        public static readonly double TDMIN = 0;
        public static readonly double TDMAX = 100;

        public World(int numberOfBiomes, double[] biomHarshness, double minAngle, double maxAngle)
        {
            if (biomHarshness.Count() < numberOfBiomes)
            {
                var temp = biomHarshness;
                biomHarshness = new double[numberOfBiomes];
                temp.CopyTo(biomHarshness, 0);
            }
            for(int i = 0; i < biomHarshness.Count(); i++)
            {
                if (biomHarshness[i] > 1) biomHarshness[i] = 1;
                else if (biomHarshness[i] < 0) biomHarshness[i] = 0;
            }
            double centerAngle = (maxAngle + minAngle)/2;
            double deltaAngle = Math.Abs(maxAngle - minAngle) / (numberOfBiomes - 1);
            if (numberOfBiomes % 2 == 0) centerAngle += deltaAngle/2;
            center = new Biom(this, numberOfBiomes, biomHarshness, centerAngle, deltaAngle);
        }

        private World() { }

        internal void Tick()
        {
            foreach(var biom in Biomes())
            {
                biom.Tick();
            }
        }

        public List<Biom> Biomes()
        {
            Biom northPole = center.FindNorthernMost;
            List<Biom> ret = northPole.ListOfSouthBiomes();
            ret.Add(northPole);
            return ret;
        }

        public World(int numberOfBiomes, double angle) : this(numberOfBiomes, GenerateHarshness(numberOfBiomes), -angle, angle) { }

        public World(int numberOfBiomes) : this(numberOfBiomes, GenerateHarshness(numberOfBiomes), -Math.PI / 2, Math.PI / 2) { }

        private static double[] GenerateHarshness(int numberOfBiomes)
        {
            double[] biomHarshness = new double[numberOfBiomes];
            Random rnd = new Random();
            for (int i = 0; i < numberOfBiomes; i++)
                biomHarshness[i] = rnd.NextDouble();
            return biomHarshness;
        }

        internal double GetTemperature(double angle)
        {
            var baseT = ATemp + (1 - Math.Cos(angle*Math.PI/180)) * TempDiff;
            var fluct = (0.5 - rnd.NextDouble()) * TempFluct;
            return baseT + fluct;
        }

        public void GenerateRandomSpecies(int n)
        {
            for(int i = 0; i < n; i++)
                AddHerdRandomly();
        }
        public void AddHerdRandomly(Herd herd = null)
        {
            Biom continent = center;
            for (int i = 0; i < 100; i++)
            {
                switch (rnd.Next(0, 2))
                {
                    case 0:
                        continent = continent.north is null ? continent : continent.north;
                        break;
                    case 1:
                        continent = continent.south is null ? continent : continent.south;
                        break;
                    default:
                        break;
                }
            }
            Habitat region = continent.Regions[(rnd.Next(0, continent.Regions.Count() - 1))];
            if (herd is null)
            {
                region.AddHerd(new Herd(region));
            }
            else region.AddHerd(herd);
        }
        public World Clone()
        {
            World world = new World()
            {
                aTemp = aTemp,
                tempDiff = tempDiff,
                tempFluct = tempFluct
            };
            world.center = this.center.Clone(world);
            return world;
        }
    }
}
