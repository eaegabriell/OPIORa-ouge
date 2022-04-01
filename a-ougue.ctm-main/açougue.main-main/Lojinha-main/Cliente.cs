using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SisTDS06
{
    internal class Cliente
    {
        public string cpf { get; set; }
        public string nome { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public DateTime dt_nascimento { get; set; } 

        public List<Cliente> listacliente()
        {
            List<Cliente> li = new List<Cliente>();
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.cpf = dr["cpf"].ToString();
                c.nome = dr["nome"].ToString();
                c.cep = dr["cep"].ToString();
                c.endereco = dr["endereco"].ToString();
                c.bairro = dr["bairro"].ToString();
                c.cidade = dr["cidade"].ToString();
                c.celular = dr["celular"].ToString();
                c.email = dr["email"].ToString();
                c.dt_nascimento = Convert.ToDateTime(dr["dt_nascimento"]);
                li.Add(c);
            }
            return li;
        }

        public void Inserir(string cpf, string nome, string cep, string endereco, string bairro, string cidade, string celular, string email, DateTime dt_nascimento)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO cliente(cpf,nome,cep,endereco,bairro,cidade,celular,email,dt_nascimento) VALUES ('"+cpf+"','"+nome+"','"+cep+"','"+endereco+"','"+bairro+"','"+cidade+"','"+celular+"','"+email+"',Convert(DateTime,'"+dt_nascimento+"',111))";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void Localiza(string cpf)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente WHERE cpf='" + cpf + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cpf = dr["cpf"].ToString();
                nome = dr["nome"].ToString();
                cep = dr["cep"].ToString();
                endereco = dr["endereco"].ToString();
                bairro = dr["bairro"].ToString();
                cidade = dr["cidade"].ToString();
                celular = dr["celular"].ToString();
                email = dr["email"].ToString();
                dt_nascimento = Convert.ToDateTime(dr["dt_nascimento"]);
            }
        }

        public void Atualizar(string cpf, string nome, string cep, string endereco, string bairro, string cidade, string celular, string email, DateTime dt_nascimento)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE cliente SET cpf='"+cpf+"',nome='" + nome + "',cep='" + cep + "',endereco='" + endereco + "',bairro='" + bairro + "',cidade='" + cidade + "',celular='" + celular + "',email='" + email + "',dt_nascimento=Convert(DateTime,'" + dt_nascimento + "',103) WHERE cpf = '" + cpf + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void Exclui(string cpf)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM cliente WHERE cpf='"+cpf+"'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }
    }
}
