using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiPokemon.Model
{
    public class Abilities
    {
        public AbilityName ability { get; set; }
        public bool is_hidden { get; set; }
    }

    public class AbilityName
    {
        public string name { get; set; }
    }
}
