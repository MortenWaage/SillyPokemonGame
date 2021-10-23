using System;
using System.Collections.Generic;

namespace Pokeapp
{
    class Program
    {
        static void Main(string[] args)
        {
            int roundNumber = 1;
            bool gameOver = false;

            Console.WriteLine("Pokekampen har startet!");

            List<IPokemon> activePokemons = new List<IPokemon>();

            activePokemons.Add(new Magicarp());
            activePokemons.Add(new Rapidash());
            activePokemons.Add(new Pikachu());
            activePokemons.Add(new Snorlax());

            while (!gameOver)
            {
                ResetRound();

                AttackOtherPokemons();

                CheckIfFainted();

                CheckWinner();

                Combat.Log.PrintLogToConsole();
            }

            void AttackOtherPokemons()
            {
                foreach (IPokemon Pokemon in activePokemons)
                    if (!Pokemon.IsFainted)
                        CauseDamage(Pokemon);
            }

            void CauseDamage(IPokemon attackingPokemon)
            {
                foreach (IPokemon Pokemon in activePokemons)
                    if (Pokemon != attackingPokemon && !Pokemon.IsFainted)
                    {
                        float damage = attackingPokemon.Damage;
                        if (damage == -1) continue;
                        else if (damage == -2)
                        {
                            Combat.Log.AddToLog($"{attackingPokemon.Name} put {Pokemon.Name} to sleep with a very soothing relaxing Lullaby");
                            Pokemon.PutToSleep();
                        }
                        else
                        {
                            Combat.Log.AddToLog($"{attackingPokemon.Name} attacked {Pokemon.Name} with {attackingPokemon.Damage} damage");
                            Pokemon.LoseHealth(damage);
                        }
                    }
            }

            void CheckIfFainted()
            {
                List<IPokemon> tempPokemons = new List<IPokemon>();
                foreach (IPokemon Pokemon in activePokemons)
                    if (!Pokemon.IsFainted)
                        tempPokemons.Add(Pokemon);

                activePokemons.Clear();
                foreach (IPokemon pokemon in tempPokemons)
                    activePokemons.Add(pokemon);
            }

            void ResetRound()
            {
                Combat.Log.StartNewRound();
                Combat.Log.AddLogLineBreak(1);
                Combat.Log.AddToLog($"Starting round number {roundNumber}");
                Combat.Log.AddToLog($"Pokemons in Battle is: {GetRemainingPokemon()}");
                Combat.Log.AddLogLineBreak(1);
                roundNumber++;

                string GetRemainingPokemon()
                {
                    string names = "";
                    foreach (IPokemon pokemon in activePokemons)
                        names += pokemon.Name + ", ";
                    return names;
                }
            }

            void CheckWinner()
            {
                if (activePokemons.Count > 1) return;

                gameOver = true;

                string winMessage = "The winner is ";
                foreach (IPokemon pokemon in activePokemons)
                    winMessage += pokemon.Name + "!!";

                Combat.Log.WinnerLog(winMessage);
            }
        }
    }
}
