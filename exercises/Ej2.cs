using System;
using LibraryCards;

class Ej2
{
	// Devuelve una baraja desordenada
	public static Deck CrearBaraja()
	{
		Deck deck = new Deck();
		deck.Shuffle();

		return deck;
	}

	// Comprueba si hay tres cartas iguales en 'cartas'.
	// return true -> si hay tres cartas iguales
	// return false -> si no hay tres cartas iguales.
	public static bool TresCartasIguales(Card[] cartas)
	{
		bool tresIguales = false;
		int igual = 0;

		// Compara la carta 'i' con el resto de cartas del array 'cartas'.
		for (int i = 0; i < cartas.Length; i++)
		{
			for (int j = i + 1; j < cartas.Length; j++)
			{
				// Si las cartas son iguales, aumenta el contador.
				if (cartas[i].GetNum() == cartas[j].GetNum())
				{
					igual++;
				}
			}
		}

		if (igual == 3)
			tresIguales = true;

		return tresIguales;
	}


	public static void Main(string[] args)
	{
		Deck baraja = CrearBaraja();
		Card[] cartas;

		// Roba 5 cartas de la baraja.
		cartas = baraja.Draw(5);

		bool continuar = true;
		while (continuar) // TRUE para probar
		{
			baraja.PrintCards(cartas);

			if (TresCartasIguales(cartas))
			{
				Console.WriteLine ("Hay tres cartas iguales");
				continuar = false;
			}
			else
			{
				Console.WriteLine ("Sigue intentándolo");
				Console.ReadLine();
				cartas = baraja.Draw(5);
				// Si ya no se pueden sacar 5 cartas crea una nueva baraja.
				if (cartas.Length < 5)
				{
					Console.WriteLine ("¡¡¡Se han acabado las cartas!!!");
					Console.WriteLine ("Creando una nueva baraja...\n");

					baraja = CrearBaraja();
					cartas = baraja.Draw(5);
				}
			}
		}
	}
}
