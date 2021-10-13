/*
 * Created by SharpDevelop.
 * User: Orlando Freitas
 * Date: 2020/2021
 * 
 */
using System;

namespace CalculadoraPolinomios
{
	/// <summary>
	/// Description of Termo.
	/// </summary>

	public class Termo
	{
		#region Atributos/campos da classe
		// Variaveis da classe
		private int grau;
		private int coef;
		
		#endregion
		
		#region Construtor
		/// <summary>
		/// Termo Property
		/// </summary>
		public Termo(int grau, int coef)
		{
			this.grau=grau;
 			this.coef=coef;
		}
		#endregion
		
		#region Propriedades da Classe
		/// <summary>
		/// Grau Property
		/// </summary>
		public int Grau {
			get { return grau; }
			set { grau = value; }
		}
		
		/// <summary>
		/// Coef Property
		/// </summary>
		
		public int Coef {
			get { return coef; }
			set { coef = value; }
		}

		#endregion
		        
		#region Métodos dos Objectos da Classe	
		//Retornar o valor da subtração do grau de dois termos diferentes
		public int CompareTo(Termo outro)
		{
			return this.grau - outro.grau;
		
		}
		//Metodo para retornar os valores do termo com as carateristicas dos graus e coeficientes 
		public override string ToString()
		{
		    if(this.grau == 0){
		         if(coef > 0)
		            return "+"+this.coef; 
		        else
		            return this.coef+"";
		    }
		    else if(this.grau == 1){
		        if(coef > 0)
		            return "+"+this.coef+"x"; 
		        else
		            return this.coef+"x"; 
		    }
		    else {
		        if(this.coef > 0)
		             return "+"+this.coef+"x^"+this.grau;
		        else
		             return this.coef+"x^"+this.grau;
		   
		    }
		    
		}
		#endregion
	}// fim da classe...
}
