using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using System.Data.SqlClient;
using System.Data;

namespace CamadaNegocio.DAO
{

    /// <summary>
    /// Classe com os comandos CRUD do recado.
    /// </summary>
    public class RecadoDAO
    {
        /// <summary>
        /// Método para Gravar um recado.
        /// </summary>
        /// <param name="recado">Variável do tipo recado com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Recado recado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Recado (dataCadastro, horaCadastro, descricao, assunto, setor, unidade_fis, lido, link)" +
                    " values(@dataCadastro, @horaCadastro, @descricao, @assunto, @setor, @unidade_fis, @lido, @link)";

                cmd.Parameters.AddWithValue("@dataCadastro", recado._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", recado._HoraCadastro);
                cmd.Parameters.AddWithValue("@descricao", recado._Descricao);
                cmd.Parameters.AddWithValue("@assunto", recado._Assunto);
                cmd.Parameters.AddWithValue("@setor", recado._Setor);
                cmd.Parameters.AddWithValue("@unidade_fis", recado._Unidade_fis);
                cmd.Parameters.AddWithValue("@lido", recado._Lido);
                cmd.Parameters.AddWithValue("@link", recado._Link);


                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse recado " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um recado.
        /// </summary>
        /// <param name="recado">Variável do tipo recado com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Recado recado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Recado SET descricao=@descricao, assunto=@assunto, lido=@lido, link=@link" +
                    " WHERE recadoID=@recadoID";

                cmd.Parameters.AddWithValue("@recadoID", recado._RecadoID);
                cmd.Parameters.AddWithValue("@descricao", recado._Descricao);
                cmd.Parameters.AddWithValue("@assunto", recado._Assunto);
                cmd.Parameters.AddWithValue("@lido", recado._Lido);
                cmd.Parameters.AddWithValue("@link", recado._Link);


                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse recado " + ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um recado.
        /// </summary>
        /// <param name="recado">Variável do tipo recado com o valor do id para fazer a exclusão.</param>
        public void Excluir(Recado recado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Recado WHERE recadoID = @recadoID";

                cmd.Parameters.AddWithValue("@recadoID", recado._RecadoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse recado " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um recado pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do recado preenchidos.</returns>
        public Recado BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Recado WHERE recadoID = @recadoID";

                cmd.Parameters.AddWithValue("@recadoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Recado recado = new Recado();

                if (dr.HasRows)
                {
                    dr.Read();
                    recado._RecadoID = (int)dr["recadoID"];
                    recado._DataCadastro = dr["dataCadastro"].ToString();
                    recado._HoraCadastro = dr["horaCadastro"].ToString();
                    recado._Descricao = dr["descricao"].ToString();
                    recado._Assunto = dr["assunto"].ToString();
                    recado._Link = dr["link"].ToString();
                    recado._Setor = dr["setor"].ToString();
                    recado._Unidade_fis = dr["unidade_fis"].ToString();
                    recado._Lido = dr["lido"].ToString();
                }
                else
                {
                    recado = null;
                }
                dr.Close();
                return recado;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse recado pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um recado pela sua data.
        /// </summary>
        /// <param name="dataInicial">Atributo com o valor da data inicial.</param>
        /// <param name="dataFinal">Variável com o valor da data final.</param>
        /// <returns>Retorna uma lista com os atributos do recado preenchidos.</returns>
        public IList<Recado> BuscarPorData(string dataInicial, string dataFinal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Recado WHERE dataCadastro BETWEEN @dataInicial AND @dataFinal";

                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Recado> listaRecado = new List<Recado>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Recado recado = new Recado();
                        recado._RecadoID = (int)dr["recadoID"];
                        recado._DataCadastro = dr["dataCadastro"].ToString();
                        recado._HoraCadastro = dr["horaCadastro"].ToString();
                        recado._Descricao = dr["descricao"].ToString();
                        recado._Assunto = dr["assunto"].ToString();
                        recado._Link = dr["link"].ToString();
                        recado._Setor = dr["setor"].ToString();
                        recado._Unidade_fis = dr["unidade_fis"].ToString();
                        recado._Lido = dr["lido"].ToString();

                        listaRecado.Add(recado);
                    }

                }
                else
                {
                    listaRecado = null;
                }
                dr.Close();
                return listaRecado;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse recado pela data " + ex.Message);
            }
        }

        
        /// <summary>
        /// Método para buscar todos os recados.
        /// </summary>
        /// <returns>Retorna uma lista com os atributos do recado preenchidos.</returns>
        public IList<Recado> BuscarTodosRecados()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Recado WHERE lido = @N";

                cmd.Parameters.AddWithValue("@N", "N");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Recado> listaRecado = new List<Recado>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Recado recado = new Recado();
                        recado._RecadoID = (int)dr["recadoID"];
                        recado._DataCadastro = dr["dataCadastro"].ToString();
                        recado._HoraCadastro = dr["horaCadastro"].ToString();
                        recado._Descricao = dr["descricao"].ToString();
                        recado._Assunto = dr["assunto"].ToString();
                        recado._Link = dr["link"].ToString();
                        recado._Setor = dr["setor"].ToString();
                        recado._Unidade_fis = dr["unidade_fis"].ToString();
                        recado._Lido = dr["lido"].ToString();

                        listaRecado.Add(recado);
                    }

                }
                else
                {
                    listaRecado = null;
                }
                dr.Close();
                return listaRecado;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os recados " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os recados não lidos.
        /// </summary>
        /// <returns>Retorna uma lista com os atributos do recado preenchidos.</returns>
        public IList<Recado> BuscarTodosRecadosLidos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Recado WHERE lido = @S";

                cmd.Parameters.AddWithValue("@S", "S");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Recado> listaRecado = new List<Recado>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Recado recado = new Recado();
                        recado._RecadoID = (int)dr["recadoID"];
                        recado._DataCadastro = dr["dataCadastro"].ToString();
                        recado._HoraCadastro = dr["horaCadastro"].ToString();
                        recado._Descricao = dr["descricao"].ToString();
                        recado._Assunto = dr["assunto"].ToString();
                        recado._Link = dr["link"].ToString();
                        recado._Setor = dr["setor"].ToString();
                        recado._Unidade_fis = dr["unidade_fis"].ToString();
                        recado._Lido = dr["lido"].ToString();

                        listaRecado.Add(recado);
                    }

                }
                else
                {
                    listaRecado = null;
                }
                dr.Close();
                return listaRecado;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os recados não lidos " + ex.Message);
            }
        }
    }

}
