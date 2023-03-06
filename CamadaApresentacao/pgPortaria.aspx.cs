using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocio.MODEL;
using CamadaNegocio.BO;


namespace CamadaApresentacao
{
    public partial class pgPortaria : System.Web.UI.Page
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
                    lkbAdicionarNovoArquivo.Visible = true;
                }
                else if (usuario._Setor == "Juridico" && usuario._Unidade_fis == "ATHENAS")
                {
                    pnlPortaria.Visible = true;
                    lkbAdicionarNovoArquivo.Visible = true;
                }

                #endregion

            }
            else
            {
                Response.Redirect("pgCarregamentoSaida.aspx");
            }

            #endregion

            #region Metodo Iniciação

            CarregarArquivos();

            #endregion

        }

        #region Metodo carregar arquivos
        public void CarregarArquivos()
        {
            string caminhoDiretorio = Path.Combine(@"C:\inetpub\ftproot\RegimentoInterno");

            if (!Directory.Exists(caminhoDiretorio))
            {
                Directory.CreateDirectory(caminhoDiretorio);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Arquivo", typeof(string));
            dt.Columns.Add("Inserido", typeof(string));
            dt.Columns.Add("Tamanho", typeof(string));

            foreach (string strFile in Directory.GetFiles(Path.Combine(caminhoDiretorio)))
            {
                FileInfo fi = new FileInfo(strFile);
                dt.Rows.Add(fi.Name, fi.CreationTime.ToString("dd/MM/yyyy"), fi.Length);

            }

            gvPortaria.DataSource = dt;
            gvPortaria.DataBind();
        }
        #endregion

        #region Mensageiro
        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Evento Salvar Arquivos

        protected void lkbAdicionarNovoArquivo_Click(object sender, EventArgs e)
        {
            pnlAdicionarNovoArquivo.Visible = true;
            pnlAqruivosGV.Visible = false;
        }

        protected void lkbSalvarPDF_Click(object sender, EventArgs e)
        {
            try
            {

                if (fuPdfPortaria.HasFile)
                {
                    if ((fuPdfPortaria.PostedFile.ContentType == "application/pdf"))
                    {
                        if (Convert.ToInt64(fuPdfPortaria.PostedFile.ContentLength) < 40000000)
                        {
                            string caminhoDiretorio = Path.Combine(@"C:\inetpub\ftproot\RegimentoInterno");
                            string caminhoDiretorioBackUp = Path.Combine(@"C:\RegimentoInternoBackUp");

                            if (!Directory.Exists(caminhoDiretorio))
                            {
                                Directory.CreateDirectory(caminhoDiretorio);
                            }

                            string nomeArquivo = Path.GetFileName(fuPdfPortaria.PostedFile.FileName);
                            fuPdfPortaria.SaveAs(Path.Combine(caminhoDiretorio, nomeArquivo));
                            fuPdfPortaria.SaveAs(Path.Combine(caminhoDiretorioBackUp, nomeArquivo));

                            DataTable dt = new DataTable();
                            dt.Columns.Add("Arquivo", typeof(string));
                            dt.Columns.Add("Inserido", typeof(string));
                            dt.Columns.Add("Tamanho", typeof(string));

                            foreach (string strFile in Directory.GetFiles(Path.Combine(caminhoDiretorio)))
                            {
                                FileInfo fi = new FileInfo(strFile);
                                dt.Rows.Add(fi.Name, fi.CreationTime.ToString("dd/MM/yyyy"), fi.Length);

                            }

                            gvPortaria.DataSource = dt;
                            gvPortaria.DataBind();

                            Mensagem("Salvo com sucesso.", this);

                        }
                        else
                        {
                            Mensagem("O tamanho do arquivo tem que ser menor que 40MB.", this);
                        }
                    }
                    else
                    {
                        Mensagem("O arquivo tem que ser em formado pdf.", this);
                    }
                }

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            pnlAdicionarNovoArquivo.Visible = false;
            pnlAqruivosGV.Visible = true;

            CarregarArquivos();
        }

        #endregion

        #region evento mostrar Arquivos
        protected void gvPortaria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lblProdId = (LinkButton)row.FindControl("lkbDownloadPDF");
                string s = lblProdId.Text;
                if (e.CommandName == "Download")
                {
                    string caminhoDiretorio = Path.Combine(@"C:\inetpub\ftproot\RegimentoInterno");
                    string path = Path.Combine(@"C:\inetpub\ftproot\RegimentoInterno\" + e.CommandArgument);
                    FileInfo file = new FileInfo(path);
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(file.FullName);
                }

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion
              

    }
}