using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SisTDS06
{
    class Usuario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string celular { get; set; }
        public DateTime dt_nascimento { get; set; }
        public DateTime dt_admissao { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string funcao { get; set; }
        public string email { get; set; }

        public List<Usuario> listausuario()
        {
            List<Usuario> li = new List<Usuario>();
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Usuario u = new Usuario();
                u.Id = (int)dr["Id"];
                u.nome = dr["nome"].ToString();
                u.login = dr["login"].ToString();
                u.senha = "******";
                u.celular = dr["celular"].ToString();
                u.dt_nascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                u.dt_admissao = Convert.ToDateTime(dr["dt_admissao"]);
                u.cep = dr["cep"].ToString();
                u.endereco = dr["endereco"].ToString();
                u.cidade = dr["cidade"].ToString();
                u.bairro = dr["bairro"].ToString();
                u.funcao = dr["funcao"].ToString();
                u.email = dr["email"].ToString();
                li.Add(u);
            }
            return li;
        }

        public void Inserir(string nome, string login, string senha, string celular, DateTime dt_nascimento, DateTime dt_admissao, string cep, string endereco, string cidade, string bairro, string funcao, string email)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO usuario(nome,login,senha,celular,dt_nascimento,dt_admissao,cep,endereco,cidade,bairro,funcao,email) VALUES ('"+nome+"','"+login+"','"+senha+"','"+celular+ "',Convert(DateTime,'"+dt_nascimento+"',103),Convert(DateTime,'"+dt_admissao+"',103),'" + cep+"','"+endereco+"','"+cidade+"','"+bairro+"','"+funcao+"','"+email+"')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void Localiza(int id)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM usuario WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                login = dr["login"].ToString();
                senha = dr["senha"].ToString();
                celular = dr["celular"].ToString();
                dt_nascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                dt_admissao = Convert.ToDateTime(dr["dt_admissao"]);
                cep = dr["cep"].ToString();
                endereco = dr["endereco"].ToString();
                cidade = dr["bairro"].ToString();
                bairro = dr["bairro"].ToString();
                funcao = dr["funcao"].ToString();
                email = dr["email"].ToString();
            }
        }

        public void Atualizar(int id, string nome, string login, string senha, string celular, DateTime dt_nascimento, DateTime dt_admissao, string cep, string endereco, string cidade, string bairro, string funcao, string email)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE usuario SET nome='" + nome + "',login='" + login + "',senha='" + senha + "',celular='" + celular + "',dt_nascimento=Convert(DateTime,'" + dt_nascimento + "',103),dt_admissao=Convert(DateTime,'" + dt_admissao + "',103),cep='" + cep + "',endereco='" + endereco + "',cidade='" + cidade + "',bairro='" + bairro + "',funcao='" + funcao + "',email='" + email + "' WHERE Id = '"+id+"'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void Exclui(int id)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM usuario WHERE Id='"+id+"'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }
    }
}
