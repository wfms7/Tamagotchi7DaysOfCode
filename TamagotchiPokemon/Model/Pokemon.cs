using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TamagotchiPokemon.Model
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public List<Types> types { get; set; }

        public List<Abilities> abilities { get; set; }


        public int hunger  = new Random().Next(0,10);
        public int sad  = new Random().Next(0, 10);
        public int strong  = new Random().Next(0, 10);
       
        public int hygiene = new Random().Next(0, 10);
        public int sleepy = new Random().Next(0,10);
        
        public bool alive = true;


        public void status()
        {
            if (hunger<=0 && sad <= 0 && strong <= 0 && hygiene <= 0 && sleepy <= 0)
            {
                alive = false;
            }

            if (alive)
            {
                Console.WriteLine($"[Fome: {hunger}] | [Humor: {sad}] | [Força: {strong}] | [Higiene: {hygiene}] | [Sono: {sleepy}] |");
                
            }
            else

            {
                Console.WriteLine("Game Over");
                Console.ReadKey ();
                Console.Clear ();
                Environment.Exit (0);
            }
        }
        public void Brincar()
        {
            strong--;
            hunger--;
            if( hunger <3 || strong <=1 || sleepy <=0)
            {
                sad--;
            }
            else { sad++; }
           
            hygiene--;
            sleepy--;
        }

        public void Alimentar()
        {
            strong++;
            hunger++;

            sad++;
            hygiene--;
            sleepy--;

        }

        public void Banho(  )
        {
            sad++;
            hygiene++;
            sleepy--;
        }

        public void Dormir()
        {
            strong++;
            hunger--;
            sad++;
            sleepy++;
        }


    }

   


}


