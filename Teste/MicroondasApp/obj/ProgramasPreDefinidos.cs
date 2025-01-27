using System.Collections.Generic;//namespace que contém classes relacionadas a coleções genéricas, como listas e dicionários. 

namespace MicroondasAppProgramas{

    ///ELEMENTOS RELACIONADOS AO NÍVEL 2///
    public class DefinindoPrograma{//Classe que serve para representar um programa de micro-ondas com diferentes propriedades.

        //Getters e Setters para definir as propriedades dos programas.
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int TempoEmSegundos { get; set; }
        public int Potencia { get; set; }
        public string StringDeAquecimento { get; set; }
        public string Instrucoes { get; set; }
    }

    public static class DefinindoProgramas{//Classe estática para acessar os métodos sem ser instânciado.
        public static List<DefinindoPrograma> GetPrograms() {//método estático GetPrograms que retorna uma lista de objetos DefinindoPrograma, lista essa que contem os programas pré-configurados do micro-ondas.
            return new List<DefinindoPrograma>{
                //Lista de programas, com Nome, Alimento, TempoEmSegundos e comentário em minutos, StringDeAquecimento e Instrucoes.//
                new DefinindoPrograma{
                    Nome = "Pipoca",
                    Alimento = "Pipoca (de micro-ondas)",
                    TempoEmSegundos = 180, // 3 minutos
                    Potencia = 7,
                    StringDeAquecimento = "*",
                    Instrucoes = "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento."
                },
                new DefinindoPrograma{
                    Nome = "Leite",
                    Alimento = "Leite",
                    TempoEmSegundos = 300, // 5 minutos
                    Potencia = 5,
                    StringDeAquecimento = "~",
                    Instrucoes = "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras."
                },
                new DefinindoPrograma{
                    Nome = "Carnes de boi",
                    Alimento = "Carne em pedaço ou fatias",
                    TempoEmSegundos = 840, // 14 minutos
                    Potencia = 4,
                    StringDeAquecimento = "#",
                    Instrucoes = "Interrompa o processo na metade  e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."
                },
                new DefinindoPrograma{
                    Nome = "Frango",
                    Alimento = "Frango (qualquer corte)",
                    TempoEmSegundos = 480, // 8 minutos
                    Potencia = 7,
                    StringDeAquecimento = "$",
                    Instrucoes = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme."
                },
                new DefinindoPrograma{
                    Nome = "Feijão",
                    Alimento = "Feijão congelado",
                    TempoEmSegundos = 480, // 8 minutos
                    Potencia = 9,
                    StringDeAquecimento = "%",
                    Instrucoes = "Deixe o recipiente destampado  e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas."
                }
            };
        }  
     }
    }
