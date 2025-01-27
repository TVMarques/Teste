using System;

using MicroondasAppNegocio; // Namespace da classe MicroondasAppNegocio.
using MicroondasAppProgramas;// Namespace da classe MicroondasAppProgramas.

namespace MicroondasAppInterface {// Namespace para a interface do micro-ondas, ou seja, a parte do código que interage com o usuário.

    class Program{
        static void Main(string[] args){
            Console.WriteLine("Bem-vindo ao Micro-ondas Simulado!");
            var microondas = new Microondas();// Criando uma instância da classe Microondas do namespace MicroondasAppNegocio.
            string opcao; //Variável para possibilitar a escolha do usuário no menu.

            do{//Loop Do-While com as opções do menu.
                Console.Clear();
                Console.WriteLine("=== MENU MICRO-ONDAS ===");
                Console.WriteLine("1. Iniciar aquecimento");
                Console.WriteLine("2. Configurar tempo");
                Console.WriteLine("3. Configure a potência");
                Console.WriteLine("4. Pausar/Cancelar aquecimento");
                Console.WriteLine("5. Retomar Aquecimento");
                Console.WriteLine("6. Resetar");
                Console.WriteLine("7. Exibindo Programas Prédefinidos");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao){//Também um switch/case para avaliar a opção escolhida pelo usuário e executa o código correspondente dos outros namespaces para àquela opção.
                     case "1":
                        microondas.Iniciar();
                        break;

                    case "2":
                        Console.Write("Informe o tempo em segundos (1-120): ");
                        if(int.TryParse(Console.ReadLine(),out int tempo)){
                            microondas.DefinirTempo(tempo);
                        }
                        break;
                    
                    case "3":
                         Console.Write("Informe a potência (1-10): ");
                            if (int.TryParse(Console.ReadLine(), out int potencia)){
                                microondas.DefinirPotencia(potencia);
                            }
                        break;
                        
                    case "4":
                        microondas.PausarOuCancelar();
                        break;

                    case "5":
                        microondas.Retomar();
                        break;

                    case "6":
                        microondas.Resetar();
                        break;

                    case "7":
                        ExibirProgramasPredefinidos();
                        break;
                    
                    case"8":
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != "8");

            static void ExibirProgramasPredefinidos() {//Função própria desta interface que exibe os programas pré-definidos armazenados na lista em PogramasPreDefinido retornada por DefinindoProgramas.GetPrograms()
            Console.Clear();
            Console.WriteLine("=== PROGRAMAS PREDEFINIDOS ===");
            var programas = DefinindoProgramas.GetPrograms();

            foreach (var programa in programas) {
                Console.WriteLine($"\nNome: {programa.Nome}");
                Console.WriteLine($"Alimento: {programa.Alimento}");
                Console.WriteLine($"Tempo: {programa.TempoEmSegundos} segundos");
                Console.WriteLine($"Potência: {programa.Potencia}");
                Console.WriteLine($"String de Aquecimento: {programa.StringDeAquecimento}");
                Console.WriteLine($"Instruções: {programa.Instrucoes}");
            }
             Console.WriteLine();
             Console.WriteLine();
             Console.WriteLine("Pressione qualquer tecla para voltar...");///Após exibir os programas, como não consegui progredir mais no desenvolvimento, faço ter pressione a tecla para voltar ao menu.
             Console.ReadKey();
         }
      }   
    }
}
