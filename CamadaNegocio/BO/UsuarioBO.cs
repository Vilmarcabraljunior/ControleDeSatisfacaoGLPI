﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using CamadaNegocio.DAO;

namespace CamadaNegocio.BO
{
    /// <summary>
    /// Classe que faz a validação dos dados do usuário.
    /// </summary>
    public class UsuarioBO
    {
        /// <summary>
        /// Variável do tipo usuário com os atributos para serem preenchidos.
        /// </summary>
        Usuario usuario;
        /// <summary>
        /// Váriavel da classe usuarioDAO para chamar os métodos da classe DAO.
        /// </summary>
        UsuarioDAO usuarioDAO;
        /// <summary>
        /// Variável do tipo Lista para retorna os dados do usuário.
        /// </summary>
        IList<Usuario> listaUsuario;

        /// <summary>
        /// Método que faz a Validação dos Dados do Usuário.
        /// </summary>
        /// <param name="usuario">Atributo do tipo usuário com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario._Usuario))
            {
                throw new Exception("Campo usuário é obrigatório.");
            }
            else if (usuario._Unidade_fis == "0")
            {
                throw new Exception("campo unidade_fis é obrigatório.");
            }
            else if (usuario._Setor == "0")
            {
                throw new Exception("campo setor é obrigatório.");
            }

        }
        /// <summary>
        /// Método que não deixa excluir um usuário sem que o seu id seja informado.
        /// </summary>
        /// <param name="usuario">Atributo do tipo usuário com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Usuario usuario)
        {
            if (usuario._UsuarioID.Equals(0))
            {
                throw new Exception("Selecione um USUÁRIO para efetuar a Exclusão.");
            }
        }
        /// <summary>
        /// Método que não deixa os campos do login nulos.
        /// </summary>
        /// <param name="cpf">Atributo com o valor do nome do usuário.</param>
        /// <param name="senha">Atributo com o valor da senha do usuário.</param>
        public void ValidacaoLogin(string usuario, string senha)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                throw new Exception("campo usuário é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(senha))
            {
                throw new Exception("campo senha é Obrigatório.");
            }
        }

        #endregion

        /// <summary>
        /// Método para Gravar um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Usuario usuario)
        {
            try
            {
                ValidacaoSalvar(usuario);

                usuarioDAO = new UsuarioDAO();

                if (usuario._UsuarioID != 0)
                {
                    usuarioDAO.Atualizar(usuario);
                }
                else
                {
                    usuarioDAO.Salvar(usuario);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(usuario);

                usuarioDAO = new UsuarioDAO();
                usuarioDAO.Excluir(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                usuarioDAO = new UsuarioDAO();
                usuarioDAO.RedefinirSenha(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                usuario = new Usuario();
                usuarioDAO = new UsuarioDAO();

                usuario = usuarioDAO.BuscarPorID(id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo seu nome.
        /// </summary>
        /// <param name="usuarioNome">Atributo com o valor do seu nome.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public IList<Usuario> BuscarPorNomeExpecifico(string usuarioNome)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarPorNomeExpecifico(usuarioNome);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que busca o usuário pelo cpf e senha.
        /// </summary>
        /// <param name="cpf">Atributo com o valor do cpf.</param>
        /// <param name="senha">Atributo com o valor da senha.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public Usuario Logar(string usuarioNome, string senha)
        {
            try
            {
                ValidacaoLogin(usuarioNome, senha);

                usuario = new Usuario();
                usuarioDAO = new UsuarioDAO();

                usuario = usuarioDAO.Logar(usuarioNome, senha);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquele usuário que foi consultado.</returns>
        public IList<Usuario> BuscarPorNome(string nome)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarPorNome(nome);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Método para buscar um usuário pelo setor.
        /// </summary>
        /// <param name="setor">Variável com o setor.</param>
        /// <returns>retorna uma lista com os atributos daquele usuário que foi consultado.</returns>
        public IList<Usuario> BuscarPorSetor(string setor)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarPorSetor(setor);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarTodosUsuarios();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
