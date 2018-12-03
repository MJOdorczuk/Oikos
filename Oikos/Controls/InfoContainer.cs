using Oikos.Kernel.Dwellers;
using Oikos.Kernel.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oikos.Controls
{
    class InfoContainer
    {
        // population, temperature, nutrition
        public List<Tuple<int, double, double>> biomInfos = new List<Tuple<int, double, double>>();
        public Dictionary<Species, int> speciesPops;

        private InfoContainer() { }

        public static InfoContainer ExtractInfo(World world)
        {
            InfoContainer ret = new InfoContainer();
            List<Species> species = world.Species();
            Dictionary<Species, int> speciesPops = new Dictionary<Species, int>();
            foreach(var spec in species)
            {
                speciesPops.Add(spec, 0);
            }
            foreach(var biom in world.Biomes())
            {
                int pop = biom.Population();
                double temp = biom.AverageTemperature();
                double nutrition = biom.Nutrition();
                ret.biomInfos.Add(new Tuple<int, double, double>(pop, temp, nutrition));
                foreach(var spec in species)
                {
                    speciesPops[spec] += biom.SpeciesPop(spec);
                }
            }
            ret.speciesPops = speciesPops;
            return ret;
        }
        
    }
}
