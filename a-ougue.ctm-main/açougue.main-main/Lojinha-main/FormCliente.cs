using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace SisTDS06
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Inserir(txtCpf.Text,txtNome.Text, txtCep.Text, txtCidade.Text, txtEndereco.Text, txtCidade.Text, txtCelular.Text,txtEmail.Text, dtpDtNascimento.Value);
                MessageBox.Show("Cliente cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Cliente> cli = cliente.listacliente();
                dgvCliente.DataSource = cli;
                txtCpf.Text = "";
                txtNome.Text = "";
                //txtBairro.Text = "";
                txtEndereco.Text = "";
                txtCep.Text = "";
                txtCidade.Text = "";
                txtEmail.Text = "";
                txtCelular.Text = "";
                this.dtpDtNascimento.Value = DateTime.Now.Date;
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
                Cliente cliente = new Cliente();
                cliente.Atualizar(txtCpf.Text, txtNome.Text, txtCep.Text, txtCidade.Text, txtEndereco.Text, txtCidade.Text, txtCelular.Text, txtEmail.Text, dtpDtNascimento.Value);
                MessageBox.Show("Cliente atualizado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Cliente> cli = cliente.listacliente();
                dgvCliente.DataSource = cli;
                txtCpf.Text = "";
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtCep.Text = "";
                txtCidade.Text = "";
                txtEmail.Text = "";
                txtCelular.Text = "";
                this.dtpDtNascimento.Value = DateTime.Now.Date;
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
                string cpf = txtCpf.Text.Trim();
                Cliente cliente = new Cliente();
                cliente.Exclui(cpf);
                MessageBox.Show("Cliente excluído com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Cliente> cli = cliente.listacliente();
                dgvCliente.DataSource = cli;
                txtCpf.Text = "";
                txtNome.Text = "";
                txtCep.Text = "";
                txtCidade.Text = "";
                txtEndereco.Text = "";
                txtEmail.Text = "";
                txtCelular.Text = "";
                this.dtpDtNascimento.Value = DateTime.Now.Date;
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnLimpaCampos_Click(object sender, EventArgs e)
        {
            txtCpf.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            this.dtpDtNascimento.Value = DateTime.Now.Date;
        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + txtCep.Text + "/json");
            request.AllowAutoRedirect = false;
            HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();
            if (ChecaServidor.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Servidor Indisponível!");
                return; //Sai da rotina e para e codificação
            }
            using (Stream webStream = ChecaServidor.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        response = Regex.Replace(response, "[{},]", string.Empty);
                        response = response.Replace("\"", "");

                        String[] substrings = response.Split('\n');

                        int cont = 0;
                        foreach (var substring in substrings)
                        {
                            if (cont == 1)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                if (valor[0] == "  erro")
                                {
                                    MessageBox.Show("CEP não encontrado!");
                                    txtCep.Focus();
                                    return;
                                }
                            }

                            //Endereço
                            if (cont == 2)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtEndereco.Text = valor[1];
                            }
                            //Cidade
                            if (cont == 5)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtCidade.Text = valor[1];
                            }
                            cont++;
                        }
                    }
                }
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                string cpf = txtCpf.Text.Trim();
                Cliente cliente = new Cliente();
                cliente.Localiza(cpf);
                txtNome.Text = cliente.nome;
                txtCep.Text = cliente.cep;
                txtEndereco.Text = cliente.endereco;
                txtCidade.Text = cliente.cidade;
                txtCelular.Text = cliente.celular;
                dtpDtNascimento.Value = Convert.ToDateTime(cliente.dt_nascimento);
                txtEmail.Text = cliente.email;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            List<Cliente> clientes = cli.listacliente();
            dgvCliente.DataSource = clientes;
        }
    }
}
