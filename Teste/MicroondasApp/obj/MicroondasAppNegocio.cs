// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using System.Text;
using System.Linq;

namespace MicroondasAppNegocio{//Elemento relacionado a lógica do aplicativo de micro-ondas.
           /// NÍVEL 1 ///
    public class Microondas{
        //DECLARANDO AS PROPRIEDADES\\
        //Declaração de constantes privadas para garantir que o tempo permitido e o valor da potência estejam sempre fixos, devido a imutabilidade da constante.
        private const int TempoMaximoSegundos = 120; // 2 minutos --> Tempo máximo de operação.
        private const int TempoMinimoSegundos = 1;   // 1 segundo -- > Tempo mínimo de operação.
        private const int PotenciaPadrao = 10; //Potência padrão caso o usuário não informe a quntidade desejada       
        private const int TempoInicioRapido = 30; // Constante para definir o tempo do início rápido, sendo o valor fixo de 30 segundos.

        private int tempoEmSegundos; //Variável privada para armazenar o tempo de aquecimento desejado.
        private int potencia; //Variável privada para a escolha da potência. A potência padrão é 10, dado na variável acima.
        private bool estaPausado; // Variável privada booleana que se verdadeira, permite controlar o aquecimento permitindo pausá-lo.
        private bool estaExecutando;// Esta variável também booleana, faz com que o micro-ondas indique se está havendo a execução do aquecimento.

        public Microondas(){//Construtor da classe Microondas
            Resetar();//Todas as instâncias serão definidas inicialmente por este método.
        }

        public int TempoEmSegundos{ // ---> Método público para acessar e configurar o tempo de aquecimento em segundos
            get => tempoEmSegundos; //Usando o get em forma de atalho para acessar o valor disponível para leitura.
            
            private set{ // ---> Método privado para modificar o tempo com uma condicional simples
                if (value < TempoMinimoSegundos || value > TempoMaximoSegundos){ //Se o valor de tempo desejado for maior que o tempo máximo ou menor que o tempo mínimo.
                     Console.WriteLine($"O tempo deve estar entre {TempoMinimoSegundos} e {TempoMaximoSegundos} segundos." ); // Lança-se uma menságem de exceção.
                     System.Threading.Thread.Sleep(3000);
            
                }else{
                     System.Threading.Thread.Sleep(400);
                     tempoEmSegundos = value;// Se a condicional for atendida, o valor desejado se tornará o de tempoEmSegundos.
                }
            }
       }

        //Outro método público para acessar a potência
        public int Potencia{
            get => potencia; //get semelhante ao método de cima
            private set{
                if (value < 1 || value > 10){// Se o valor menor que 1 ou maior que 10.
                    Console.WriteLine("A potência deve estar entre 1 e 10."); // Mensagem de exceção dizendo a faixa de potência.
                    System.Threading.Thread.Sleep(3000);
                }else{
                    potencia = value; //Com a condicional atendida, o valor pretendido se torna o valor da propriedade privada potência.
                    System.Threading.Thread.Sleep(400);
                }
            }
        }

        //Método público para saber qual o status do aquecimento, se está aquecendo conforme o solicitado.
        public string StatusAquecimento { get; private set; } = string.Empty;// Os getters e setters são automáticos, com o set privado, não tendo sua disponibilidade pública e o campo de texto da string é inicializado vázio.

        
        // Define o tempo de aquecimento
        public void DefinirTempo(int segundos){
            //TempoEmSegundos = segundos;// Chamando a propriedade TempoEmSegundos e atribuindo o valor de tempo desejado, com a validação de tempo permitido garantida.
            TempoEmSegundos = segundos;

        }

        // Define a potência do aquecimento
        public void DefinirPotencia(int potencia){
            Potencia = potencia;//Faz o mesmo que o método acima, so que com a potência, com o usuário atribuindo o valor desejado e ele só sendo possível o determinado de 1 a 10.
        }

         private string FormatarTempo(int segundos) {
            int minutos = segundos / 60;
            int segundosRestantes = segundos % 60;
            return $"{minutos}:{segundosRestantes:D2}";
        }

        // Inicia o processo de aquecimento
        public void Iniciar() {
            if (estaExecutando){ //Se o micro-ondas estiver funcionando, adiciona o TempoInicioRapido que é 30 segundos.
                AdicionarTempo(TempoInicioRapido);
                return;
            }

            if (tempoEmSegundos == 0)//Se o tempo passado for 0 (ou não for passado), se assume o TempoInicioRapido, ou seja, 30 segundos.
                TempoEmSegundos = TempoInicioRapido;

            if (potencia == 0)//Se a potência for 0 (ou não for passado a quantidade de potência), a potência será a padrão que é 10.
                Potencia = PotenciaPadrao;

            estaExecutando = true;
            estaPausado = false;
            StatusAquecimento = "Aquecimento iniciado.";// Com o aquecimento em andamento, o método StatusAquecimento preenche sua variável string vazia com a mensagem.
            Console.WriteLine(StatusAquecimento);
            Console.WriteLine("Pressione 4 duas vezes para pausar/cancelar o aquecimento."); //Aparece no início da execução para avisar qual botão clicar para ter a pausa.
            SimularAquecimento();//Simulando o aquecimento.                                
        }

