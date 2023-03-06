using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Usuario com os atributos e propriedades.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int usuarioID;
        /// <summary>
        /// Variável que guarda o valor do usuário.
        /// </summary>
        private string usuario;
        /// <summary>
        /// Variável que guarda o valor da senha do usuário.
        /// </summary>
        private string senha;
        /// <summary>
        /// Variável que guarda o valor da unidade fisica do usuário.
        /// </summary>
        private string unidade_fis;
        /// <summary>
        /// Variável que guarda o valor da unidade fisica do usuário.
        /// </summary>
        private string setor;
        /// <summary>
        /// Variável do tipo UsuarioNivelAcesso que guarda os atributos do usuario nivel acesso.
        /// </summary>
        private Ativo ativo;
       
             
        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Usuario()
        {

        }

        /// <summary>
        /// Propriedade da variável usuarioID.
        /// </summary>
        public int _UsuarioID
        {
            get
            {
                return usuarioID;
            }
            set
            {
                usuarioID = value;
            }
        }
               
              

        /// <summary>
        /// Propriedade da variável usuario.
        /// </summary>
        public string _Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        /// <summary>
        /// Propriedade da variável senha.
        /// </summary>
        public string _Senha
        {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
            }
        }

        /// <summary>
        /// Propriedade da variável unidade_fis.
        /// </summary>
        public string _Unidade_fis
        {
            get
            {
                return unidade_fis;
            }
            set
            {
                unidade_fis = value;
            }
        }

        /// <summary>
        /// Propriedade da variável setor.
        /// </summary>
        public string _Setor
        {
            get
            {
                return setor;
            }
            set
            {
                setor = value;
            }
        }

        /// <summary>
        /// Propriedade da variável ativo.
        /// </summary>
        public Ativo _Ativo
        {
            get
            {
                return ativo;
            }
            set
            {
                ativo = value;
            }
        }
               
    }
}
