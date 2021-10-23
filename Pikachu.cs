using System;

namespace Pokeapp
{
	public class Pikachu : IPokemon, IAbilities
	{
		public bool IsFainted { get => health <= 0; set { } }
		public string Name { get; set; }
		private float health;
		public float Damage { get => Attack(); set { } }

		private bool isAsleep;
		private float damage;
		int numberOfAttacks = 2; // Anntall ulike angrep som Pikachu kan utføre

		public Pikachu()
		{
			health = Pokedex.pokeHealth[Pokedex.Pokemon.Pikachu];
			damage = Pokedex.pokeDamage[Pokedex.Pokemon.Pikachu];
			Name = Pokedex.pokeNames[Pokedex.Pokemon.Pikachu];
		}
		public void LoseHealth(float damage)
		{
			health -= Math.Min(damage, health);
			Combat.Log.AddToLog($"{Name} took {damage} damage. Remaining health is {health}"); //Singleton - kan når fra alle steder i koden
			if (IsFainted == true)
			{
				Combat.Log.AddToLog($"{Name} has fainted ");
			}
		}
		public float Attack()
        {
			if (isAsleep)
			{
				isAsleep = false;
				Combat.Log.AddToLog($" {Name} is asleep ");
				return -1;
			}

			Random rand = new Random();
			int attack = rand.Next(1, numberOfAttacks);

			switch (attack)
            {
				case 1: return ThunderBolt();
				case 2: return TailSwipe();
				default: return damage;
			}

			float ThunderBolt()
			{
				return damage * 3f;
			}

			float TailSwipe()
			{
				return damage * 0.5f;
			}
		}

		public void PutToSleep()
        {
			Combat.Log.AddToLog($"{Name} was put to sleep");
			isAsleep = true;
        }
	}
}
