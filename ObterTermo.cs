/*
 * Created by SharpDevelop.
 * User: Orlando Freitas
 * Date: 2020/2021
 */
using System;

namespace CalculadoraPolinomios
{
	/// <summary>
	/// Description of ObterTermo.
	/// </summary>
	public class ObterTermo
	{
		private int maiorGrau;//variavel para defenir o tamanho do vetor.
		
		public int MaiorGrau 
		{
			get { return maiorGrau; }
			set { maiorGrau = value; }
		}

		//Metodo para verificar se os carateres inseridos, são validos 
		public bool StringResult(string imput,string carateres)
		{
			    foreach (char c in imput)
			    {
			    	if (carateres.IndexOf(c) == -1) //IndexOf , verifica a 1º ocorrencia do carater passado 
			    	{
			    		return false;
			      	}
			    }
			    return true;
		}
		
		//Metodo para recolher os termos que formam os polinomios
		public string ObterString()
		{
			Console.WriteLine("Inserir termo a termo,Ex:'3x^4' ou '-4x' ou '23', para terminar colocar '='.");
			string termoinput = "";
			this.MaiorGrau = 1;
			string Equa = "";
			while(termoinput != "=")
            {
                Console.WriteLine("Insira um termo");
                termoinput = Console.ReadLine();
                
				string carateresvalidos = "0123456789+-x^"; //Carateres validos para formar os termos
			    
				bool result = StringResult(termoinput,carateresvalidos);//Verificar se o careteres são validos
			    if(result == true)
			    {
			    	if(termoinput.Contains("^") == true)//Verificar se foi passado o carater'^' que indica o grau do termo
			    	{
			    		//Converter para inteiro uma substring, criada apartir da posiçao que indica o carater'^', que corresponde ao valor do grau
			    		int g = Convert.ToInt32(termoinput.Substring(termoinput.IndexOf("^") +1));
			    		if(MaiorGrau < g) //Guardar o maior grau 
			    			MaiorGrau = g;
			    		
			    	}
			    	
			    	Equa = termoinput +";"+ Equa;//Criar uma String com os termos separados por ';'
			    }
			    else
			    {
			    	if(termoinput != "=")
			    		Console.WriteLine("Termo invalido...");
			    }
			}
			Console.WriteLine("Fim da inserção de termos...");
			
			string carateresvalidos2 = "+-x^;=";
			bool result2 = StringResult(Equa,carateresvalidos2);//Verificar se exite uma valor numerico.
			if(result2 == true)
			{
				Equa = "";// Colocar a tring em vazio
				Console.WriteLine("Termo invalido...");
			}
				
			
			return Equa;
		}
		
		public int[] ObterVetor(String Equa)
		{
			string[] termo = Equa.Split(';'); //Criar um vetor de string, com as string criadas pela separaçao de uma outra, pelos numero de carateres';' que existirem 
			int[] vetor = new  int [MaiorGrau + 1];//Criar um vetor de inteiros, om o tamanho da variavel correspondente ao maior grau passado na intrução dos termos 
			foreach (string term in termo)
			{
				if(term != ""){
				   if(term.Contains("^") == true)
				   { // Se conter o carater '^' correspondente ao grau, separa e criar outro vetor 
			       		string[] str = term.Split('^');
				        if(str[0].Contains("x") == true)
				        { //Se conter o carater 'x' correspondente à variavel, separa para retira o valor do coeficiente 
				            string [] t= str[0].Split('x');
				            string coef =t[0];
				            if(coef == "") //se estiver vazio, o valor é 1
				            	coef = "1";
				            else if(coef == "-") //se estiver só o sinal '-', o valor é -1
				            	coef = "-1";
				            int valorcoef = vetor[Convert.ToInt32(str[1])];//Copiar o valor do vetor na posição do grau
				            if(valorcoef != 0) //Se o valor foi diferente de 0, é porque ja exite um termo com o mesmo grau e então somamos o valor com o valor convertido da string
				            	valorcoef += Convert.ToInt32(coef);
				            else 
				            	valorcoef = Convert.ToInt32(coef); //Copiar o valor convertido da string
				            vetor[Convert.ToInt32(str[1])] = valorcoef; //Inserir no vetor o valor do correspondente do coeficiente na posição correta
				        }
				        else
				        {//Se conter o carater 'x' correspondente à variavel, mas conter o carater '^' correspondente ao grau, vamos fazer a conta para colocar na posiçao do grau 0, que é a posiçao correta
					        double dvalor = Math.Pow (Convert.ToDouble(str[0]),Convert.ToDouble(str[1]));
					        int valor = vetor[0];//Copiar o valor do vetor na posição do grau
				            if(valor != 0) //Se o valor foi diferente de 0, é porque ja exite um termo com o mesmo grau e então somamos o valor com o valor convertido da string
				            	valor += Convert.ToInt32(dvalor);
				            else 
				            	valor = Convert.ToInt32(dvalor);//Copiar o valor convertido da string
				            vetor[0] = valor; //Inserir no vetor o valor do correspondente do coeficiente na posição correta
				        
				        }
				   }
				   else
				   { 
				      if(term.Contains("x") == true)
				      { //Não contem o carater '^' correspondente ao grau, mas contem o carater 'x' correspondente à variavel
				            string [] t= term.Split('x');//Separa para retira o valor do coeficiente 
				            string coef =t[0];
				            //Os passos seguintes já foram anteriormente explicados
							if(coef == "")
								coef = "1";
							if(coef == "-")
								coef = "-1";
							int valor = vetor[1];
				            if(valor != 0)
				            	valor += Convert.ToInt32(coef);
				            else
				            	valor = Convert.ToInt32(coef);
				            vetor[1] = valor;
				        } 
				        else{
							int valor = vetor[0];
				            if(valor != 0)
				            	valor += Convert.ToInt32(term);
				            else
				            	valor = Convert.ToInt32(term);
				            vetor[0] = valor;
					        	
				        }
				   }

				}
			}
		return vetor; //Retornar o vetor com os valores nas posicoes correspondentes aos graus
		}
	
	}
}