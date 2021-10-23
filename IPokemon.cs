using System;

namespace Pokeapp
{
    public interface IPokemon
	{
		public bool IsFainted { get; set; }
		public string Name { get; set; }
		public float Damage { get; set; }
		public void LoseHealth(float damage);

		public void PutToSleep();
	}
}
