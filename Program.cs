/*
 * Created by SharpDevelop.
 * User: Orlando Freitas
 * Date: 2020/2021
 * 
 */
using System;

namespace CalculadoraPolinomios
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			ObterTermo obter = new ObterTermo();

/*			
			string equacao ="";
			while(equacao.Length < 1) //Condição para ser introduzido um valor valido
			{
				equacao = obter.ObterString();
			}
			int[] vetor1 = obter.ObterVetor(equacao);
			Polinomio p = new Polinomio(vetor1);
			
*/			
			
			Polinomio p = new Polinomio(-7,4,5);
			Console.WriteLine("Polinomio1 = {0}",p.ToString());
			Console.WriteLine("Polinomio1 Nº termos = {0}  Grau = {1}",p.NumTermos,p.Grau);
			Console.WriteLine("valor de p(2) = {0}",p.Valor(2));

			/*
			string equacao2 ="";
			while(equacao2.Length < 1) //Condição para ser introduzido um valor valido
			{
				equacao2 = obter.ObterString();
			}
		
			int[] vetor2 = obter.ObterVetor(equacao2);
			Polinomio p2 = new Polinomio(vetor2);
			
*/			
			Polinomio p2 = new Polinomio(2,-3);
			Console.WriteLine("Polinomio2 = {0}",p2.ToString());
			Console.WriteLine("Polinomio2 Nº termos = {0}  Grau = {1}",p2.NumTermos,p2.Grau);
			
			
/*			
			
			
			p.AddTermo(2,4); 	// VAI ELIMINAR O QUE lÁ ESTÁ :(
			Console.WriteLine("Polinomio1 Adicionado o termo de grau 2,coef 4 ");
			Console.WriteLine("Polinomio1 = {0}",p.ToString());
			Console.WriteLine("Polinomio1 Nº termos = {0}  Grau = {1}",p.NumTermos,p.Grau);
			Console.WriteLine("Polinomio1 calculado com o valor de 2.0-> {0} = {1}",p.ToString(),p.Valor(2.0));
			
			
			p2.AddTermo(2,4);	// VAI ELIMINAR O QUE lÁ ESTÁ :(
			Console.WriteLine("Polinomio2 Adicionado o termo de grau 2,coef 4 ");
			Console.WriteLine("Polinomio2 Nº termos = {0}  Grau = {1}",p2.NumTermos,p2.Grau);
			p2.AddTermo(3,4);
			Console.WriteLine("Polinomio2 Adicionado o termo de grau 3,coef 4 ");
			Console.WriteLine("Polinomio2 = {0}",p2.ToString());
			Console.WriteLine("Polinomio2 Nº termos = {0}  Grau = {1}",p2.NumTermos,p2.Grau);
			p2.AddTermo(3,8);
			Console.WriteLine("Polinomio2 Adicionado o termo de grau 3,coef 8 ");
			Console.WriteLine("Polinomio2 = {0}",p2.ToString());
			Console.WriteLine("Polinomio2 Nº termos = {0}  Grau = {1}",p2.NumTermos,p2.Grau);
			p2.RemoveTermo(7);
			Console.WriteLine("Polinomio2 Tentativa de remover o termo de grau 7");
			
			Console.WriteLine("Polinomio2 = {0}",p2.ToString());
			Console.WriteLine("Polinomio2 Nº termos = {0}  Grau = {1}",p2.NumTermos,p2.Grau);
			
			Console.WriteLine("Polinomio1 Grau = {0} Polinomio2 Grau2 = {1}",p.Grau,p2.Grau);
			Console.WriteLine("Polinomio1 Nº termos = {0} Polinomio2 Nº termos = {1}",p.NumTermos,p2.NumTermos);
			
			Polinomio p3 = p2.Clone();
			Console.WriteLine("Polinomio2 = {0}",p2.ToString());
			Console.WriteLine("Polinomio3 clone de Polinomio2 = {0}",p3.ToString());
			Console.WriteLine("Polinomio3 Nº termos = {0}  Grau = {1}",p3.NumTermos,p3.Grau);
			
*/
			
			Polinomio p4 = p+p2;
			Console.WriteLine("Polinomio4 p+p2 = {0}",p4.ToString());
			Console.WriteLine("Polinomio4 Nº termos = {0}  Grau = {1}",p4.NumTermos,p4.Grau);
			
			Polinomio p5 = p-p2;
			Console.WriteLine("Polinomio5 p-p2 = {0}",p5.ToString());
			Console.WriteLine("Polinomio5 Nº termos = {0}  Grau = {1}",p5.NumTermos,p5.Grau);
			
			Polinomio p6 = p*p2;
			Console.WriteLine("Polinomio6 p*p2 = {0}",p6.ToString());
			Console.WriteLine("Polinomio6 Nº termos = {0}  Grau = {1}",p6.NumTermos,p6.Grau);
			
			Polinomio p7 = p*2;
			Console.WriteLine("Polinomio7 p*2 = {0}",p7.ToString());
			Console.WriteLine("Polinomio7 Nº termos = {0}  Grau = {1}",p7.NumTermos,p7.Grau);
			
			//Polinomio p8 = p2/p;
			//Console.WriteLine("Polinomio8 p*2 = {0}",p8.ToString());
			
			bool result = false;
			string input ="";
			while(result != true)
			{
				string carateresvalidos = "0123456789+-x^";
				Console.WriteLine("Criar o Polinómio através de uma string");
				Console.WriteLine("Inserir o Polinómio,Ex:'3x^4-4x+23'.");
				input = Console.ReadLine();
				result = obter.StringResult(input,carateresvalidos);//validar os carateres através de um metodo que ja tinha criado 
			}
			
			if(result == true)
			{
				Polinomio p9 = new Polinomio();
				if(Polinomio.TryParse(input,out p9 )==true)
					Console.WriteLine("Polinomio9 TryParse = {0}",p9.ToString());
				Console.WriteLine("Polinomio9 Nº termos = {0}  Grau = {1}",p9.NumTermos,p9.Grau);
			}
				
		
			
			
		
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}