using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TamagotchiPokemon.Model
{
    public class Types
    {

        public int slot { get; set; }
        [JsonPropertyName("type")]

        public Type type_ { get; set; }
        //public Dictionary<string,object> type_ { get; set; }

    }
}
