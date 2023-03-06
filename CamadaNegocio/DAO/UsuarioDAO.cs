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
    /// Classe com os comandos CRUD do usuário.
    /// </summary>
    public class UsuarioDAO
    {
        /// <summary>
        /// Método para Gravar um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Usuario (usuario, senha, unidade_fis, setor, ativo)" +
                    " values(@usuario, @senha, @unidade_fis, @setor, @ativo)";

                cmd.Parameters.AddWithValue("@usuario", usuario._Usuario);
                cmd.Parameters.AddWithValue("@senha", usuario._Senha);
                cmd.Parameters.AddWithValue("@unidade_fis", usuario._Unidade_fis);
                cmd.Parameters.AddWithValue("@setor", usuario._Setor);
                cmd.Parameters.AddWithValue("@ativo", usuario._Ativo);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse usuário " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Usuario SET usuario=@usuario, senha=@senha, unidade_fis=@unidade_fis, setor=@setor, ativo=@ativo WHERE usuarioID=@usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@usuario", usuario._Usuario);
                cmd.Parameters.AddWithValue("@senha", usuario._Senha);
                cmd.Parameters.AddWithValue("@unidade_fis", usuario._Unidade_fis);
                cmd.Parameters.AddWithValue("@setor", usuario._Setor);
                cmd.Parameters.AddWithValue("@ativo", usuario._Ativo);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse usuário " + ex.Message);
            }
        }
               
        /// <summary>
        /// Método para excluir um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com o valor do id para fazer a exclusão.</param>
        public void Excluir(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Usuario WHERE usuarioID = @UsuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para redefinir a senha do usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void RedefinirSenha(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Usuario SET senha=@senha WHERE usuarioID=@usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@senha", usuario._Senha);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível redefinir a senha do usuário." + ex.Message);
            }
        }
        
        /// <summary>
        /// Método para buscar um usuário pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public Usuario BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Usuario usuario = new Usuario();

                if (dr.HasRows)
                {

                    dr.Read();
                    usuario._UsuarioID = (int)dr["usuarioID"];
                    usuario._Usuario = dr["usuario"].ToString();
                    usuario._Senha = dr["senha"].ToString();
                    usuario._Unidade_fis = dr["unidade_fis"].ToString();
                    usuario._Setor = dr["setor"].ToString();
                    usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), dr["ativo"].ToString());
                }
                else
                {
                    usuario = null;
                }
                dr.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse nível de acesso do usuário pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo seu nome.
        /// </summary>
        /// <param name="usuarioNome">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public IList<Usuario> BuscarPorNomeExpecifico(string usuarioNome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuario = @usuario";

                cmd.Parameters.AddWithValue("@usuario", usuarioNome);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._Usuario = dr["usuario"].ToString();
                        usuario._Senha = dr["senha"].ToString();
                        usuario._Unidade_fis = dr["unidade_fis"].ToString();
                        usuario._Setor = dr["setor"].ToString();
                        usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), dr["ativo"].ToString());

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse usuário pelo nome expecifico  " + ex.Message);
            }
        }

        /// <summary>
        /// Método que busca o usuário pelo cpf e senha.
        /// </summary>
        /// <param name="usuarioNome">Atributo com o valor do cpf.</param>
        /// <param name="senha">Atributo com o valor da senha.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public Usuario Logar(string usuarioNome, string senha)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuario = @usuario and senha = @senha";

                cmd.Parameters.AddWithValue("@usuario", usuarioNome);
                cmd.Parameters.AddWithValue("@senha", senha);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Usuario usuario = new Usuario();

                if (dr.HasRows)
                {

                    dr.Read();
                    usuario._UsuarioID = (int)dr["usuarioID"];
                    usuario._Usuario = dr["usuario"].ToString();
                    usuario._Senha = dr["senha"].ToString();
                    usuario._Unidade_fis = dr["unidade_fis"].ToString();
                    usuario._Setor = dr["setor"].ToString();
                    usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), dr["ativo"].ToString());
                }
                else
                {
                    usuario = null;
                }
                dr.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível logar. " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo nome.
        /// </summary>
        /// <param name="usuarioNome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos do usuário preenchidas.</returns>
        public IList<Usuario> BuscarPorNome(string usuarioNome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuario like @usuario ORDER BY usuario ASC";

                cmd.Parameters.AddWithValue("@usuario", usuarioNome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._Usuario = dr["usuario"].ToString();
                        usuario._Senha = dr["senha"].ToString();
                        usuario._Unidade_fis = dr["unidade_fis"].ToString();
                        usuario._Setor = dr["setor"].ToString();
                        usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), dr["ativo"].ToString());

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse usuário pelo nome  " + ex.Message);
            }
        }
                

        /// <summary>
        /// Método para buscar um usuário pelo setor.
        /// </summary>
        /// <param name="setor">Variável com o valor do setor.</param>
        /// <returns>Retorna uma Lista com os atributos do usuário preenchidos.</returns>
        public IList<Usuario> BuscarPorSetor(string setor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE setor = @setor ORDER BY usuario ASC";

                cmd.Parameters.AddWithValue("@setor", setor);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._Usuario = dr["usuario"].ToString();
                        usuario._Senha = dr["senha"].ToString();
                        usuario._Unidade_fis = dr["unidade_fis"].ToString();
                        usuario._Setor = dr["setor"].ToString();
                        usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), dr["ativo"].ToString());

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse usuário pelo setor  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os usuários da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os usuários e seus atributos.</returns>
        public IList<Usuario> BuscarTodosUsuarios()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario ORDER BY usuario ASC ";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._Usuario = dr["usuario"].ToString();
                        usuario._Senha = dr["senha"].ToString();
                        usuario._Unidade_fis = dr["unidade_fis"].ToString();
                        usuario._Setor = dr["setor"].ToString();
                        usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), dr["ativo"].ToString());

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os usuários " + ex.Message);
            }
        }
                
    }
}
