using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using backPadaria.Model;

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

            // 1 - IDENTIFICAÇÂO DO FUNCIONÀRIO.
            int funcionarioID = 2;

            // 2 - IDENTIFICAÇÂO DO CLIENTE.
            Console.WriteLine("ID do cliente (Pressione ENTER se nâo quiser identificar)");

            int idCliente = 0;
            int.TryParse(Console.ReadLine(), out idCliente);

            Cliente? clienteVenda = Cliente.ListarPorId(idCliente);


            // -- Inicializando o objeto compra.
            Compra compraAtiva = new Compra(DateTime.Now, funcionarioID, clienteVenda.Id);


            // Loop do carrinho de compra.                                                                        
            bool adicionarMais = true;

            while (adicionarMais)
            {

                Console.WriteLine("\n----- Adicionar Produto -----");
                Console.WriteLine("Id do produto ou '0' para finalizar/pagar");

                int.TryParse(Console.ReadLine(), out int idProduto);

                if (idProduto == 0)
                {
                    adicionarMais = false;
                    // Volta para o começo do laço.
                    continue;
                }

                Produto? produto = Produto.ListarPorId(idProduto);

                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado... Tente novamente");
                    // Volta para o começo do laço.
                    continue;
                }

                Console.Write($"Produto: {produto.Nome} | Preco: {produto.Preco:C} | Quantidade: ");
                int.TryParse(Console.ReadLine(), out int qtdProduto);

                if ( qtdProduto > 0 )
                {   
                    compraAtiva.AdicionarItem(produto, qtdProduto);
                    Console.WriteLine($"Subtotal: {produto.Preco * qtdProduto}");

                } // ENCERRA O LAÇO DE PRODUTOS




                // 3. Checkout

            }

                if( compraAtiva.Itens.Count == 0 )
                {
                    Console.WriteLine("\nVenda cancelada (Nenhum item foi adicionado).");
                }
                else
                {

                    Console.WriteLine("\n------ RESUMO DA VENDA ------");
                    foreach (var item in compraAtiva.Itens)
                    {
                        Console.WriteLine($"ID: {item.ProdutoId} | Qtd: {item.Quantidade} | Preço {item.PrecoCobrado} | Subtotal: {item.CalcularSubtotal():C}");
                    }

                    decimal totalFinal = compraAtiva.CalcularTotal();

                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"TOTAL A PAGAR: {totalFinal:C}");
                    Console.WriteLine("------------------------------");

                }

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
