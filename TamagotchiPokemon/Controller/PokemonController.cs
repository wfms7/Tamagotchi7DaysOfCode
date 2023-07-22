using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TamagotchiPokemon.Model;
using TamagotchiPokemon.Views;

namespace TamagotchiPokemon.Controller
{
    public class PokemonController
    {
       private  PokemonViews _PokemonViews = new PokemonViews();
       public List<Pokemon> _pokemonList = new List<Pokemon>();
        public List<Pokemon> _seusPokemos = new List<Pokemon>();
    


        public void CarregarPokemon()
        {

            int quantidadePokemon = 5;

            Random random = new Random();

           

            for (int i = 1; i <= quantidadePokemon; i++)
            {
                int idPokemon = random.Next(1, 300);
                var url = new RestClientOptions($"https://pokeapi.co/api/v2/pokemon/{idPokemon}");
                var cllient = new RestClient(url);
                var request = new RestRequest();
                var result = cllient.ExecuteGet(request);

                var data = JsonSerializer.Deserialize<Pokemon>(result.Content!)!;
                //   var x = data["abilities"]["ability"];
                _pokemonList.Add(new Pokemon
                {
                    id = i,
                    name = data.name,
                    height = data.height,
                    weight = data.weight,
                    types = data.types,
                    abilities = data.abilities

                });

            }
            inicio();

            //Console.WriteLine("==== Lista de Pokemons ====");


            //foreach (var pokemon in pokemonList)
            //{
            //    Console.WriteLine("==== ===== ====\n");
            //    Console.WriteLine($"Id:  {pokemon.id}");
            //    Console.WriteLine($"Nome: {pokemon.name.ToUpper()}");
            //    Console.WriteLine($"Altura: {pokemon.height}");
            //    Console.WriteLine($"Peso: {pokemon.weight}");
            //    //foreach (var item in pokemon.types)
            //    //{
            //    //    foreach (var item_ in item.type_)
            //    //    {
            //    //        if (item_.Key =="name")
            //    //        {
            //    //            Console.WriteLine($"Tipo: {item_.Value}");
            //    //        }

            //    //    }


            //    //}
            //    Console.WriteLine("Habilidades:");
            //    //foreach (var item in pokemon.abilities)
            //    //{
            //    //    foreach (var item_ in item.ability)
            //    //    {
            //    //        if (item_.Key == "name")
            //    //        {
            //    //            Console.WriteLine($" {item_.Value}");
            //    //        }
            //    //    }
            //    //}


            //    Console.WriteLine("==== ===== ====\n");
            //}

            //Console.ReadKey();
        }

        private void inicio()
        {
            _PokemonViews.inicio();

            menu();
        }

        private void menu()
        {
            _PokemonViews.menu();
            var opcao = int.Parse( Console.ReadLine());
            Console.WriteLine("--------------------------\n");
            switch ( opcao )
            {
                case 1:listaPokemon();
                    break;
                case 2:
                    verSeusPokemons();
                    break;
                case 3:
                    Console.WriteLine("Até a proxima");
                    break;
            }
        }

        private void listaPokemon()
        {
            _PokemonViews.listaPokemon(_pokemonList);
            var opcao = int.Parse(Console.ReadLine());
            opcaoAposSelecionar(opcao);

        }

        private void opcaoAposSelecionar(int opcaoSelecionada)
        {
            
            Console.WriteLine("--------------------------\n");
            if (opcaoSelecionada > 0 && opcaoSelecionada < 6)
            {
                var pokmonSelecionando = _pokemonList.FirstOrDefault(p => p.id == opcaoSelecionada);
                
                
                _PokemonViews.opcaoAposSelecionar(pokmonSelecionando);
                var opcao = int.Parse(Console.ReadLine());
                Console.WriteLine("--------------------------\n");
                switch (opcao)
                {
                    case 1:
                        infoPkemon(pokmonSelecionando);
                        break;
                    case 2:
                        adotar(pokmonSelecionando);
                        break;
                    case 3:
                        listaPokemon();
                        break;
                }

              
               

            }
        }

        private void verSeusPokemons()
        {
            Console.WriteLine("--------------------------\n");
            _PokemonViews.verSeusPokemons(_seusPokemos);
            Console.WriteLine("--------------------------\n");
            Console.ReadKey();
            menu();
        }

        private void infoPkemon(Pokemon pokemon)
        {
            Console.WriteLine("--------------------------\n");
            _PokemonViews.infoPkemon(pokemon);
            Console.WriteLine("--------------------------\n");
            Console.ReadKey();
            opcaoAposSelecionar(pokemon.id);
        }

        private void adotar(Pokemon pokemon)
        {
            Console.WriteLine("--------------------------\n");
            int totalPokemon = _seusPokemos.Count();

            _seusPokemos.Add(new Pokemon
            {
                id = totalPokemon + 1,
                abilities = pokemon.abilities,
                height = pokemon.height,
                name = pokemon.name,
                types = pokemon.types,
                weight = pokemon.weight
            });
            _PokemonViews.adotar();

            Console.WriteLine("--------------------------\n");

            startPlay(_seusPokemos[0]);

        }

        private void startPlay (Pokemon pokemon)
        {
            Console.WriteLine("--------------------------\n");

            _PokemonViews.menuAposAdocao(pokemon);
            var opcao = int.Parse( Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Brincar(pokemon);
                    break;
                case 2:
                   Alimentar(pokemon);
                    break;
                case 3:
                   Banho(pokemon);
                    break;
                case 4:
                    Dormir(pokemon);
                    break;
            }
        }

        public void Brincar(Pokemon pokemon)
        {
           
            _PokemonViews.Brincar(pokemon);
            startPlay(pokemon);
        }

        public void Alimentar(Pokemon pokemon)
        {
           _PokemonViews.Alimentar(pokemon);
            startPlay(pokemon);
        }

        public void Banho(Pokemon pokemon)
        {
            _PokemonViews.Banho(pokemon);
            startPlay(pokemon);
        }

        public void Dormir(Pokemon pokemon)
        {
            _PokemonViews.Dormir(pokemon);
            startPlay(pokemon);
        }

    }
}
