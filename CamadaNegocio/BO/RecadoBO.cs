using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using CamadaNegocio.DAO;

namespace CamadaNegocio.BO
{
    /// <summary>
    /// classe que faz a validãção dos dados do recado.
    /// </summary>
    public class RecadoBO
    {
        /// <summary>
        /// Variável do tipo recado com os atributos para serem preenchidos.
        /// </summary>
        Recado recado;
        /// <summary>
        /// Váriavel da classe recadoDAO para chamar os métodos da classe DAO.
        /// </summary>
        RecadoDAO recadoDAO;
        /// <summary>
        /// Variável do tipo Lista para retorna os dados do recado.
        /// </summary>
        IList<Recado> listaRecado;

        /// <summary>
        /// Método que faz a Validação dos Dados do Recado.
        /// </summary>
        /// <param name="recado">Atributo do tipo recado com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Recado recado)
        {
            if (string.IsNullOrEmpty(recado._Assunto))
            {
                throw new Exception("Campo Assunto é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(recado._Descricao))
            {
                throw new Exception("Campo Descrição é Obrigatório.");
            }
        }
              
        #endregion

        /// <summary>
        /// Método para Gravar um recado.
        /// </summary>
        /// <param name="recado">Variável do tipo recado com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Recado recado)
        {
            try
            {
                ValidacaoSalvar(recado);

                recadoDAO = new RecadoDAO();

                if (recado._RecadoID != 0)
                {
                    recadoDAO.Atualizar(recado);
                }
                else
                {
                    recadoDAO.Salvar(recado);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                recadoDAO = new RecadoDAO();
                recadoDAO.Excluir(recado);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                recado = new Recado();
                recadoDAO = new RecadoDAO();

                recado = recadoDAO.BuscarPorID(id);
                return recado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que busca o recado pela sua data.
        /// </summary>
        /// <param name="dataInicial">Atributo com o valor da data inicial.</param>
        /// <param name="dataFinal">Atributo com o valor da dataFinal.</param>
        /// <returns>Retorna uma variável com os atributos do recado preenchidos.</returns>
        public IList<Recado> BuscarPorData(string dataInicial, string dataFinal)
        {
            try
            {
                listaRecado = new List<Recado>();
                recadoDAO = new RecadoDAO();

                listaRecado = recadoDAO.BuscarPorData(dataInicial, dataFinal);
                return listaRecado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Método para buscar todos os recados da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os recados e seus atributos.</returns>
        public IList<Recado> BuscarTodosRecados()
        {
            try
            {
                listaRecado = new List<Recado>();
                recadoDAO = new RecadoDAO();

                listaRecado = recadoDAO.BuscarTodosRecados();
                return listaRecado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os recados não lidos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os recados e seus atributos.</returns>
        public IList<Recado> BuscarTodosRecadosLidos()
        {
            try
            {
                listaRecado = new List<Recado>();
                recadoDAO = new RecadoDAO();

                listaRecado = recadoDAO.BuscarTodosRecadosLidos();
                return listaRecado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
