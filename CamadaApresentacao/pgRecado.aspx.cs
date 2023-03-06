using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocio.MODEL;
using CamadaNegocio.BO;


namespace CamadaApresentacao
{
    public partial class pgCalendAcademico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificação nível de acesso
            //Mostrando o nome do usuário e definindo o tipo de menu que ele verá quando acessar o sistema.
            if (Session["UsuarioLogado"] != null)
            {
                var usuario = (Usuario)Session["UsuarioLogado"];

                #region Nome do usuário

                lblUsuarioNomeNivel.Text = "Bem-Vindo(a) " + usuario._Usuario;

                #endregion

                #region tela de cadastro de usuário

                if (usuario._Setor == "TI" && usuario._Unidade_fis == "ATHENAS")
                {
                    pnlPerfilUsuario.Visible = true;
                }

                #endregion

                #region tela de portaria

                if (usuario._Setor == "TI" && usuario._Unidade_fis == "ATHENAS")
                {
                    pnlPortaria.Visible = true;
                }
                else if (usuario._Setor == "Juridico" && usuario._Unidade_fis == "ATHENAS")
                {
                    pnlPortaria.Visible = true;
                }

                #endregion

            }
            else
            {
                Response.Redirect("pgCarregamentoSaida.aspx");
            }

            #endregion

            #region Metodos Iniciação

            if (ckbCarregarRecados.SelectedIndex == 1)
            {
                CarregarTodosRecados();
            }

