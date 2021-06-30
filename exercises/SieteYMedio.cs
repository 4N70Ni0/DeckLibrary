using System;
using LibraryCards;

public class SieteYMedio
{
	// Se ejecuta cuando uno de los dos oponentes pierde.
	// Jugador: true.
	// Banca: false.
	public static double Derrota(string msg)
	{
		Console.WriteLine(msg);
		return -1.0;
	}

	// Devuelve la opción elegida por el jugador:
	// Robar: true
	// Plantarse: false
	private static bool Turno()
	{
		bool ret = false;
		bool repetir;
		string opt;

		do {
			repetir = false;

			Console.WriteLine ("¿Qué quieres hacer? (R/r)obar, (P/p)lantarse");
			opt = Console.ReadLine();
			opt.ToLower();

			if (opt.Equals("r"))
			{
				Console.WriteLine ("Robando carta");
				ret = true;
			}
			else if (opt.Equals("p"))
			{
				Console.WriteLine ("Plantando");
			}
			else
			{
				Console.WriteLine("Orden no encontrada");
				repetir = true;
			}
		}
		while (repetir);

		return ret;
	}

	// Devuelve el valor de la carta robada de la baraja.
	public static double RobarCarta(Deck baraja)
	{
		Card carta;
		double numero;
		bool continuar;

		do {
			continuar = false;
			carta = baraja.Draw();
			numero = carta.GetNum();

			// J, Q, K valen 0.5.
			if (numero >= 11)
			{
				numero = 0.5;
			}
			// En este juego no hay ni 8 ni 9 ni 10. Volver a sacar carta.
			else if (numero >= 8 && numero <= 10)
			{
				continuar = true;
			}
		}
		while (continuar);

		Console.WriteLine(carta.GetAsciiCard());

		return numero;
	}

	// Turno del jugador. Retornará el total de sus cartas si no se ha pasado.
	public static double Jugador(Deck baraja)
	{
		double jugador = 0;
		bool continuar = true;

		Console.WriteLine ("\nJugador\n--------------------");
		while (continuar && Turno())
		{
			jugador += RobarCarta(baraja);
			//Console.WriteLine("Jugador = {0}", jugador);
			if (jugador > 7.5)
			{
				jugador = Derrota("El Jugador ha sacado más de 7.5\n¡¡¡La Banca gana!!!");
				continuar = false;
			}
		}

		return jugador;
	}


	public static double Banca(Deck baraja)
	{
		double banca = 0;
		bool continuar = true;
		Random rand = new Random();

		Console.WriteLine ("\nBanca\n--------------------");
		while (continuar)
		{
			banca += RobarCarta(baraja);

			// Pequeña IA
			if (rand.Next(0, 2) == 0)
				continuar = false;

			if (banca > 7.5)
			{
				banca = Derrota("La Banca ha sacado más de 7.5\n¡¡¡El Jugador gana!!!");
				continuar = false;
			}
		}

		return banca;
	}


	public static void Main(string[] args)
	{
		double jugador, banca;
		Deck baraja = new Deck();

		baraja.Shuffle();

		// Jugador
		jugador = Jugador(baraja);

		// Si el jugador no ha sacado más de 7.5, se ejecuta el turno de la Banca.
		if (jugador != -1.0)
		{
			// Banca
			banca = Banca(baraja);

			// Si la banca no ha sacado más de 7.5.
			if (banca != -1.0)
			{
				// Si el Jugador ha sacado más que la Banca, gana.
				if (jugador > banca)
				{
					Console.WriteLine("El Jugador gana");
				}
				// Si la Banca ha sacado más que el Jugador o han empatado, gana la Banca.
				else if (banca >= jugador)
				{
					Console.WriteLine("La Banca gana");
				}
			}
		}
	}
}
