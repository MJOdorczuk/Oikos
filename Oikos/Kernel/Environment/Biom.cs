using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oikos.Kernel.Dwellers;

namespace Oikos.Kernel.Environment
{
    class Biom
    {
        //Static fields
        public static readonly uint HABITAT_COUNT = 10;
        public static readonly double CHANCE_TO_MIGRATE = 0.01;
        //End of static fields

        
        private readonly List<Habitat> regions = new List<Habitat>();
        public readonly World world;
        public readonly Biom north, south;
        // Vertical coordinate of the region, from -1 to 1, where 0 is equator and -1 and 1 are poles
        public readonly double angle;
        
        // Universal factor, summation of all environmental factors (0 - mild, 1 - harsh)
        public readonly double harshness;


        //Constructors
        public Biom(World world, int numberOfBiomes, double[] biomHarshness, double centerAngle, double deltaAngle)
        {
            this.world = world;
            angle = centerAngle;
            int southBiomes = numberOfBiomes % 2 == 0 ? numberOfBiomes / 2 - 1 : numberOfBiomes / 2;
            if (southBiomes < 0) southBiomes = 0;
            int northBiomes = numberOfBiomes / 2;
            double[] toSouth = biomHarshness.Take(southBiomes).Reverse().ToArray();
            double[] toNorth = biomHarshness.Skip(southBiomes + 1).ToArray();
            harshness = biomHarshness[(int)Math.Floor((double)(numberOfBiomes - 1) / 2)];
            if(northBiomes > 0) north = new Biom(this, true, northBiomes, toNorth, centerAngle, deltaAngle);
            if(southBiomes > 0) south = new Biom(this, false, southBiomes, toSouth, centerAngle, deltaAngle);
            for(int i = 0; i < HABITAT_COUNT; i++)
            {
                regions.Add(new Habitat(this));
            }
        }
        private Biom(Biom mother, bool toNorth, int biomsToCreate, double[] biomHarshness, double currentAngle, double deltaAngle)
        {
            harshness = biomHarshness[0];
            angle = currentAngle + (toNorth ? deltaAngle : -deltaAngle);
            biomHarshness = biomHarshness.Skip(1).ToArray();
            world = mother.world;
            Biom neigh;
            if (biomsToCreate > 1)
                neigh = new Biom(this, toNorth, biomsToCreate - 1, biomHarshness, angle, deltaAngle);
            else neigh = null;
            if (toNorth)
            {
                north = neigh;
                south = mother;
            }
            else
            {
                north = mother;
                south = neigh;
            }
            for (int i = 0; i < HABITAT_COUNT; i++)
            {
                regions.Add(new Habitat(this));
            }
        }
        public Biom(World world, List<Habitat> regions, double angle, Biom north, Biom south, double harshness)
        {
            this.regions = regions;
            this.angle = angle;
            this.harshness = harshness;
            this.world = world;
            if (!(north is null)) this.north = north.CloneNorth(world, this);
            if (!(south is null)) this.south = south.CloneSouth(world, this);
        }
        public Biom(World world, List<Habitat> regions, double angle, Biom north, Biom south, double harshness, bool toNorth)
        {
            this.regions = regions;
            this.angle = angle;
            this.harshness = harshness;
            this.north = north;
            this.south = south;
            this.world = world;
            if (toNorth && !(north is null)) this.north = north.CloneNorth(world, this);
            if (!(south is null || toNorth)) this.south = south.CloneSouth(world, this);
        }

        //Accessors
        internal int SpeciesPop(Species spec)
        {
            var ret = 0;
            foreach(var region in regions)
            {
                ret += region.SpeciesPop(spec);
            }
            return ret;
        }
        internal double GetTemperature()
        {
            return world.GetTemperature(angle);
        }
        internal int Population()
        {
            int ret = 0;
            foreach (var region in regions)
            {
                ret += region.Population();
            }
            return ret;
        }
        internal double Nutrition()
        {
            var ret = 0.0;
            foreach (var region in regions)
            {
                ret += region.Nutrition();
            }
            return ret;
        }
        internal double AverageTemperature()
        {
            var ret = 0.0;
            foreach (var region in regions)
            {
                ret += region.Temperature;
            }
            return ret / regions.Count();
        }
        internal List<Species> Species()
        {
            List<Species> ret = new List<Species>();
            foreach (var region in regions)
            {
                ret = ret.Union(region.Species()).ToList();
            }
            return ret;
        }
        internal List<Biom> ListOfSouthBiomes()
        {
            if (south is null) return new List<Biom>(new Biom[] { this });
            else
            {
                List<Biom> ret = south.ListOfSouthBiomes();
                ret.Add(this);
                return ret;
            }
        }
        public List<Habitat> Regions => new List<Habitat>(regions);
        internal Biom FindNorthernMost => north is null ? this : north.FindNorthernMost;

        // Actions
        internal Habitat Move(Habitat habitat)
        {
            Habitat ret = habitat;
            while(ret == habitat)
            {
                var rnd = new Random().NextDouble();
                if(rnd < CHANCE_TO_MIGRATE/2)
                {
                    return north.Move(habitat);
                }
                else if(rnd < CHANCE_TO_MIGRATE)
                {
                    return south.Move(habitat);
                }
                else
                {
                    ret = regions[new Random().Next(0, regions.Count - 1)];
                }
            }
            return ret;
        }
        internal void Tick()
        {
            foreach (Habitat region in regions)
            {
                region.Tick();
            }
        }


        private Biom CloneSouth(World world, Biom biom)
        {
            List<Habitat> regionsClones = new List<Habitat>();
            foreach (var region in regions)
            {
                regionsClones.Add(region.Clone(this));
            }
            Biom cloned = south is null ? null : south.CloneSouth(world, this);
            Biom ret = new Biom(world, regionsClones, angle, biom, cloned, harshness, false);
            return ret;
        }
        private Biom CloneNorth(World world, Biom biom)
        {
            List<Habitat> regionsClones = new List<Habitat>();
            foreach (var region in regions)
            {
                regionsClones.Add(region.Clone(this));
            }
            Biom cloned = north is null ? null : north.CloneNorth(world, this);
            Biom ret = new Biom(world, regionsClones, angle, cloned, biom, harshness, true);
            return ret;
        }
        
        
        internal Biom Clone(World world)
        {
            List<Habitat> regionsClones = new List<Habitat>();
            foreach(var region in regions)
            {
                regionsClones.Add(region.Clone(this));
            }
            Biom biom = new Biom(world, regionsClones, angle, north, south, harshness);
            return biom;
        }
    }
}
