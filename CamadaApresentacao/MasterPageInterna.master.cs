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
    public partial class MasterPageInterna : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Mostrando o nome do usuário e definindo o tipo de menu que ele verá quando acessar o sistema.
            if (Session["UsuarioLogado"] != null)
            {
                var usuario = (Usuario)Session["UsuarioLogado"];

                lblUsuarioNome.Text = "Bem-Vindo(a) " + usuario._Usuario;
            }
            else
            {
                Response.Redirect("pgCarregamentoSaida.aspx");
            }
        }

        #region Métodos Auxiliares

        public void LimparFormularioAlterarSenha()
        {
            txtNovaSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        #endregion
               
        #region Eventos do Botão Sair

        protected void lkbSair_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("pgCarregamentoSaida.aspx");
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos do Alterar Senha

        protected void lkbAlterarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNovaSenha.Text))
                {
                    if (!string.IsNullOrEmpty(txtConfirmarSenha.Text))
                    {
                        if (txtNovaSenha.Text == txtConfirmarSenha.Text)
                        {
                            var usuarioLogado = (Usuario)Session["UsuarioLogado"];

                            Usuario usuario = new Usuario();

                            usuario._UsuarioID = usuarioLogado._UsuarioID;
                            usuario._Senha = txtConfirmarSenha.Text;

                            UsuarioBO usuarioBO = new UsuarioBO();
                            usuarioBO.RedefinirSenha(usuario);

                            Mensagem("Senha foi Alterada com Sucesso.", this);

                            LimparFormularioAlterarSenha();
                        }
                        else
                        {
                            Mensagem("As Senhas Informadas Precisam ser Idênticas.", this);

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                        }
                    }
                    else
                    {
                        Mensagem("Campo Confirmar Senha é Obrigatório.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                    }
                }
                else
                {
                    Mensagem("Campo Nova Senha é Obrigatório.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarAlterarSenha_Click(object sender, EventArgs e)
        {
            LimparFormularioAlterarSenha();
        }

        #endregion
            
    }
}