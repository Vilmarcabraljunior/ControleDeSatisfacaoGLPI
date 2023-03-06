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
    public partial class pgLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }

         }

        #region Métodos Auxiliares

        public void LimparFormulario()
        {
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }

        public void LimparFormularioAlterarSenha()
        {
            hdUsuarioAlterarSenhaID.Value = "0";
            txtNovaSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos Entrar

        Usuario usuario;
        UsuarioBO usuarioBO;
   
        protected void lkbEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuarioBO = new UsuarioBO();

                usuario = usuarioBO.Logar(txtUsuario.Text, txtSenha.Text);

                if (usuario != null)
                {
                    if (usuario._Senha == "athenas@123")
                    {
                        //esse campo rerebe o id do funcionario para poder atualizar a senha;
                        hdUsuarioAlterarSenhaID.Value = usuario._UsuarioID.ToString();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                    }
                    else
                    {
                        Session["UsuarioLogado"] = usuario;
                        Response.Redirect("pgCarregamentoEntrada.aspx");
                    }
                }
                else
                {
                    Mensagem("Login ou senha de usuário estão incorretos, por favor verifique novamente.", this);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Evento para quando clicar em enter ele faz essa ação.
        protected void txtSenha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuarioBO = new UsuarioBO();

                usuario = usuarioBO.Logar(txtUsuario.Text, txtSenha.Text);

                if (usuario != null)
                {
                    if (usuario._Senha == "athenas@123")
                    {
                        //esse campo rerebe o id do funcionario para poder atualizar a senha;
                        hdUsuarioAlterarSenhaID.Value = usuario._UsuarioID.ToString();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                    }
                    else
                    {
                        Session["UsuarioLogado"] = usuario;
                        Response.Redirect("pgCarregamentoEntrada.aspx");
                    }
                }
                else
                {
                    Mensagem("Login ou senha de usuário estão incorretos, por favor verifique novamente.", this);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        #endregion

        #region Eventos Alterar Senha

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
                            usuario = new Usuario();
                            
                            usuario._UsuarioID = Convert.ToInt32(hdUsuarioAlterarSenhaID.Value);
                            usuario._Senha = txtConfirmarSenha.Text;

                            usuarioBO = new UsuarioBO();
                            usuarioBO.RedefinirSenha(usuario);

                            Mensagem("Senha criada com sucesso.", this);

                            txtSenha.Text = string.Empty;

                            LimparFormularioAlterarSenha();
                        }
                        else
                        {
                            Mensagem("Ambas as Novas Senhas Devem ser Iguais. Digite-as Novamente", this);

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