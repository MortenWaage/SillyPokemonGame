using System;
using System.Collections.Generic;
using System.Text;

namespace Pokeapp
{
	public static class Pokedex
	{
		public enum Pokemon
		{
			Magicarp,
			Rapidash,
			Pikachu,
			Snorlax
		}

		public static Dictionary<Pokemon, string> pokeType = new Dictionary<Pokemon, string>()
		{
			{Pokemon.Magicarp, "Water" },
			{Pokemon.Rapidash, "Air" },
			{Pokemon.Pikachu, "Lightning" },
			{Pokemon.Snorlax, "Normal" }
		};

		public static Dictionary<Pokemon, string> pokeNames = new Dictionary<Pokemon, string>()
		{
			{Pokemon.Magicarp, "Magicarp" },
			{Pokemon.Rapidash, "Rapidash" },
			{Pokemon.Pikachu, "Pikachu" },
			{Pokemon.Snorlax, "Snorlax" }

		};

		public static Dictionary<Pokemon, float> pokeDamage = new Dictionary<Pokemon, float>()
		{
			{Pokemon.Magicarp, 1f },
			{Pokemon.Rapidash, 5f },
			{Pokemon.Pikachu, 4.5f },
			{Pokemon.Snorlax, 1f }
		};

		public static Dictionary<Pokemon, float> pokeHealth = new Dictionary<Pokemon, float>()
		{
			{Pokemon.Magicarp, 21f },
			{Pokemon.Rapidash, 10.5f },
			{Pokemon.Pikachu, 15.5f },
			{Pokemon.Snorlax, 20.5f }
		};
	}
}
