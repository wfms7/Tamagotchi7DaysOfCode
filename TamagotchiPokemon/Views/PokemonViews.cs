using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiPokemon.Controller;
using TamagotchiPokemon.Model;

namespace TamagotchiPokemon.Views
{
    public class PokemonViews
    {
        string nome = "";

        public void inicio()

        {
            Console.WriteLine(@"                
██████╗░░█████╗░██╗░░██╗███████╗███╗░░░███╗░█████╗░███╗░░██╗
██╔══██╗██╔══██╗██║░██╔╝██╔════╝████╗░████║██╔══██╗████╗░██║
██████╔╝██║░░██║█████═╝░█████╗░░██╔████╔██║██║░░██║██╔██╗██║
██╔═══╝░██║░░██║██╔═██╗░██╔══╝░░██║╚██╔╝██║██║░░██║██║╚████║
██║░░░░░╚█████╔╝██║░╚██╗███████╗██║░╚═╝░██║╚█████╔╝██║░╚███║
╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚══╝

");

            Console.WriteLine("Bem vindo ao Pokemon virtual");
            Console.WriteLine("Qual seu nome?");

            nome = Console.ReadLine();
            Console.WriteLine("--------------------------\n");
        }

        public void menu() {

            Console.WriteLine($"{nome}, Escolha o que deseja fazer?");
            Console.WriteLine($"1 - Adotar Pokemon:");
            Console.WriteLine($"2 - Ver seus Pokemons");
            Console.WriteLine($"3 - Sair");
            Console.WriteLine($"Obs. digite um numero para escolher uma das opções");


        }
        public void listaPokemon(List<Pokemon> pokemons) {
            Console.WriteLine("Escolha um dos Pokemos abaixo");



            foreach (var item in pokemons)
            {
                Console.WriteLine($"{item.id} - {item.name.ToUpper()}");
            }

        }

        public void opcaoAposSelecionar(Pokemon pokemon)
        {
            Console.WriteLine($"{nome} Você deseja");
            Console.WriteLine($"1 - Deseja saber mais do {pokemon.name.ToUpper()}");
            Console.WriteLine($"2 - Adotar o {pokemon.name.ToUpper()}");
            Console.WriteLine($"3 - Voltar");
        }

        public void infoPkemon(Pokemon pokemon) {

            Console.WriteLine($"Nome: {pokemon.name.ToUpper()}");
            Console.WriteLine($"Altura: {pokemon.height}");
            Console.WriteLine($"Peso: {pokemon.weight}");
            Console.WriteLine($"Tipo: [");
            foreach (var item in pokemon.types)
            {
                Console.WriteLine($"  {item.type_.name}");
            }
            Console.WriteLine($"]");
            Console.WriteLine($"Habilidade: [");
            foreach (var item in pokemon.abilities)
            {
                Console.WriteLine($"  {item.ability.name} ");
            }
            Console.WriteLine($"]");
        }
        public void adotar()
        {
            Console.WriteLine("Pokemon adotado com sucesso");
            Console.WriteLine("===========");
            Console.WriteLine(@" (ʘ‿ʘ)");
            Console.WriteLine("===========");
        }

        public void verSeusPokemons(List<Pokemon> pokemons)
        {
            Console.WriteLine("Seus Pokemons");
            foreach (var item in pokemons)
            {
                Console.WriteLine($"{item.id} - {item.name.ToUpper()}");
            }
        }

        public void menuAposAdocao(Pokemon pokemon) {
            statusPokemon(pokemon);
            Console.WriteLine($"Olá, {nome} o que deseja fazer ?");
            Console.WriteLine($"1 - Brincar com {pokemon.name.ToUpper()}");
            Console.WriteLine($"2 - Alimentar o {pokemon.name.ToUpper()}");
            Console.WriteLine($"3 - Dar banho no {pokemon.name.ToUpper()}");
            Console.WriteLine($"4 - Colocar para Dormir");



        }

        public void statusPokemon(Pokemon pokemon) { 
            Console.WriteLine($"Pokemon: {pokemon.name.ToUpper()}");
            pokemon.status();
          
        
        }

        public void Brincar(Pokemon pokemon)
        {
            pokemon.Brincar();
            Console.WriteLine("Pokemon esta brincando");
            Thread.Sleep(5000);
            Console.WriteLine("Sucesso");
        }
        
        public void Alimentar(Pokemon pokemon)
        {
            pokemon.Alimentar();
            Console.WriteLine("Pokemon esta se Alimentando");
            Thread.Sleep(5000);
            Console.WriteLine("Sucesso");
        }

        public void Banho(Pokemon pokemon)
        {
            pokemon.Banho();
            Console.WriteLine("Pokemon esta tomando banho ");
            Thread.Sleep(5000);
            Console.WriteLine("Sucesso");
        }

        public void Dormir(Pokemon pokemon)
        {
            pokemon.Dormir();
            Console.WriteLine("Pokemon esta ZZZZZZZZZ");
            Thread.Sleep(5000);
            Console.WriteLine("Sucesso");
        }
    }
}
