using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SisTDS06
{
    public partial class FormVenda : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Lojinha-windows-forms-main\\DbSis.mdf;Integrated Security=True");

        public FormVenda()
        {
            InitializeComponent();
        }

        public void CarregaCbxCliente()
        {
            string cli = "SELECT * FROM cliente";
            SqlCommand cmd = new SqlCommand(cli, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cli, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "cliente");
            cbxCliente.ValueMember = "cpf";
            cbxCliente.DisplayMember = "nome";
            cbxCliente.DataSource = ds.Tables["cliente"];
            con.Close();
        }

        public void CarregaCbxProduto()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            string pro = "SELECT Id, nome FROM [produto]";
            SqlCommand cmd = new SqlCommand(pro, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(pro, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "produto");
            cbxProduto.ValueMember = "Id";
            cbxProduto.DisplayMember = "nome";
            cbxProduto.DataSource = ds.Tables["produto"];
            con.Close();
        }


        private void FormVenda_Load(object sender, EventArgs e)
        {
            if (cbxCliente.DisplayMember == "")
            {
                cbxProduto.Enabled = false;
                txtIdProduto.Enabled = false;
                txtQuantidade.Enabled = false;
                txtPreco.Enabled = false;
                dgvVenda.Enabled = false;
                btnNovoItem.Enabled = false;
                btnEditarItem.Enabled = false;
                btnExcluirItem.Enabled = false;
                txtTotal.Enabled = false;
                btnFinalizarVenda.Enabled = false;
            }
            CarregaCbxCliente();
        }

        private void cbxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [produto] WHERE Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", cbxProduto.SelectedValue);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                txtPreco.Text = rd["valor"].ToString();
                txtIdProduto.Text = rd["Id"].ToString();
                txtQuantidade.Focus();
                rd.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovaVenda_Click(object sender, EventArgs e)
        {
            cbxProduto.Enabled = true;
            CarregaCbxProduto();
            txtIdProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            txtPreco.Enabled = true;
            dgvVenda.Enabled = true;
            btnNovoItem.Enabled = true;
            btnEditarItem.Enabled = true;
            btnExcluirItem.Enabled = true;
            txtTotal.Enabled = true;
            btnFinalizarVenda.Enabled = true;
            dgvVenda.Columns.Add("ID", "ID");
            dgvVenda.Columns.Add("Produto", "Produto");
            dgvVenda.Columns.Add("Quantidade", "Quantidade");
            dgvVenda.Columns.Add("Valor", "Valor");
            dgvVenda.Columns.Add("Total", "Total");
        }

        private void btnNovoItem_Click(object sender, EventArgs e)
        {
            var repetido = false;
            foreach (DataGridViewRow dr in dgvVenda.Rows)
            {
                if (txtIdProduto.Text == Convert.ToString(dr.Cells[0].Value))
                {
                    repetido = true;
                }
            }
            if (repetido == false)
            {
                DataGridViewRow item = new DataGridViewRow();
                item.CreateCells(dgvVenda);
                item.Cells[0].Value = txtIdProduto.Text;
                item.Cells[1].Value = cbxProduto.Text;
                item.Cells[2].Value = txtQuantidade.Text;
                item.Cells[3].Value = txtPreco.Text;
                item.Cells[4].Value = Convert.ToDecimal(txtPreco.Text) * Convert.ToDecimal(txtQuantidade.Text);
                dgvVenda.Rows.Add(item);

                cbxProduto.Text = "";
                txtIdProduto.Text = "";
                txtQuantidade.Text = "";
                txtPreco.Text = "";
                decimal soma = 0;
                foreach (DataGridViewRow dr in dgvVenda.Rows)
                    soma += Convert.ToDecimal(dr.Cells[4].Value);
                txtTotal.Text = Convert.ToString(soma);
            }
            else
            {
                MessageBox.Show("Item já esta listado na venda!", "Repetição", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvVenda.Rows[e.RowIndex];
            cbxProduto.Text = row.Cells[1].Value.ToString();
            txtIdProduto.Text = row.Cells[0].Value.ToString();
            txtQuantidade.Text = row.Cells[2].Value.ToString();
            txtPreco.Text = row.Cells[3].Value.ToString();
        }

        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            int linha = dgvVenda.CurrentRow.Index;
            dgvVenda.Rows[linha].Cells[0].Value = txtIdProduto.Text;
            dgvVenda.Rows[linha].Cells[1].Value = cbxProduto.Text;
            dgvVenda.Rows[linha].Cells[2].Value = txtQuantidade.Text;
            dgvVenda.Rows[linha].Cells[3].Value = txtPreco.Text;
            dgvVenda.Rows[linha].Cells[4].Value = Convert.ToDecimal(txtPreco.Text) * Convert.ToDecimal(txtQuantidade.Text);

            cbxProduto.Text = "";
            txtIdProduto.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            decimal soma = 0;
            foreach (DataGridViewRow dr in dgvVenda.Rows)
                soma += Convert.ToDecimal(dr.Cells[4].Value);
            txtTotal.Text = Convert.ToString(soma);
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            int linha = dgvVenda.CurrentRow.Index;
            dgvVenda.Rows.RemoveAt(linha);
            dgvVenda.Refresh();

            cbxProduto.Text = "";
            txtIdProduto.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            decimal soma = 0;
            foreach (DataGridViewRow dr in dgvVenda.Rows)
                soma += Convert.ToDecimal(dr.Cells[4].Value);
            txtTotal.Text = Convert.ToString(soma);
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("Quantidade_Produto", con);
            cmd.Parameters.AddWithValue("@Id", txtIdProduto.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            int valor1 = 0;
            bool conversaoSucedida = int.TryParse(txtQuantidade.Text, out valor1);
            if (rd.Read())
            {
                int valor2 = Convert.ToInt32(rd["quantidade"].ToString());
                if (valor1 > valor2)
                {
                    MessageBox.Show("Não tem quantidade suficiente em estoque!", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantidade.Text = "";
                    txtQuantidade.Focus();
                    con.Close();
                }
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("InserirPedido", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cpf_cliente", SqlDbType.NChar).Value = cbxCliente.SelectedValue;
            cmd.Parameters.AddWithValue("@valor_total", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTotal.Text);
            cmd.Parameters.AddWithValue("@data_pedido", SqlDbType.Date).Value = DateTime.Now;
            cmd.Parameters.AddWithValue("@situacao", SqlDbType.NChar).Value = "Aberta";
            cmd.ExecuteNonQuery();
            string idvenda = "SELECT IDENT_CURRENT('pedido') AS id_pedido";
            SqlCommand cmdvenda = new SqlCommand(idvenda, con);
            Int32 idvenda2 = Convert.ToInt32(cmdvenda.ExecuteScalar());
            foreach (DataGridViewRow dr in dgvVenda.Rows)
            {
                SqlCommand cmditens = new SqlCommand("ItensPedidos", con);
                cmditens.CommandType = CommandType.StoredProcedure;
                cmditens.Parameters.AddWithValue("@Id_pedido", SqlDbType.Int).Value = idvenda2;
                cmditens.Parameters.AddWithValue("@Id_Produto", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[0].Value);
                cmditens.Parameters.AddWithValue("@Quantidade", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[2].Value);
                cmditens.Parameters.AddWithValue("@preco", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[3].Value);
                cmditens.Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[4].Value);
                cmditens.ExecuteNonQuery();
            }
            con.Close();
            dgvVenda.Rows.Clear();
            dgvVenda.Refresh();
            txtTotal.Text = "";
            MessageBox.Show("Pedido realizado com sucesso!", "Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLocalizarVenda_Click(object sender, EventArgs e)
        {
            CarregaCbxProduto();
            txtTotal.Text = "";
            dgvVenda.Columns.Clear();
            dgvVenda.Rows.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("LocalizarPedido", con);
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int linhas = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                cbxCliente.Enabled = true;
                cbxCliente.Text = "";
                cbxCliente.Text = dt.Rows[0]["nomecliente"].ToString();
                txtTotal.Text = dt.Rows[0]["valor_total"].ToString();
                cbxProduto.Enabled = true;
                txtIdProduto.Enabled = true;
                txtQuantidade.Enabled = true;
                txtPreco.Enabled = true;
                dgvVenda.Enabled = true;
                btnNovoItem.Enabled = true;
                btnEditarItem.Enabled = true;
                btnExcluirItem.Enabled = true;
                txtTotal.Enabled = true;
                btnFinalizarVenda.Enabled = true;
                dgvVenda.Columns.Add("ID", "ID");
                dgvVenda.Columns.Add("Produto", "Produto");
                dgvVenda.Columns.Add("Quantidade", "Quantidade");
                dgvVenda.Columns.Add("Valor", "Valor");
                dgvVenda.Columns.Add("Total", "Total");
                for (int i = 0; i < linhas; i++)
                {
                    DataGridViewRow item = new DataGridViewRow();
                    item.CreateCells(dgvVenda);
                    item.Cells[0].Value = dt.Rows[i]["id_produto"].ToString();
                    item.Cells[1].Value = dt.Rows[i]["nomeproduto"].ToString();
                    item.Cells[2].Value = dt.Rows[i]["quantidade"].ToString();
                    item.Cells[3].Value = dt.Rows[i]["preco"].ToString();
                    item.Cells[4].Value = dt.Rows[i]["total"].ToString();
                    dgvVenda.Rows.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Nenhum pedido localizado com este ID!", "Não localizado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void btnAtualizarPedido_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE pedido SET valor_total = @total WHERE Id = @Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
            cmd.Parameters.AddWithValue("@total", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTotal.Text.Trim());
            cmd.ExecuteNonQuery();

            SqlCommand deletar_itens = new SqlCommand("DELETE FROM itens_pedidos WHERE Id_pedido = @Id", con);
            deletar_itens.CommandType = CommandType.Text;
            deletar_itens.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
            deletar_itens.ExecuteNonQuery();

            foreach (DataGridViewRow dr in dgvVenda.Rows)
            {
                SqlCommand cmditens = new SqlCommand("ItensPedidos", con);
                cmditens.CommandType = CommandType.StoredProcedure;
                cmditens.Parameters.AddWithValue("@id_pedido", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
                cmditens.Parameters.AddWithValue("@id_Produto", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[0].Value);
                cmditens.Parameters.AddWithValue("@quantidade", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[2].Value);
                cmditens.Parameters.AddWithValue("@preco", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[3].Value);
                cmditens.Parameters.AddWithValue("@total", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[4].Value);
                cmditens.ExecuteNonQuery();
            }
            MessageBox.Show("Pedido atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            dgvVenda.Columns.Clear();
            dgvVenda.Rows.Clear();
            txtIdVenda.Text = "";
        }

        private void btnVendaFinal_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE pedido SET valor_total = @total, situacao = @situacao WHERE Id = @Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@total", SqlDbType.Decimal).Value = Convert.ToDecimal(txtTotal.Text.Trim());
            cmd.Parameters.AddWithValue("@situacao", SqlDbType.NChar).Value = "Finalizado";
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
            cmd.ExecuteNonQuery();

            foreach (DataGridViewRow dr in dgvVenda.Rows)
            {
                SqlCommand cmditens = new SqlCommand("ItensVendidos", con);
                cmditens.CommandType = CommandType.StoredProcedure;
                cmditens.Parameters.AddWithValue("@id_pedido", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
                cmditens.Parameters.AddWithValue("@id_Produto", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[0].Value);
                cmditens.Parameters.AddWithValue("@quantidade", SqlDbType.Int).Value = Convert.ToInt32(dr.Cells[2].Value);
                cmditens.Parameters.AddWithValue("@preco", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[3].Value);
                cmditens.Parameters.AddWithValue("@total", SqlDbType.Decimal).Value = Convert.ToDecimal(dr.Cells[4].Value);
                cmditens.ExecuteNonQuery();
            }

            SqlCommand deletar_itens = new SqlCommand("DELETE FROM itens_pedidos WHERE Id = @Id", con);
            deletar_itens.CommandType = CommandType.Text;
            deletar_itens.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(txtIdVenda.Text.Trim());
            deletar_itens.ExecuteNonQuery();

            MessageBox.Show("Venda realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            dgvVenda.Columns.Clear();
            dgvVenda.Rows.Clear();
            txtIdVenda.Text = "";
        }

        private void txtIdVenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPedido_Click(object sender, EventArgs e)
        {

        }
    }
}
