using System;

namespace AlgoritmosGeneticos
{
	/// <summary>
	/// Descripci�n breve de Flores.
	/// </summary>
	public class Flores
	{
		// Variables necesarias para la clase
		private int x; // Posici'on en la ventana
		private double adaptacion; // Nivel de adaptacion del organismo
		

		// Creamos el cromosoma de la flor
		// 0-Altura
		// 1-Color de la flor
		// 2-Color del tallo
		// 3-Ancho del tallo
		// 4-Tama�o de la flor
		// 5-Tama�o del centro de la flor

		public int[] cromosoma=new int[6];

		// Creamos las propiedades
		public int CoordX 
		{
			set {x=value;}
			get {return x;}
		}

		public double Adaptacion
		{
			set {adaptacion=value;}
			get {return adaptacion;}
		}


		public Flores()
		{
			//
			// TODO: agregar aqu� la l�gica del constructor
			//

			
		}

	

	}
}
