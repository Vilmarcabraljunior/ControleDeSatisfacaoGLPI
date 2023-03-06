using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe recado com os atributos e propriedades.
    /// </summary>
    public class Recado
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int recadoID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da hora do cadastro.
        /// </summary>
        private string horaCadastro;
        /// <summary>
        /// Variável que guarda o valor da descrição do recado.
        /// </summary>
        private string descricao;
        /// <summary>
        /// Variável que guarda o valor da assunto do recado.
        /// </summary>
        private string assunto;
        /// <summary>
        /// Variável que guarda o valor do link do recado.
        /// </summary>
        private string link;
        /// <summary>
        /// Variável que guarda o setor do assunto.
        /// </summary>
        private string setor;
        /// <summary>
        /// Variável que guarda o setor da unidade_fis.
        /// </summary>
        private string unidade_fis;
        /// <summary>
        /// Variável que guarda o valor do marcado como lido.
        /// </summary>
        private string lido;
        
               
        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Recado()
        {

        }

        /// <summary>
        /// Propriedade da variável recadoID.
        /// </summary>
        public int _RecadoID
        {
            get
            {
                return recadoID;
            }
            set
            {
                recadoID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável dataCadastro.
        /// </summary>
        public string _DataCadastro
        {
            get
            {
                return dataCadastro;
            }
            set
            {
                dataCadastro = value;
            }
        }

        /// <summary>
        /// Propriedade da variável horaCadastro.
        /// </summary>
        public string _HoraCadastro
        {
            get
            {
                return horaCadastro;
            }
            set
            {
                horaCadastro = value;
            }
        }

        /// <summary>
        /// Propriedade da variável descricao.
        /// </summary>
        public string _Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }

        /// <summary>
        /// Propriedade da variável assunto.
        /// </summary>
        public string _Assunto
        {
            get
            {
                return assunto;
            }
            set
            {
                assunto = value;
            }
        }

        /// <summary>
        /// Propriedade da variável link.
        /// </summary>
        public string _Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
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
        /// Propriedade da variável lido.
        /// </summary>
        public string _Lido
        {
            get
            {
                return lido;
            }
            set
            {
                lido = value;
            }
        }
                
    }
}
