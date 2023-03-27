using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstoqueSimples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        private List<Produto> listaProdutos = new List<Produto>();

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto
            {
                Nome = txtNome.Text,
                Marca = txtMarca.Text,
                Categoria = txtCategoria.Text,
                Preco = (double)decimal.Parse(txtPreco.Text)
            };

            listaProdutos.Add(produto);
            dataGridView1.DataSource = null; // Limpa a fonte de dados atual
            dataGridView1.DataSource = listaProdutos; // Define a fonte de dados atualizada

            // Limpa os campos de texto após a adição do produto.
            txtNome.Text = "";
            txtMarca.Text = "";
            txtCategoria.Text = "";
            txtPreco.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = listaProdutos;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index; // Obtém o índice da linha selecionada
                Produto produto = listaProdutos[index]; // Obtém o produto correspondente na lista de produtos

                // Atualiza os campos de edição com os valores do produto
                txtNome.Text = produto.Nome;
                txtMarca.Text = produto.Marca;
                txtCategoria.Text = produto.Categoria;
                txtPreco.Text = produto.Preco.ToString();
            }
            else
            {
                MessageBox.Show("Selecione uma linha para editar.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Produto produto = dataGridView1.SelectedRows[0].DataBoundItem as Produto;
                listaProdutos.Remove(produto);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaProdutos;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index; // Obtém o índice da linha selecionada
                Produto produto = listaProdutos[index]; // Obtém o produto correspondente na lista de produtos

                // Mostra as informações do produto nos campos de edição
                txtNome.Text = produto.Nome;
                txtMarca.Text = produto.Marca;
                txtCategoria.Text = produto.Categoria;
                txtPreco.Text = produto.Preco.ToString();
            }
        }
    }
}
