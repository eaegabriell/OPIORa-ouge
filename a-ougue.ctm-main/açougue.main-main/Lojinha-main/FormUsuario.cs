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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            List<Usuario> usuarios = usu.listausuario();
            dgvUsuario.DataSource = usuarios;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.Inserir(txtNome.Text, txtLogin.Text, txtSenha.Text, txtCelular.Text, dtpDtNascimento.Value, dtpDtAdmissao.Value, txtCep.Text, txtEndereco.Text, txtCidade.Text, txtBairro.Text, txtFuncao.Text, txtEmail.Text);
                MessageBox.Show("Usuário cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Usuario> usu = usuario.listausuario();
                dgvUsuario.DataSource = usu;
                txtNome.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtCelular.Text = "";
                this.dtpDtNascimento.Value = DateTime.Now.Date;
                this.dtpDtAdmissao.Value = DateTime.Now.Date;
                txtCep.Text = "";
                txtEndereco.Text = "";
                txtCidade.Text = "";
                txtBairro.Text = "";
                txtFuncao.Text = "";
                txtEmail.Text = "";
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
                int id = Convert.ToInt32(txtId.Text.Trim());
                Usuario usuario = new Usuario();
                usuario.Localiza(id);
                txtNome.Text = usuario.nome;
                txtLogin.Text = usuario.login;
                txtSenha.Text = usuario.senha;
                txtCelular.Text = usuario.celular;
                dtpDtNascimento.Value = Convert.ToDateTime(usuario.dt_nascimento);
                dtpDtAdmissao.Value = Convert.ToDateTime(usuario.dt_admissao);
                txtCep.Text = usuario.cep;
                txtEndereco.Text = usuario.endereco;
                txtCidade.Text = usuario.cidade;
                txtBairro.Text = usuario.bairro;
                txtFuncao.Text = usuario.funcao;
                txtEmail.Text = usuario.email;
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
                int id = Convert.ToInt32(txtId.Text.Trim());
                Usuario usuario = new Usuario();
                usuario.Atualizar(id, txtNome.Text, txtLogin.Text, txtSenha.Text, txtCelular.Text, dtpDtNascimento.Value, dtpDtAdmissao.Value, txtCep.Text, txtEndereco.Text, txtCidade.Text, txtBairro.Text, txtFuncao.Text, txtEmail.Text);
                MessageBox.Show("Usuário atualizado com sucesso!", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Usuario> usu = usuario.listausuario();
                dgvUsuario.DataSource = usu;
                txtId.Text = "";
                txtNome.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtCelular.Text = "";
                this.dtpDtNascimento.Value = DateTime.Now.Date;
                this.dtpDtAdmissao.Value = DateTime.Now.Date;
                txtCep.Text = "";
                txtEndereco.Text = "";
                txtCidade.Text = "";
                txtBairro.Text = "";
                txtFuncao.Text = "";
                txtEmail.Text = "";
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
                int id = Convert.ToInt32(txtId.Text.Trim());
                Usuario usuario = new Usuario();
                usuario.Exclui(id);
                MessageBox.Show("Usuário excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Usuario> usu = usuario.listausuario();
                dgvUsuario.DataSource = usu;
                txtId.Text = "";
                txtNome.Text = "";
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtCelular.Text = "";
                this.dtpDtNascimento.Value = DateTime.Now.Date;
                this.dtpDtAdmissao.Value = DateTime.Now.Date;
                txtCep.Text = "";
                txtEndereco.Text = "";
                txtCidade.Text = "";
                txtBairro.Text = "";
                txtFuncao.Text = "";
                txtEmail.Text = "";
                ClassConecta.FecharConexao();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCep_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" +txtCep.Text + "/json");
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

                            //Bairro
                            if (cont == 4)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txtBairro.Text = valor[1];
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

        private void btnLimpaCampos_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtCelular.Text = "";
            this.dtpDtNascimento.Value = DateTime.Now.Date;
            this.dtpDtAdmissao.Value = DateTime.Now.Date;
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtFuncao.Text = "";
            txtEmail.Text = "";
        }
    }
}
