using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstoqueSimples
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Obtém a lista de produtos do arquivo
            //List<Produto> listaProdutos = ProdutoDAO.GetProdutos();
            List<Produto> listaProdutos = new List<Produto>();


            // Verifica se a lista de produtos está vazia
            if (listaProdutos.Count == 0)
            {
                MessageBox.Show("Não há produtos disponíveis.");
            }
        }
    }
}
