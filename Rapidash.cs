using System;

namespace Pokeapp
{
	public class Rapidash : IPokemon
	{
		public bool IsFainted { get => health <= 0; set { } }
		public string Name { get; set; }
		private float health;
		public float Damage { get => Attack(); set { } }
		private bool isAsleep;

		float damage;
		public void PutToSleep()
        {
			Combat.Log.AddToLog($"{Name} was put to sleep");
			isAsleep = true;
        }

		public Rapidash()
		{
			health = Pokedex.pokeHealth[Pokedex.Pokemon.Rapidash];
			damage = Pokedex.pokeDamage[Pokedex.Pokemon.Rapidash];
			Name = Pokedex.pokeNames[Pokedex.Pokemon.Rapidash];
		}
		public void LoseHealth(float damage)
		{
			health -= Math.Min(damage, health);
			Combat.Log.AddToLog($"{Name} took {damage} damage. Remaining health is {health}");
			if(IsFainted == true)
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

			int numberOfAttacks = 1;
			Random rand = new Random();
			int attack = rand.Next(1, numberOfAttacks);

			switch (attack)
			{
				case 1: return Kick();
				default: return damage;
			}	
		}

		private float Kick()
        {
			return damage;
        }
	}
}
