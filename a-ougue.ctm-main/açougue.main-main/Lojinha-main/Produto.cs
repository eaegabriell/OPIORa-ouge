using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SisTDS06
{
    internal class Produto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }

        public List<Produto> listaproduto()
        {
            List<Produto> li = new List<Produto>();
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM produto";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Produto p = new Produto();
                p.Id = (int)dr["Id"];
                p.nome = dr["nome"].ToString();
                p.quantidade = (int)dr["quantidade"];
                p.valor = Convert.ToDecimal(dr["valor"]);
                li.Add(p);
            }
            return li;
        }

        public void Inserir(string nome, int quantidade, decimal valor)
        {
            string num = valor.ToString();
            num = num.Replace(',', '.');
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO produto(nome,quantidade,valor) VALUES ('" + nome + "'," + quantidade + ",'" + num + "')";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void Localiza(int id)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM produto WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                quantidade = (int)dr["quantidade"];
                valor = (decimal)dr["valor"];
            }
        }

        public void Atualizar(int id, string nome, int quantidade, decimal valor)
        {
            string num = valor.ToString();
            num = num.Replace(',', '.');
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE produto SET nome='" + nome + "',quantidade=" + quantidade + ",valor='" + num + "' WHERE Id = '" + id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }

        public void Exclui(int id)
        {
            SqlConnection con = ClassConecta.ObterConexao();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM produto WHERE Id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            ClassConecta.FecharConexao();
        }
    }
}
