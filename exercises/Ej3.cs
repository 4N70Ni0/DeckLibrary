using System;
using LibraryCards;

class Ej3
{
	// Puntos de los jugadores.
	static private int jug1pts = 0;
	static private int jug2pts = 0;

	// Muestra las dos cartas de forma horizontal.
	public static void MostrarCartas(Deck deck, Card card1, Card card2)
	{
		Card[] mostrar = {card1, card2};
		Console.WriteLine("  Jugador 1    Jugador 2");
		deck.PrintCards(mostrar);
	}

	// Compara que carta es la más alta y da punto a ese jugador.
	public static string CartaMasAlta(Card jug1, Card jug2)
	{
		string ret;

		if (jug1.GetNum() > jug2.GetNum())
		{
			ret = "Punto para el Jugador 1 por tener la carta más alta.";
			jug1pts++;
		}
		else if (jug2.GetNum() > jug1.GetNum())
		{
			ret = "Punto para el Jugador 2 por tener la carta más alta.";
			jug2pts++;
		}
		else
			ret = "Las cartas son iguales.";

		return ret;
	}

	// Si los palos son distintos, da punto al que haya sacado.
	public static string Jugador(bool turno)
	{
		string ret;

		if (turno)
		{
			ret = "Punto para el Jugador 1.";
			jug1pts++;
		}
		else
		{
			ret = "Punto para el Jugador 2.";
			jug2pts++;
		}

		return ret;
	}

	public static void Main(string[] args)
	{
		// TRUE -> Jugador 1
		// FALSE -> Jugador 2
		bool turno = true;
		Deck baraja = new Deck();
		Card[] jug1;
		Card[] jug2;

		// Crea la baraja y roba 10 cartas para cada jugador.
		baraja.Shuffle();
		jug1 = baraja.Draw(10);
		jug2 = baraja.Draw(10);

		for (int ronda = 0; ronda < jug1.Length; ronda++)
		{
			// Muestras las dos cartas en horizontal.
			MostrarCartas(baraja, jug1[ronda], jug2[ronda]);

			// Compara los palos. Si son iguales las cartas se comparan por el número.
			if (jug1[ronda].GetSuit() == jug2[ronda].GetSuit())
			{
				Console.WriteLine("Los palos son iguales.");
				Console.WriteLine(CartaMasAlta (jug1[ronda], jug2[ronda]));
			}
			else
			{
				Console.WriteLine("Los palos son distintos.");
				Console.WriteLine(Jugador(turno));
			}

			// Siguiente turno.
			if (turno)
				turno = false;
			else
				turno = true;

			Console.ReadLine();
		}

		// Compara los puntos y muestra quien ha ganado.
		if (jug1pts > jug2pts)
			Console.WriteLine("¡¡¡El Jugador 1 ha ganado!!!");
		else if (jug2pts > jug1pts)
			Console.WriteLine("¡¡¡El Jugador 2 ha ganado!!!");
		else
			Console.WriteLine("¡¡¡Ha habido un empate!!!");
	}
}
