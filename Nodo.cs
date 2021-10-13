/*
 * Created by SharpDevelop.
 * User: Orlando Freitas
 * Date: 2020/2021
 */
using System;

namespace CalculadoraPolinomios
{
	/// <summary>
	/// Description of Nodo.
	/// </summary>
	public class Nodo
	{
		#region Atributos/campos da classe
		private Termo elemento; // informação a guardar do termo
		private Nodo next;      // apontador para o nodo seguinte
		private Nodo prev;      // apontador para o nodo anterior
		
		#endregion
		
		
		#region Propriedades da Classe
		public Termo Elemento {
			get { return elemento; }
			set { elemento = value; }
		}
		
		
		public Nodo Next {
			get { return next; }
			set { next = value; }
		}

		
		public Nodo Prev {
			get { return prev; }
			set { prev = value; }
		}
		#endregion
		
		#region Construtor
		
		public Nodo(Termo elemento)
		{
			this.Elemento=elemento;
			this.Next=null;
		}
		#endregion
	}// fim da classe...
}
