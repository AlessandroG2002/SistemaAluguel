using SistemaCasas.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCasas.DAO
{
    public class LoginDao
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;

        public bool verificarLogin(String login, String senha)
        {
            command.CommandText = "select * from usuario " +
                "where login = @login and senha = @senha";

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@senha", senha);

            Conexao con = new Conexao();

            try
            {
                command.Connection = con.conectar();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                    tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados! ";
            }

            return tem;
        }

        public bool cadastrar(String login, String senha, string confirmarSenha, Pessoa pessoa, Endereco endereco)
        {
            command.CommandText = "select * from usuario " +
                "where login = @login and senha = @senha";

            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@senha", senha);

            Conexao con = new Conexao();

            try
            {
                command.Connection = con.conectar();
                dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();
                    con.desconectar();
                    tem = true;
                }
                else
                {
                    dr.Close();

                    SqlCommand command = new SqlCommand();

                    command.CommandText = "insert into usuario (login, senha) values (@login, @senha); " +
                        "insert into pessoa (nome, email, filiacao, data, isAdmin, isCNPJ, cpf, cnpj) values (@nome, @email, @filiacao, @data, @isAdmin, @isCNPJ, '" + pessoa.cpf + "', '" + pessoa.cnpj +"'); " +
                        "insert into casa (numero, bairro, cep, cidade, estado, aluguel) values (@numero, @bairro, @cep, @cidade, @estado, null)";

                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@senha", senha);

                    command.Parameters.AddWithValue("@nome", pessoa.nome);
                    command.Parameters.AddWithValue("@email", pessoa.email);
                    command.Parameters.AddWithValue("@filiacao", pessoa.filiacao);
                    command.Parameters.AddWithValue("@data", pessoa.data);
                    command.Parameters.AddWithValue("@isAdmin", pessoa.isAdmin);
                    command.Parameters.AddWithValue("@isCNPJ", pessoa.isCNPJ);

                    command.Parameters.AddWithValue("@numero", endereco.numero);
                    command.Parameters.AddWithValue("@bairro", endereco.bairro);
                    command.Parameters.AddWithValue("@cep", endereco.cep);
                    command.Parameters.AddWithValue("@cidade", endereco.cidade);
                    command.Parameters.AddWithValue("@estado", endereco.estado);

                    con.desconectar();
                    con = new Conexao();

                    command.Connection = con.conectar();

                    command.ExecuteNonQuery();
                }
                    
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
            }
            return tem;
        }
    }
}
