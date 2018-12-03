using Oikos.Kernel.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oikos.Kernel.Dwellers
{
    class Herd
    {
        // Static fields
        private static readonly Random rnd = new Random();
        // End of static fields


        private Habitat habitat;
        public readonly Creature ancestor;
        private List<Creature> members = new List<Creature>();


        // Constructors
        public Herd(Creature ancestor, Habitat habitat)
        {
            this.ancestor = ancestor;
            ancestor.Herd = this;
            double[] genom = new double[Creature.GENOMSIZE];
            for (int i = 0; i < Creature.GENOMSIZE; i++)
            {
                genom[i] = ancestor.Genom(i);
            }
            Creature partner = new Creature(genom, this, !ancestor.female);
            if(!ancestor.female)
            {
                Creature tmp = ancestor;
                ancestor = partner;
                partner = tmp;
            }
            for (int i = 0; i < 10; i++)
            {
                members.Add(new Creature(partner, ancestor));
            }
            if(habitat != null)
            {
                this.Habitat = habitat;
                habitat.AddHerd(this);
            }
        }
        public Herd(Habitat habitat)
        {
            Random rnd = new Random();
            double[] genom = new double[Creature.GENOMSIZE];
            for(int i = 0; i < Creature.GENOMSIZE; i++)
            {
                genom[i] = rnd.NextDouble();
            }
            ancestor = new Creature(genom, this, true);
            Creature pater = new Creature(genom, this, false);
            for(int i = 0; i < 10; i++)
            {
                members.Add(new Creature(pater, ancestor));
            }
            habitat.AddHerd(this);
        }
        private Herd(List<Creature> members, Creature ancestor)
        {
            this.members = members;
            this.ancestor = ancestor;
        }
        internal static Herd Multiply(Creature ancestor)
        {
            Herd herd = new Herd(ancestor, null);
            for(int i = 0; i < 10; i++)
            {
                Creature creature = ancestor.Clone(i % 2 == 0);
                creature.Herd = herd;
                herd.members.Add(creature);
            }
            return herd;
        }

        // Accessors
        internal int Count()
        {
            return members.Count();
        }
        internal Habitat Habitat { get => habitat; set => habitat = value; }
        public Dictionary<string, double> AverageGenom()
        {
            Dictionary<string, double> ret = new Dictionary<string, double>();
            List<string> calls = Creature.Genes;
            foreach (string key in calls)
            {
                ret[key] = 0;
            }
            foreach (var member in members)
            {
                foreach (string key in calls)
                {
                    ret[key] += member.Gene(key);
                }
            }
            foreach (var key in calls)
            {
                ret[key] /= members.Count;
            }
            return ret;
        }


        // Actions
        internal void Breed()
        {
            List<Creature> membersCopy = new List<Creature>(members);
            foreach(Creature mother in membersCopy)
            {
                if(mother.female)
                {
                    Creature father = membersCopy[rnd.Next(membersCopy.Count() - 1)];
                    if (mother.CanBreedWith(father))
                    {
                        if(rnd.NextDouble() < father.ChanceOfBreed*mother.ChanceOfBreed)
                        {
                            members.Add(new Creature(father, mother));
                        }
                    }
                }
            }
        }
        internal void Sleep()
        {
            List<Creature> temp = new List<Creature>(members);
            foreach(var member in temp)
            {
                member.Sleep();
            }
        }
        public void Split(Creature creature)
        {
            Herd splited = new Herd(creature, Habitat.Move());
            members.Remove(creature);
            foreach(Creature member in members)
            {
                if(member.Distance(creature) < member.Distance(ancestor))
                {
                    members.Remove(member);
                    splited.members.Add(member);
                }
            }
            if(members.Count == 0)
            {
                Habitat.Forget(this);
            }
        }
        public double Nourish(double available)
        {
            members = members.OrderBy(x => new Random().NextDouble() > 0.5).ToList();
            foreach(var member in members)
            {
                available = member.Nourish(available);
            }
            return available;
        }
        internal void Hunt()
        {
            List<Creature> huntingPack = members.FindAll(x => x.Carnivory > 0.5);
            if (huntingPack.Count == 0) return;
            huntingPack = huntingPack.OrderBy(x => 0 - x.ScoreHunter()).ToList();
            Creature alpha = huntingPack[0];
            Herd bestPray = null;
            double compatibility = 0;
            foreach(Herd herd in Habitat.inhabitants)
            {
                if(herd != this)
                {
                    var score = alpha.ScorePray(herd.ancestor);
                    if (compatibility < score)
                    {
                        bestPray = herd;
                        compatibility = score;
                    }
                }
            }
            if (bestPray is null) return;
            var nourishment = bestPray.BeHunted(huntingPack);
            foreach(Creature hunter in huntingPack)
            {
                nourishment = hunter.Devour(nourishment);
            }
        }
        private double BeHunted(List<Creature> huntingPack)
        {
            double loot = 0;
            foreach(Creature hunter in huntingPack)
            {
                List<Creature> targets = members.OrderBy(x => new Random().Next()).Take(new Random().Next(0, members.Count() / 2)).ToList();
                foreach(Creature target in targets)
                {
                    loot += hunter.Duel(target) ? 0 : target.Size * target.Fullness * Creature.NOURISH_MULITPLIER;
                }
            }
            return loot;
        }
        public void Kill(Creature killed)
        {
            members.Remove(killed);
            if(members.Count() == 0)
            {
                Habitat.Forget(this);
            }
        }
        public void AddMember(Creature member) { members.Add(member); }

        // Cloners
        internal Herd Clone()
        {
            List<Creature> cloned = members.ConvertAll((x) => x.Clone());
            Herd ret = new Herd(cloned, ancestor.Clone());
            foreach (var clone in cloned)
            {
                clone.Herd = ret;
            }
            return ret;
        }
    }
}
