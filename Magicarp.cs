using System;

namespace Pokeapp
{
	public class Magicarp : IPokemon
	{
		public bool IsUseless = true; //property
		public bool IsFainted { get => health <= 0; set { } }
		public string Name { get; set; }
		private float  health;
		public float Damage { get => Attack(); set { } }
		private bool isAsleep;

		float damage;
		public Magicarp()
		{
			Random random = new Random();
			int randomNumber = random.Next(1, 3);
			if (randomNumber == 1) IsUseless = true;

			health = Pokedex.pokeHealth[Pokedex.Pokemon.Magicarp];
			damage = Pokedex.pokeDamage[Pokedex.Pokemon.Magicarp];
			Name = Pokedex.pokeNames[Pokedex.Pokemon.Magicarp];
		}
		public void LoseHealth(float damage)
		{
			health -= Math.Min(damage, health);
			if (IsUseless) health = 0;
			Combat.Log.AddToLog($"{Name} took {damage} damage. Remaining health is {health}");
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

			return FlopAroundUselessly();
		}
		public void PutToSleep()
        {
			Combat.Log.AddToLog($"{Name} was put to sleep");
			isAsleep = true;
        }
		private float FlopAroundUselessly()
        {
			return damage;//Console.WriteLine("Magicarp is useless. It flops uselessly!");
        }
	}
}
