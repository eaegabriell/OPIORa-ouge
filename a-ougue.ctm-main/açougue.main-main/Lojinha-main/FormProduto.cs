using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisTDS06
{
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpaCampos_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {
            Produto pro = new Produto();
            List<Produto> produtos = pro.listaproduto();
            dgvProduto.DataSource = produtos;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                int qtde = Int32.Parse(txtQuantidade.Text);
                Produto produto = new Produto();
                produto.Inserir(txtNome.Text, qtde, Convert.ToDecimal(txtValor.Text));
                MessageBox.Show("Produto cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Produto> pro = produto.listaproduto();
                dgvProduto.DataSource = pro;
                txtId.Text = "";
                txtNome.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtId.Text);
                int qtde = Int32.Parse(txtQuantidade.Text);
                Produto produto = new Produto();
                produto.Atualizar(id, txtNome.Text, qtde, Convert.ToDecimal(txtValor.Text));
                MessageBox.Show("Produto atualizado com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Produto> pro = produto.listaproduto();
                dgvProduto.DataSource = pro;
                txtId.Text = "";
                txtNome.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtId.Text);
                Produto produto = new Produto();
                produto.Exclui(id);
                MessageBox.Show("Produto excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Produto> pro = produto.listaproduto();
                dgvProduto.DataSource = pro;
                txtId.Text = "";
                txtNome.Text = "";
                txtQuantidade.Text = "";
                txtValor.Text = "";
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtId.Text);
                Produto produto = new Produto();
                produto.Localiza(id);
                txtNome.Text = produto.nome;
                txtQuantidade.Text = Convert.ToString(produto.quantidade);
                txtValor.Text = Convert.ToString(produto.valor);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