            #endregion
        }

        #region Metodos

        #region Mensageiro
        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Limpar Formulario
        public void LimparFormulario()
        {

            hdRecadoID.Value = "0";
            txtRecado.Text = string.Empty;
            txtAssunto.Text = string.Empty;
            txtLink.Text = string.Empty;
            txtDataCadastroRecado.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void LimparFormularioDetalhes()
        {
            hdDetalhesRecadoID.Value = "0";
            lblDetalhesRecado.Text = string.Empty;
            lblAssuntoDetalhesRecado.Text = string.Empty;
            lkbLinkDetalhes.Text = string.Empty;
            txtLinkDetalhes.Text = string.Empty;
            lblDataCadastroDetalhesRecado.Text = string.Empty;
            CkbLido.Checked = false;
        }
        #endregion

        #region Carregar Recados
        public void CarregarTodosRecados()
        {
            try
            {
                recadoBO = new RecadoBO();
                listaRecado = new List<Recado>();

                listaRecado = recadoBO.BuscarTodosRecados();
                gvRecado.DataSource = listaRecado;
                gvRecado.DataBind();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);

            }

        }
        public void CarregarRecadosLidos()
        {
            try
            {

                recadoBO = new RecadoBO();
                listaRecado = new List<Recado>();

                listaRecado = recadoBO.BuscarTodosRecadosLidos();
                gvRecado.DataSource = listaRecado;
                gvRecado.DataBind();

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion

        #region Instancia objeto
        Recado recado;
        RecadoBO recadoBO;
        IList<Recado> listaRecado;
        #endregion

        #region Metodo Cadastrar
        public void SalvarRecado()
        {
            try
            {
                recado = new Recado();

                recado._RecadoID = Convert.ToInt32(hdRecadoID.Value);
                recado._DataCadastro = txtDataCadastroRecado.Text;
                recado._HoraCadastro = DateTime.Now.ToString("HH:mm");
                recado._Assunto = txtAssunto.Text;
                recado._Link = txtLink.Text;
                recado._Descricao = txtRecado.Text;

                var usuario = (Usuario)Session["UsuarioLogado"];

                recado._Setor = usuario._Setor;
                recado._Unidade_fis = usuario._Unidade_fis;
                recado._Lido = "N";

                recadoBO = new RecadoBO();
                recadoBO.Salvar(recado);

                Mensagem("Recado Salvo com Sucesso.", this);


                LimparFormulario();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion

        #region Metodo Atualizar
        public void AtualizarRecado()
        {
            try
            {
                recado = new Recado();

                recado._RecadoID = Convert.ToInt32(hdDetalhesRecadoID.Value);
                recado._Assunto = lblAssuntoDetalhesRecado.Text;
                recado._Link = txtLinkDetalhes.Text;
                recado._Descricao = lblDetalhesRecado.Text;

                if (CkbLido.Checked)
                {
                    recado._Lido = "S";
                }
                else
                {
                    recado._Lido = "N";
                }

                recadoBO = new RecadoBO();
                recadoBO.Salvar(recado);

                Mensagem("Recado editado como sucesso.", this);

                LimparFormularioDetalhes();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion


        #endregion

        #region Eventos

        #region Evento Salvar

        protected void lkbSalvarRecado_Click(object sender, EventArgs e)
        {
            SalvarRecado();
        }
        protected void lkbAbrirNovoRecado_Click(object sender, EventArgs e)
        {
            pnlRecadosGV.Visible = false;
            pnlRecadoNovo.Visible = true;

            txtDataCadastroRecado.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        protected void lkbCancelarRecado_Click(object sender, EventArgs e)
        {
            LimparFormulario();

            CarregarTodosRecados();

            pnlRecadosGV.Visible = true;
            pnlRecadoNovo.Visible = false;

        }
        #endregion

        #region Evento Visualizar
        //Método para visualizar 
        protected void gvRecado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                //Buscar um recado pelo id
                recado = new Recado();
                recadoBO = new RecadoBO();

                int recadoID = Convert.ToInt32(gvRecado.DataKeys[e.RowIndex].Value);
                recado = recadoBO.BuscarPorID(recadoID);

                hdDetalhesRecadoID.Value = recado._RecadoID.ToString();
                lblAssuntoDetalhesRecado.Text = recado._Assunto;
                lkbLinkDetalhes.Text = recado._Link;
                txtLinkDetalhes.Text = recado._Link;
                lblDataCadastroDetalhesRecado.Text = recado._DataCadastro;
                lblDetalhesRecado.Text = recado._Descricao;

                if (recado._Lido == "N")
                {
                    CkbLido.Checked = false;
                }
                else if (recado._Lido == "S")
                {
                    CkbLido.Checked = true;
                }

                lblAssuntoDetalhesRecado.ReadOnly = true;

                txtLinkDetalhes.Visible = false;
                if (!string.IsNullOrEmpty(recado._Link))
                {
                    lblRotuloLinkDetalhes.Visible = true;
                    lkbLinkDetalhes.Visible = true;

                }
                else
                {
                    lblRotuloLinkDetalhes.Visible = false;
                    lkbLinkDetalhes.Visible = false;
                }

                lblDetalhesRecado.ReadOnly = true;
                lblDetalhesRecado.EnableToolbars = false;
                lblDetalhesRecado.EnableHtmlMode = false;
                lkbAtualizarDetalhesRecado.Visible = false;
                Label2.Visible = false;
                CkbLido.Visible = false;

                pnlRecadosGV.Visible = false;
                pnlRecadoVisualizar.Visible = true;


            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }


        }
        protected void lkbCancelarDetalhesRecado_Click(object sender, EventArgs e)
        {

            if (ckbCarregarRecados.SelectedIndex == 1)
            {
                CarregarTodosRecados();
            }

            LimparFormularioDetalhes();

            pnlRecadosGV.Visible = true;
            pnlRecadoVisualizar.Visible = false;
        }
        #endregion

        #region Evento Editar
        //Método para editar um recado
        protected void gvRecado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //Buscar um recado pelo id
                recado = new Recado();
                recadoBO = new RecadoBO();

                int recadoID = Convert.ToInt32(gvRecado.DataKeys[e.RowIndex].Value);
                recado = recadoBO.BuscarPorID(recadoID);

                hdDetalhesRecadoID.Value = recado._RecadoID.ToString();
                lblAssuntoDetalhesRecado.Text = recado._Assunto;
                lkbLinkDetalhes.Text = recado._Link;
                txtLinkDetalhes.Text = recado._Link;
                lblDataCadastroDetalhesRecado.Text = recado._DataCadastro;
                lblDetalhesRecado.Text = recado._Descricao;

                if (recado._Lido == "N")
                {
                    CkbLido.Checked = false;
                }
                else if (recado._Lido == "S")
                {
                    CkbLido.Checked = true;
                }

                var usuario = (Usuario)Session["UsuarioLogado"];
                if (usuario._Setor == recado._Setor && usuario._Unidade_fis == recado._Unidade_fis)
                {
                    lblAssuntoDetalhesRecado.ReadOnly = false;

                    lblRotuloLinkDetalhes.Visible = true;
                    txtLinkDetalhes.Visible = true;
                    txtLinkDetalhes.ReadOnly = false;
                    
                    lkbLinkDetalhes.Visible = false;
                    lblDetalhesRecado.ReadOnly = false;
                    lblDetalhesRecado.EnableToolbars = true;
                    lblDetalhesRecado.EnableHtmlMode = false;
                    lkbAtualizarDetalhesRecado.Visible = true;
                    Label2.Visible = true;
                    CkbLido.Visible = true;
                }

                pnlRecadosGV.Visible = false;
                pnlRecadoVisualizar.Visible = true;


            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion

        #region Evento Atualizar
        protected void lkbAtualizarDetalhesRecado_Click(object sender, EventArgs e)
        {
            AtualizarRecado();

            if (ckbCarregarRecados.SelectedIndex == 0)
            {
                CarregarRecadosLidos();
            }
            else if (ckbCarregarRecados.SelectedIndex == 1)
            {
                CarregarTodosRecados();
            }

            LimparFormularioDetalhes();

            pnlRecadosGV.Visible = true;
            pnlRecadoVisualizar.Visible = false;
        }
        #endregion

        #region Evento Pesquisar
        protected void lkbCarregarRecados_Click(object sender, EventArgs e)
        {
            if (ckbCarregarRecados.SelectedIndex == 0)
            {
                CarregarRecadosLidos();
            }
            else if (ckbCarregarRecados.SelectedIndex == 1)
            {
                CarregarTodosRecados();

            }
        }

        #endregion

        #region Evento abrir link
        protected void lkbLinkDetalhes_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + lkbLinkDetalhes.Text + "','_blank')", true);

            //Buscar um recado pelo id
            recado = new Recado();
            recadoBO = new RecadoBO();

            int recadoID = Convert.ToInt32(hdDetalhesRecadoID.Value);
            recado = recadoBO.BuscarPorID(recadoID);

            lblDetalhesRecado.Text = recado._Descricao;
                        
        }
        #endregion


        #endregion

    }
}