        // Pausa ou cancela o aquecimento -- método usado para pausar ou cancelar o aquecimento
        public void PausarOuCancelar(){
            if (!estaExecutando){// Se o micro-ondas não está em execução, ele é resetado diretamente.
                Resetar();
                return;
            }

            if (estaPausado){//Se pausar o funcionamento e não retomar, o atributo estaPausado é true, a máquina é resetada.
                Resetar();
                return;
            }
            estaPausado = true;
            StatusAquecimento = "Aquecimento pausado.";// Imprime outra mensagem em StatusAquecimento, agora do estado pausado.
            Console.WriteLine(StatusAquecimento);
            Console.WriteLine("Se deseja retomar clique 5, cancelar 4");
        }

        // Retoma o aquecimento após pausa
        public void Retomar(){
            if (estaPausado){//Se o aparelho está pausado porém se continua o aquecimento, estaPausado se torna false e há prosseguimento de atividade.
                estaPausado = false;
                StatusAquecimento = "Aquecimento retomado.";//Assim a mensagem imprimida será de que o aquecimento retornou.
                Console.WriteLine(StatusAquecimento);
            }
        }

        // Adiciona tempo ao aquecimento em andamento
        private void AdicionarTempo(int segundos){
            if (tempoEmSegundos + segundos > TempoMaximoSegundos)//Se o tempo passado total for maior que o tempo máximo permitido:
                TempoEmSegundos = TempoMaximoSegundos;// O tempo será o valor máximo(120)
            else
                TempoEmSegundos += segundos;//Senão, incremente o tempo com os segundos fornecidos.
        }

        // Simula o processo de aquecimento
        private void SimularAquecimento(){
            var output = new StringBuilder();//Declarando uma variável com tipo implicito que tem como atribuição uma string de saída que representa visualmente o aquecimento. 
            for (int i = 1; i <= tempoEmSegundos; i++){// Faça funcionar pelo número de segundos configurados pelo usuário.

               //Comando para acrescentar mais 30 segundos ao tempo se clicar iniciar. 
               if(Console.KeyAvailable) {
                    var key = Console.ReadKey(intercept: true).Key; // Lê a tecla pressionada
                    if (key == ConsoleKey.D1) { // Tecla "1" para retomar
                        TempoEmSegundos += TempoInicioRapido; // Se acrescenta mais 30 segundos ao tempo
                        Console.WriteLine("Mais 30 segundos");
                    }
                }
               
                if (estaPausado) break;// Se houver pausa, se interrope o laço.
   
                    // Verifica se uma tecla foi pressionada
                    if (Console.KeyAvailable) {
                        var key = Console.ReadKey(intercept: true).Key; // Lê a tecla pressionada
                        if (key == ConsoleKey.D4) { // Tecla "4" para pausar/cancelar
                            PausarOuCancelar();
                            
                                
                            // Espera pela entrada do usuário para retomar ou cancelar
                            while (estaPausado) {
                                if (Console.KeyAvailable) {
                                    var subkey = Console.ReadKey(intercept: true).Key; // Lê a tecla pressionada
                                    if (subkey == ConsoleKey.D5) { // Tecla "5" para retomar
                                        Retomar();
                                    } else if (subkey == ConsoleKey.D4) { // Tecla "4" para cancelar
                                        Resetar();
                                        return;
                                    }
                                }
                            }
                        }
                   }

                output.Append(new string('.', Potencia));// Adiciona à string uma quantidade de pontos referênciando a potência.
                StatusAquecimento = output.ToString();// Atualiza o status com a string gerada até o momento.
                Console.WriteLine($"{FormatarTempo(i)} - {StatusAquecimento}");
                System.Threading.Thread.Sleep(1000); // Simula 1 segundo por iteração
            }

           if(!estaPausado){
                StatusAquecimento = " Aquecimento concluído.";//Se o processo não ter pausa, adiciona a mensagem ao status.
                Console.WriteLine(StatusAquecimento);
                System.Threading.Thread.Sleep(3000); // Pausa a execução por 5 segundos (3000 milissegundos) para aparecer a mensagem
                estaExecutando = false;// E então o micro-ondas é marcado como não funcionando.
            }    
        }

        // Reseta as configurações do micro-ondas
        public void Resetar(){//  Método privado que redefine todas as variáveis do micro-ondas para seus valores padrão.
            tempoEmSegundos = 0;
            potencia = 0;
            estaExecutando = false;
            estaPausado = false;
            StatusAquecimento = "";
        }

        
    }
}
