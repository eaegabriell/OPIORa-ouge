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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario usu = new FormUsuario();
            usu.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente cli = new FormCliente();
            cli.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduto pro = new FormProduto();
            pro.Show();
        }

        private void pbCliente_Click(object sender, EventArgs e)
        {
            FormCliente cli = new FormCliente();
            cli.Show();
        }

        private void pbProduto_Click(object sender, EventArgs e)
        {
            FormProduto pro = new FormProduto();
            pro.Show();
        }

        private void pbUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario usu = new FormUsuario();
            usu.Show();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVenda ven = new FormVenda();
            ven.Show();
        }

        private void pbVendas_Click(object sender, EventArgs e)
        {
            FormUsuario usu = new FormUsuario();
            usu.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
