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
    public partial class pgIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificação nivel de acesso
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

        }

    }
}