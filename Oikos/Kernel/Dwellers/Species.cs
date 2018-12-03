using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oikos.Kernel.Dwellers
{
    class Species
    {
        // Static fields
        private static readonly List<string> prefixes = new List<string>()
        {
            "Arbo",
            "Ando",
            "Arachi",
            "Atlapa",
            "Anti",
            "Biro",
            "Betha",
            "Bona",
            "Basis",
            "Basilei",
            "Burgundi",
            "Bavari",
            "Boleslaui",
            "Ceraeri",
            "Nesti",
            "Arpadi",
            "Tauri",
            "Kalaui"
        };
        private static readonly List<string> suffixes = new List<string>()
        {
            "nensis",
            "ana",
            "mina",
            "puta",
            "trada",
            "tops",
            "sinaps",
            "saur",
            "nychus",
            "aviis"
        };
        private static readonly List<string> adjectives = new List<string>()
        {
            "Albii",
            "Cavia",
            "Mortis",
            "Vulgar",
            "Pulchra",
            "Iraes",
            "Hibernii"
        };
        private static Random rnd = new Random();
        // End of static fields

        
        private readonly Creature ancestor;
        public readonly string name;
        private List<Species> closeSpecies = new List<Species>();
        

        // Constructors
        public Species(Creature ancestor)
        {
            this.ancestor = ancestor;
            this.name = GenerateName();
        }

        // Actions
        private string GenerateName()
        {
            string name = prefixes[rnd.Next(0, prefixes.Count())];
            name += suffixes[rnd.Next(0, suffixes.Count())];
            name += " " + adjectives[rnd.Next(0, adjectives.Count())];
            return name;
        }
        public void RelateWith(Species species)
        {
            if (closeSpecies.Contains(species))
                return;
            species.closeSpecies.Add(this);
            closeSpecies.Add(species);
        }
        public bool CloseWith(Species species)
        {
            return species == this || closeSpecies.Exists(s => s == species);
        }
    }
}
