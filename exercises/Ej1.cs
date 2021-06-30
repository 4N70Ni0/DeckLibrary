using System;
using LibraryCards;

class Ej1
{
	public static void Main (string[] args)
	{
		Deck baraja = new Deck();
		Card[] cartas;

		// Desordena la baraja.
		baraja.Shuffle();

		for (int i = 0; i < 13; i++)
		{
			// Roba 4 cartas de la baraja.
			cartas = baraja.Draw(4);
			// Muestra las 4 cartas en horizontal.
			baraja.PrintCards(cartas);
		}
	}
}
