using Oikos.Kernel.Dwellers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oikos.Kernel.Environment
{
    class Habitat
    {
        private static readonly double FERTILE_TEMP = (World.FREEZE_TEMP - World.DESERT_TEMP) / 2;
        private static readonly double FERTILITY_RATIO = 1;
        private static readonly double FLORA_LIMIT = 100000;
        public readonly List<Herd> inhabitants = new List<Herd>();
        private double temperature;
        private double nutrition;
        public readonly Biom biom;

        public Habitat(Biom biom)
        {
            this.biom = biom;
        }

        private Habitat(Biom biom, List<Herd> inhabitants)
        {
            this.biom = biom;
            this.inhabitants = inhabitants;
        }

        public void Tick()
        {
            temperature = biom.GetTemperature();
            nutrition += FERTILITY_RATIO * Math.Exp(-1 - Math.Abs(FERTILE_TEMP - temperature)) * biom.harshness;
            if(nutrition > FLORA_LIMIT*(1-biom.harshness))
            {
                nutrition = FLORA_LIMIT * (1 - biom.harshness);
            }
            List<Herd> temp = new List<Herd>(inhabitants);
            foreach(Herd herd in temp)
            {
                herd.Sleep();
            }
            temp = new List<Herd>(inhabitants);
            foreach(Herd herd in temp)
            {
                nutrition = herd.Nourish(nutrition);
            }
            temp = new List<Herd>(inhabitants);
            foreach(Herd herd in temp)
            {
                herd.Breed();
            }
        }

        internal double Nutrition()
        {
            return nutrition;
        }

        internal List<Species> Species()
        {
            List<Species> ret = new List<Species>();
            foreach(var herd in inhabitants)
            {
                if(!ret.Contains(herd.ancestor.species))
                    ret.Add(herd.ancestor.species);
            }
            return ret;
        }

        internal int Population()
        {
            var pop = 0;
            foreach(var herd in inhabitants)
            {
                pop += herd.Count();
            }
            return pop;
        }

        public Habitat Move()
        {
            return this.biom.Move(this);
        }

        internal void Forget(Herd herd)
        {
            this.inhabitants.Remove(herd);
        }

        public double Temperature => temperature;
        internal void AddHerd(Herd herd)
        {
            inhabitants.Add(herd);
            herd.Habitat = this;
        }

        internal Habitat Clone(Biom biom)
        {
            List<Herd> clonedHerds = new List<Herd>();
            Habitat ret = new Habitat(biom, clonedHerds);
            foreach(var herd in inhabitants)
            {
                var clone = herd.Clone();
                clonedHerds.Add(clone);
                clone.Habitat = ret;
            }
            return ret;
        }

        internal int SpeciesPop(Species spec)
        {
            var pops = 0;
            foreach(var herd in inhabitants)
            {
                if(herd.ancestor.species == spec)
                {
                    pops += herd.Count();
                }
            }
            return pops;
        }
    }
}
