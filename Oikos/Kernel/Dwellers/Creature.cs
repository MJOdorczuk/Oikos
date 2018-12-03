using Oikos.Kernel.Environment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oikos.Kernel.Dwellers
{
    class Creature
    {

        //Static fields
        public static readonly double NOURISH_MULITPLIER = 5.0;
        private const double MUTABILITY_LIMIT = 0.1;
        private const double RELATIVITY_LIMIT = 0.1;
        public static readonly uint SIZE = 0;
        public static readonly uint REFLEX = 1;
        public static readonly uint CARNIVORY = 2;
        public static readonly uint TEMPOPT = 3;
        public static readonly uint TEMPRANGE = 4;
        public static readonly uint SENSE = 5;
        public static readonly uint SPEED = 6;
        public static readonly uint AGILITY = 7;
        public static readonly uint COLOR = 8;
        public static readonly uint MUTABILITY = 9;

        public static readonly uint GENOMSIZE = 10;

        private readonly static Dictionary<string, uint> calls =
            new Dictionary<string, uint>()
            {
                { "size", SIZE },
                { "reflex", REFLEX },
                { "carnivory", CARNIVORY },
                { "tempopt", TEMPOPT },
                { "temprange", TEMPRANGE },
                { "sense", SENSE },
                { "speed", SPEED },
                { "agility", AGILITY },
                { "color", COLOR },
                { "mutability", MUTABILITY }
            };
        public static Dictionary<string, uint> Calls => new Dictionary<string, uint>(calls);

        public static List<string> Genes => new List<string>()
        { "size", "reflex", "carnivory", "tempopt", "temprange", "sense", "speed", "agility", "color", "mutability" };
        private readonly static Random rnd = new Random();

        //End of static fields



        /*
        * Gene pool
        */
        private readonly double[] genom = new double[GENOMSIZE];

        public readonly bool female;
        private double energy;
        private Herd herd;
        public readonly Species species;
        /*
         * Result traits
         */
        private double energyStorage, energyConsumption, chanceOfDeath, chanceOfBreed;



        //Constructors
        public Creature(double[] genom, Herd herd, bool female)
        {
            if (genom.Count() != GENOMSIZE) throw new Exception("Wrong genom size");
            foreach (double gene in genom)
            {
                if (gene < 0 || gene > 1) throw new Exception("Parameter out of range");
            }
            this.genom = genom;
            this.Herd = herd;
            this.female = female;
            if (!(herd is null)) herd.AddMember(this);
            if (herd is null) species = new Species(this);
            else if (herd.ancestor is null) species = new Species(this);
            else species = herd.ancestor.species;
            AnalyseGenePool();
        }
        public Creature(Creature father, Creature mother)
        {
            if (father.female || !mother.female || !father.species.CloseWith(mother.species)) throw new Exception("Not possible to breed");
            for (int i = 0; i < GENOMSIZE; i++)
            {
                genom[i] = Mutate((father.genom[i] + mother.genom[i]) / 2);
            }
            female = rnd.NextDouble() - 0.5 > 0;
            this.Herd = father.Herd;
            herd.AddMember(this);
            double paternalDistance = Distance(father);
            double maternalDistance = Distance(mother);
            if (paternalDistance > RELATIVITY_LIMIT && maternalDistance > RELATIVITY_LIMIT)
            {
                species = new Species(this);
                species.RelateWith(mother.species);
                species.RelateWith(father.species);
                if (!species.CloseWith(herd.ancestor.species))
                    herd.Split(this);
            }
            else if (Distance(father) > Distance(mother))
                species = mother.species;
            else species = father.species;
            AnalyseGenePool();
        }
        private Creature(double[] genom, bool female, Species species)
        {
            this.genom = genom;
            this.female = female;
            this.species = species;
            AnalyseGenePool();
        }

        //Cloning devices
        internal Creature Clone()
        {
            var clone = new Creature(genom, female, species)
            {
                energy = this.energy
            };
            return clone;
        }
        internal Creature Clone(bool v)
        {
            var clone = new Creature(genom, v, species)
            {
                energy = this.energy
            };
            return clone;
        }

        //Accessors
        public double Genom(int i)
        {
            return genom[i];
        }
        public double Gene(string geneName)
        {
            return genom[calls[geneName]];
        }
        public double Size => genom[SIZE];
        public double Reflex => genom[REFLEX];
        public double Carnivory => genom[CARNIVORY];
        public double TempOpt => genom[TEMPOPT];
        public double TempRange => genom[TEMPRANGE];
        public double Sense => genom[SENSE];
        public double Speed => genom[SPEED];
        public double Agility => genom[AGILITY];
        public double Color => genom[COLOR];
        public double Mutability => genom[MUTABILITY];
        public double EnergyStorage => energyStorage;
        public double EnergyConsumption => energyConsumption;
        public double Fullness => energy / energyStorage;
        public double ChanceOfDeath => chanceOfDeath;
        public double ChanceOfBreed => chanceOfBreed;
        internal Herd Herd { get => herd; set => herd = value; }

        //Commands and actions
        internal void Sleep()
        {
            energy -= energyConsumption;
            if (energy <= 0 || rnd.NextDouble() < chanceOfDeath) herd.Kill(this);
        }
        internal double Devour(double nourishment)
        {
            if (nourishment > (energyStorage - energy) * 10 / Carnivory)
            {
                nourishment -= (EnergyStorage - energy) / Carnivory;
                energy = energyStorage;
            }
            else
            {
                nourishment -= 0.5 * nourishment * Carnivory;
                energy += 0.5 * nourishment * Carnivory * Carnivory;
            }
            return nourishment;
        }
        internal double Nourish(double available)
        {
            /*if(Carnivory > 0.5 && !hasHunted)
            {
                
            }*/
            if (Carnivory < 0.8)
            {
                if (available > (energyStorage - energy) * 100)
                {
                    available -= (EnergyStorage - energy) / (1 - Carnivory);
                    energy = energyStorage;
                }
                else
                {
                    var nourishmentFound = rnd.NextDouble() * (available / 100);
                    available -= nourishmentFound;
                    energy += nourishmentFound * (1 - Carnivory);
                }
            }
            return available;
        }
        internal bool Duel(Creature target)
        {
            if (Agility * Speed * (energy / EnergyStorage) / (Visibility + 1) - target.Reflex * (target.energy / target.EnergyStorage) * (rnd.NextDouble() + 0.5) > 0)
            {
                target.herd.Kill(target);
                return true;
            }
            if (Size * Agility - target.Size * (rnd.NextDouble() + 0.5) > 0)
            {
                target.herd.Kill(target);
                return true;
            }
            return false;
        }

        //Valuators
        internal double ScoreHunter()
        {
            return Carnivory * energy * Speed * Agility * Sense * Reflex * Size;
        }
        internal double ScorePray(Creature ancestor)
        {
            var c1 = (1 + Carnivory - ancestor.Carnivory);
            var c2 = (1 + Speed - ancestor.Speed);
            var c3 = (2 - Size - Sense);
            var c4 = (2 + Agility - Size - ancestor.Reflex);
            var c5 = ancestor.Visibility;
            return c1 * c2 * c3 * c4 * c5;
        }
        private double Visibility
        {
            get
            {
                double t;
                if (herd.Habitat.Temperature < World.FREEZE_TEMP) t = World.FREEZE_TEMP;
                else if (herd.Habitat.Temperature > World.DESERT_TEMP) t = World.DESERT_TEMP;
                else t = herd.Habitat.Temperature;
                return Math.Abs(Color * World.DESERT_TEMP - World.FREEZE_TEMP - t - World.FREEZE_TEMP);
            }
        }
        private void AnalyseGenePool()
        {
            energy = energyStorage = Size * (Carnivory / 2 + 0.5) * (1 - TempRange) * (1 - Speed) * (1 - Agility);
            energyConsumption = (Size / 2 + 1 / 2) * Reflex * (1 - TempOpt / 2) * TempRange * Sense * Speed * Agility * 0.01;
            chanceOfDeath = Math.Pow((1 - Size * 0.9) * (1 - Reflex * 0.2) * (Speed / 2 + 0.5) * Mutability, 2);
            chanceOfBreed = Math.Pow((1 - Size) * (Carnivory * 0.75 + 0.25) * Speed * Agility, 0.8);
        }
        private double Mutate(double value)
        {
            double mutation = Mutability * (0.5 - rnd.NextDouble()) * MUTABILITY_LIMIT;
            if (mutation > 0) value += (1 - value) * mutation;
            else value -= value * mutation;
            return value;
        }
        public double Distance(Creature creature)
        {
            double distance = 0;
            for (int i = 0; i < GENOMSIZE; i++)
            {
                double a = genom[i];
                double b = creature.genom[i];
                distance += (a - b) * (a - b);
            }
            return distance;
        }
        public bool CanBreedWith(Creature creature)
        {
            return Distance(creature) < RELATIVITY_LIMIT && (female != creature.female) && species.CloseWith(creature.species);
        }
    }
}
