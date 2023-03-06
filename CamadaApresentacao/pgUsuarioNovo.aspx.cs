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
    public partial class pgUsuarioNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDDLNivelAcesso();
            }
        }

        #region Métodos Auxiliares
        public void CarregarDDLNivelAcesso()
        {
            ddlAtivo.DataSource = Enum.GetNames(typeof(Ativo));
            ddlAtivo.DataBind();
        }


        public void LimparBusca()
        {
            gvUsuario.DataSource = null;
            gvUsuario.DataBind();
        }

        public void LimparFormulario()
        {
            lblUsuarioNovoTitulo.Text = "Novo Usuário";
            lblUsuarioNovoTitulo.CssClass = "fa fa-plus-circle";

            hdUsuarioID.Value = "0";
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
            ddlUnidade_fis.SelectedValue = null;
            ddlSetor.SelectedValue = null;
            ddlAtivo.SelectedValue = null;
                      
        }
        

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Usuário

        Usuario usuario;
        UsuarioBO usuarioBO;
        IList<Usuario> listaUsuario;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();

                usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                usuario._Usuario = txtUsuario.Text;
                usuario._Senha = txtSenha.Text;
                usuario._Unidade_fis = ddlUnidade_fis.SelectedValue;
                usuario._Setor = ddlSetor.SelectedValue;
                usuario._Ativo = (Ativo)Enum.Parse(typeof(Ativo), ddlAtivo.SelectedValue);


                usuarioBO = new UsuarioBO();
                usuarioBO.Salvar(usuario);

                if (usuario._UsuarioID != 0)
                {
                    if (gvUsuario.Rows.Count == 1)
                    {
                        int id = usuario._UsuarioID;
                        usuario = usuarioBO.BuscarPorID(id);

                        listaUsuario = new List<Usuario>();
                        listaUsuario.Add(usuario);

                        gvUsuario.DataSource = listaUsuario;
                        gvUsuario.DataBind();
                    }
                    else if (gvUsuario.Rows.Count > 1)
                    {
                        listaUsuario = new List<Usuario>();
                        listaUsuario = usuarioBO.BuscarTodosUsuarios();
                        gvUsuario.DataSource = listaUsuario;
                        gvUsuario.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUsuarioModal();", true);

                    Mensagem("Usuário Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Usuário Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
                }

                LimparFormulario();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuarioBO = new UsuarioBO();

                usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                usuarioBO.Excluir(usuario);

                Mensagem("Usuário Excluido com Sucesso.", this);

                if (gvUsuario.Rows.Count == 1)
                {
                    int id = usuario._UsuarioID;
                    usuario = usuarioBO.BuscarPorID(id);
                    gvUsuario.DataSource = usuario;
                    gvUsuario.DataBind();
                }
                else if (gvUsuario.Rows.Count > 1)
                {
                    listaUsuario = new List<Usuario>();
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUsuarioModal();", true);

                LimparFormulario();
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


        protected void lkbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();

                    txtBuscarPorNome.Text = string.Empty;

                }
                else if (ddlBuscarPorSetor.SelectedValue != "0")
                {
                    listaUsuario = usuarioBO.BuscarPorSetor(ddlBuscarPorSetor.SelectedValue);
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();

                    ddlBuscarPorSetor.Text = null;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuarioBO = new UsuarioBO();

                int id = Convert.ToInt32(gvUsuario.SelectedDataKey.Value);
                usuario = usuarioBO.BuscarPorID(id);

                hdUsuarioID.Value = usuario._UsuarioID.ToString();
                txtUsuario.Text = usuario._Usuario;
                txtSenha.Text = usuario._Senha;
                ddlUnidade_fis.SelectedValue = usuario._Unidade_fis.ToString();
                ddlSetor.SelectedValue = usuario._Setor.ToString();
                ddlAtivo.SelectedValue = usuario._Ativo.ToString();


                lblUsuarioNovoTitulo.Text = "Atualizar Usuário";
                lblUsuarioNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
                
          
    }
}