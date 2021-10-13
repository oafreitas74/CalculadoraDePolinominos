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
	/// Description of Polinomio.
	/// </summary>
	public class Polinomio
	{
		#region Atributos/campos da classe
		// Variaveis da classe
									
		private int numTermos=0; 	// Quantos elementos estão na lista
		private int grau = 0;		// Qual o grau de maior valor
		private Nodo inicio;  		// Onde começa a lista propriamente dita
		private Nodo atual;  		// Manter informação para quando percorrer a lista
		#endregion
		
		#region Construtores
		//Construtor que cria objeto do tipo Polinómio vazio (sem termos).
		public Polinomio()
		{
			this.grau=0;
			this.numTermos=0;
			this.inicio = null;
            this.atual = null;
		}
		
		//Construtor que cria um objeto do tipo Polinómio com os coeficientes passados por argumento.
		public Polinomio(params int[] coef)
		{
			//Inverter o "for", para quando termo for inserido no inicio da lista, estar na posição de maior grau primeiro
            for (int g=coef.Length-1;g>=0;g--)
            {
				if(coef[g] != 0) //Todos os valores em "0" não são adicionados à lista.
				{
					Termo Tnovo = new Termo(g,coef[g]);
					Nodo Nnovo = new Nodo(Tnovo);
					Nnovo.Next= this.inicio;
					if (this.inicio!=null)
						this.inicio.Prev = Nnovo;	 

					this.inicio=Nnovo;	 
					this.numTermos++;
				}

            }
           this.Grau= coef.Length -1;//o Tamanho do vetor -1, é o valor de maior grau // VAI DAR ERRADO SE COEFICIENTE for 0 do maior ;)
		}
		#endregion
		
		#region Propriedades da Classe
		//Método que permite acrescentar um novo termo ao polinómio.
		public void AddTermo(int grau, int coef)
		{
			//Verificar se existe um termo com o mesmo grau e eliminar o existente.
			// NÃO É O PRETENDIDO!!!!! - O termo tem que ser atualizado
			this.atual = this.inicio;
			while(this.atual != null)
	 		{
			 	if(this.atual.Elemento.Grau == grau)
			 		this.RemoveTermo(grau);
			 	else
	 				this.atual=this.atual.Next;
	 		}
			
			Termo Tnovo = new Termo(grau,coef);
			Nodo Nnovo = new Nodo(Tnovo);
			Nnovo.Next= this.inicio;
			//Inserir no inicio se a lista estiver vazia ou se o novo termo tem o grau mais baixo.
			//Ao ser chamada o metodo 'CompareTo', é feita uma subtraçao de graus de dois termos 
			// se o resultado for menor que 0, significa que o 1º grau e que o 2º(passado por referencia )
			if(this.inicio==null || Tnovo.CompareTo(this.inicio.Elemento)<0)
			{
				if (this.inicio!=null)
					this.inicio.Prev = Nnovo;	
				this.inicio=Nnovo;
			}
			//Inserir no meio ou fim da lista
			//Precorrer a lista até encontrar um termo com o grau superior ao novo ou chegar ao fim.
			Nodo aux = this.inicio;
			while (aux.Next!=null && Tnovo.CompareTo(aux.Next.Elemento)>0)
				aux = aux.Next;
			
			//Depois de encontra a posição, vamos inserir o novo termo
			Nnovo.Next= aux.Next; //a informação do apontador para nodo seguinte e passado o apontador novo seguinte
			Nnovo.Prev= aux; // a informação do nodo e passado para o apontador anterior do novo nodo
			aux.Next= Nnovo; //o apontador para o nodo seguinte,passa a guardar a nformaçao do nodo novo
			
			if (Nnovo.Next!=null) //Se existir algum mais algum termo inserir no meio
	 			Nnovo.Next.Prev = Nnovo;
			
			if(this.Grau < grau) //atualizar o valor se o novo termo tem um grau maior que os restantes
				this.Grau = grau;
 			this.numTermos++; //Atualizar o nº de termos da lista
		}
	//Método que permite acrescentar um novo termo no inicio ao polinómio.
		public void AddTermoInicio(int grau, int coef)
		{
			
			Termo Tnovo = new Termo(grau,coef);
			Nodo Nnovo = new Nodo(Tnovo);
			Nnovo.Next= this.inicio;
			
			if (this.inicio!=null)
				this.inicio.Prev = Nnovo;	
			this.inicio=Nnovo;
			this.Grau = 0;
			while(this.atual != null)
			{
				if(this.atual.Elemento.Grau<=this.Grau)
					this.Grau = this.atual.Elemento.Grau;
			
				this.atual=this.atual.Next;
			}
			this.numTermos++; // atualizar o nº de termos.
		}
		//Método que retira do polinómio o termo de grau igual ao passado por argumento.
		public void RemoveTermo(int grau)
		{
			//Verificar se existe termo com o mesmo grau:
			bool existe = false;
			this.atual = this.inicio;
			while(this.atual != null)
	 		{
			 	if(this.atual.Elemento.Grau == grau)//Comparar o grau dos termos da lista com o grau passado para remover
			 		existe = true;
	 			this.atual=this.atual.Next;
	 		}
			if(existe == true) // Se existe, vai procurar e eliminar
			{
				Termo novo = new Termo(grau,1);
				  this.atual = this.inicio;	 
				  //Precorer a lista toda até encontrar o termo tem o grau igual ao passado.
				  //Na função CompareTo é feita uma subtração entre graus, quando o resultado for igual  0, são iguais e para a procura.
				 while (this.atual!=null && this.atual.Elemento.CompareTo(novo)!=0)
				 	this.atual = this.atual.Next;
			
				if (this.atual==this.inicio)
				 {
				   this.inicio = this.inicio.Next;
				   if (this.inicio!=null) 		
						this.inicio.Prev= null;	
				
				 }
				
				(this.atual.Prev).Next = this.atual.Next;
				if (this.atual.Next!=null)
					(this.atual.Next).Prev = this.atual.Prev;
				
				this.numTermos--; // atualizar o nº de termos.
				
				if(this.Grau == grau)//Verificar se o termo eliminado e igual ao maior grau 
				{// Se for igual, vamos atualizar o maior Grau, precorrendo a lista para encontrar o maior grau
					this.atual = this.inicio;
					this.Grau = 0;
					while(this.atual != null)
					{
						if(this.atual.Elemento.Grau>this.Grau)
							this.Grau = this.atual.Elemento.Grau;
					
						this.atual=this.atual.Next;
					}
				}
				Console.WriteLine("O termo com o grau {0}, foi removido com sucesso.",grau);	// NÂO DEVIAM ESTAR aQUI :(
			 }
			 else
			 	Console.WriteLine("O termo com o grau {0},  nao se encontra na lista.",grau);
			 
		}
		
		//Propriedade de leitura que devolve o grau do Polinómio.
		public int Grau {
			get { return grau; }
			set { grau = value; }
		}
		
		//Propriedade de leitura que devolve o número de termos que o Polinómio tem.
		public int NumTermos {
			get { return numTermos; }
			set { numTermos = value; }
		}
		#endregion
		        
		#region Métodos dos Objectos da Classe	
		//Método que calcula o valor real do polinómio para o argumento recebido.
		public double Valor(double vx)
		{
			double resultado =0;
			Nodo aux = this.inicio;
	 		while(aux != null)
	 		{//Calcular pelo metotodo 'Math.Pow', o valor real por todos os graus da lista e depois multiplicar pelo seu coeficiente
	 			resultado += Math.Pow(vx,aux.Elemento.Grau)*aux.Elemento.Coef;
	 			aux=aux.Next;
	 		}
			return resultado;
		}
		
		
		//Método que devolve o polinómio na forma de string de acordo com o seguinte formato: -2x^5 + 3x^2 – x + 6
		public override string ToString()
		{//Criar um vetor com quantidade de termos da lista e precorrer a lista toda para copiar para o vetor
			Termo[] vector =new Termo[this.numTermos];
			Nodo aux = this.inicio;
			int i=0;
            while(aux != null)
            {
                vector[i] = aux.Elemento;
				 aux=aux.Next;
				 i++;
            }
            string str = "";//
            for (i=0;i<this.numTermos;i++)
            	str= vector[i]+ str;
			return str;
		}
		 //Criar um array da lista, este metodo nao estava pedido, mas só foi criado para facilitar noutros metodos 
		public int[] ToArray(int Tam)
		{
			int[] vaux = new int [Tam];
			Nodo Naux = this.inicio;
			while(Naux != null)
	 		{
				vaux[Naux.Elemento.Grau]= Naux.Elemento.Coef;//Preencher o vetor nas posições que está formada a lista
				Naux=Naux.Next;
	 		}
			return vaux;
		}
		
		//Método que cria uma “cópia” do Polinómio.
		public Polinomio Clone()
		{	
			Nodo Naux = this.inicio;
			int[] vec = this.ToArray(this.Grau+1);//Criar um vetor de int com o tamaho do maior grau
	 		
			//Criar novo Polinimio com o vetor criado.
			Polinomio Paux = new Polinomio(vec);
			return Paux;
						
		}
		
		//Realiza a operação de soma de polinómios, devolvendo o resultado como um novo Polinómio.
		public static Polinomio operator +(Polinomio P1, Polinomio P2)
		{
			int Tam = 0;
			if(P1.Grau >= P2.Grau)//verificar qual o polinómio de maior grau para serem criados os vetores com o mesmo tamanho
				Tam = P1.Grau +1;
			else
				Tam = P2.Grau +1;
			
			int[] vec1 = P1.ToArray(Tam);//Criar um array do polinómio
			int[] vec2 = P2.ToArray(Tam);//Criar um array do polinómio
			int[] vec3 = new int [Tam];	//Inicializar um array para guardar a soma dos polinómios
			
			for(int i=0;i<Tam;i++)
			{
				if(vec1[i] !=0 && vec2[i] !=0)//Se a mesma posição nos vetores têm valores diferente de 0 
					vec3[i]=vec1[i]+vec2[i]; //entao fazemos a soma desses valores 
					
				else if(vec1[i] !=0 && vec2[i] ==0)//Para quando as posições só têm valores num dos vetores
					vec3[i]=vec1[i];
					
				else if(vec1[i] ==0 && vec2[i] !=0)
					vec3[i]=vec2[i];
				
			}
			
			Polinomio Paux = new Polinomio(vec3); //Criar um novo Polinómio apartir do vetor criado anteriormente	
			return Paux;
		}
		
		//Realiza a operação de subtração de polinómios, devolvendo o resultado como um novo Polinómio.
		public static Polinomio operator -(Polinomio P1, Polinomio P2)
		{//O processo é igual ao da soma, só altera na operação entre os valores
			int Tam = 0;
			if(P1.Grau >= P2.Grau)
				Tam = P1.Grau +1;
			else
				Tam = P2.Grau +1;
			
			int[] vec1 = P1.ToArray(Tam);
			int[] vec2 = P2.ToArray(Tam);
			int[] vec3 = new int [Tam];	//Inicializar um array para guardar a subtração dos polinómios
			
			for(int i=0;i<Tam;i++)
			{
				if(vec1[i] !=0 && vec2[i] !=0)
					vec3[i]=vec1[i]-vec2[i];
					
				else if(vec1[i] !=0 && vec2[i] ==0)
					vec3[i]=vec1[i];
					
				else if(vec1[i] ==0 && vec2[i] !=0)
					vec3[i]=vec2[i];
				
			}
			
			Polinomio Paux = new Polinomio(vec3);	
			return Paux;
		}
			
		//Realiza a operação de multiplicação de polinómios, devolvendo o resultado como um novo Polinómio.
		public static Polinomio operator *(Polinomio P1, Polinomio P2)
		{ //Criar array do polinómios
			Polinomio Paux = new Polinomio();
			int[] vec1 = P1.ToArray(P1.Grau+1);
			int[] vec2 = P2.ToArray(P2.Grau+1);

			//Precorrer os vetores e sempre que o valor ser diferente de 0, recolher os resultados e acresentar no inicio do polinómios
			for(int i=0;i<P1.Grau+1;i++)
				if(vec1[i] !=0)
					for(int y=0;y<P2.Grau+1;y++)
	                    if(vec2[y] !=0)
	                    	Paux.AddTermoInicio(i+y,vec1[i]*vec2[y]);


			return Paux;
			
		}
		 
		//Realiza a operação de multiplicação entre um polinómio e um valor inteiro,
		public static Polinomio operator *(Polinomio P1, int escalar)
		{
			
			
			Polinomio Paux = new Polinomio();	
			int[] vec1 = P1.ToArray(P1.Grau+1);
			for(int i=P1.Grau;i>=0;i--)
				if(vec1[i] !=0)
					Paux.AddTermoInicio(i,vec1[i]*escalar);
			
			return Paux;
		}
	/*
		//calcula a divisão de dois polinómios, devolvendo o quociente e resto da divisão dos polinómios.
		public static Polinomio operator /(Polinomio P1, Polinomio P2)
		{	
		}
		 */
		//converter uma string num objeto do tipo Polinómio.
		public static bool TryParse(string strPol,out Polinomio result)
		{
			string termo ="";
	       	int MaiorGrau = 1;
	       	int g=0;
			//Precorrer a string e procurar os sinais '+' e '-', para acrecentar antes do sinal um ';'
			//para assim fazer a separação de cada termo 
	        for(int i=0;i<strPol.Length;i++)
	        {
				if(strPol[i].Equals('+') || strPol[i].Equals('-'))
				    termo += ";"+strPol[i];
				else
				    termo +=strPol[i];
				if(strPol[i].Equals('^'))
				{//No mesmo for aproveito para verificar qual é o maior grau existente
					g= (int)char.GetNumericValue(strPol[i+1]);
					if(MaiorGrau < g)  
						MaiorGrau =  g;
				}
	        }
		   
		    
		    string[] termovec = termo.Split(';');//Criar um vetor de string, com as string criadas pela separaçao de uma outra, pelos numero de carateres';' que existirem 
		    int[] vetor = new  int [MaiorGrau+1];//Criar um vetor de inteiros, om o tamanho da variavel correspondente ao maior grau
		    
		    foreach (string term in termovec)
			{
				if(term != "")
				{
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
	    
		    result = new Polinomio(vetor);
		    return true;
		} 
		 
		 
		 
		 
		
		
		#endregion
	}
}
