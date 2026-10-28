using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria.Service
{
    public static class VendaService
    {

        public static void MenuVendas()
        {
            // sair recebe 'false'.
            bool sair = false;


            // Enquanto sair = 'false'.
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("===== PDV - Padaria Pão & Cia ===== ");
                Console.WriteLine("1 - Iniciar nova venda");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine(" ===================================");


                Console.Write("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.Clear();


                try
                {

                    switch (opcao)
                    {

                        case "1":
                            IniciarNovaVenda(); break;
                        case "0":
                            sair = true; break;
                        default:
                            Console.WriteLine("opção Inválida."); break;

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERRO] na venda {ex.Message}");
                    PressioneParaContinuar();
                }

            }

        }//

       
        public static void IniciarNovaVenda()
        {

            Console.WriteLine("------ NOVA VENDA ------");

            // 1 


        }





         private static void PressioneParaContinuar()
         { 
            Console.WriteLine("\nPressione qualquer tecla para continuar:");
            Console.ReadKey();
         }


        //Perfumaria
        private static void VoltarParaOMenu()
        {
            Console.Write("\nPressione qualquer tecla para voltar ao menu principal:");
            Console.ReadKey();
            Console.Clear();
        }



        // Método auxiliar apenas para pausar antes de limpar a tela no loop
        private static void PressionarParaTentarNovamente()
        {
            Console.Write("\nPressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
        }

    }

}
