<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgLoginNovo.aspx.cs" Inherits="CamadaApresentacao.pgLoginNovo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-133809415-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-133809415-1');
    </script>

    <!-- Required meta tags-->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="au theme template">
    <meta name="author" content="Hau Nguyen">
    <meta name="keywords" content="au theme template">

    <!-- Title Page-->
    <title>Portal Administrativo</title>
    <link rel="icon" href="Imagem/AthenasLogo4.png" />

    <!-- Fontfaces CSS-->
    <link href="css/font-face.css" rel="stylesheet" media="all">
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <link href="vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all">
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">

    <!-- Bootstrap CSS-->
    <link href="vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all">

    <!-- Vendor CSS-->
    <link href="vendor/animsition/animsition.min.css" rel="stylesheet" media="all">
    <link href="vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all">
    <link href="vendor/wow/animate.css" rel="stylesheet" media="all">
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all">
    <link href="vendor/slick/slick.css" rel="stylesheet" media="all">
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="css/theme.css" rel="stylesheet" media="all">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="page-wrapper">
                <div class="page-content--bge5">
                    <div class="container">
                        <div class="login-wrap">
                            <div class="login-content">
                                <div class="login-logo">
                                    <a href="#">
                                        <img src="Imagem/AthenasLogo5.png" width="400px" height="100px" alt="Portal Athenas" />
                                    </a>
                                    <div align="center">
                                        <b>PORTAL ADMINISTRATIVO</b>
                                    </div>
                                </div>

                                <div class="login-form">
                                    <div class="form-group">
                                        <label>Usuário</label>
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control input-sm" placeholder="Digite seu usuário."></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label>Senha</label>
                                        <asp:TextBox ID="txtSenha" runat="server" class="form-control input-sm" placeholder="Digite sua senha." AutoPostBack="true" OnTextChanged="txtSenha_TextChanged" TextMode="Password"></asp:TextBox>
                                    </div>

                                    <asp:LinkButton ID="lkbEntrar" runat="server" class="btn btn-primary btn-block btn-xl" ToolTip="Clique para Entrar" OnClick="lkbEntrar_Click"><i class="fa fa-share"> Entrar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelar" runat="server" class="btn btn-default btn-block btn-xl" ToolTip="Clique para Cancelar" OnClick="lkbCancelar_Click"><i class="fa fa-reply"> Limpar</i></asp:LinkButton>
                                    <div align="right">
                                        <asp:LinkButton ID="lkbRecuperarSenhaAbrir" runat="server" href="#RecuperarSenhaModal" data-toggle="modal">Esqueceu sua senha?</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <!-- Jquery JS-->
            <script src="vendor/jquery-3.2.1.min.js"></script>
            <!-- Bootstrap JS-->
            <script src="vendor/bootstrap-4.1/popper.min.js"></script>
            <script src="vendor/bootstrap-4.1/bootstrap.min.js"></script>
            <!-- Vendor JS       -->
            <script src="vendor/slick/slick.min.js">
            </script>
            <script src="vendor/wow/wow.min.js"></script>
            <script src="vendor/animsition/animsition.min.js"></script>
            <script src="vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
            </script>
            <script src="vendor/counter-up/jquery.waypoints.min.js"></script>
            <script src="vendor/counter-up/jquery.counterup.min.js">
            </script>
            <script src="vendor/circle-progress/circle-progress.min.js"></script>
            <script src="vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
            <script src="vendor/chartjs/Chart.bundle.min.js"></script>
            <script src="vendor/select2/select2.min.js">
            </script>

            <!-- Main JS-->
            <script src="js/main.js"></script>
        </div>
        <div>
            <!--Área para Alterar/recuperar/mostrar a senha do Usuário---------------------------------------------------------------------------------------------------------------------------------------------------------------->

            <!--Script para abrir o modal para Alterar a senha do Usuário-->
            <script type="text/javascript">
                function openAlterarSenhaModal() {
                    $('#AlterarSenhaModal').modal('show');
                }
            </script>

            <!-- Modal para Alterar a senha do Usuário -->
            <div class="modal fade" data-keyboard="false" data-backdrop="static" id="AlterarSenhaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" style="width: 400px;" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title text-center"><i class="">Criação de senha</i></h4>
                                    <h4 class="panel-title text-center"><i class="">Primeiro Acesso</i></h4>
                                </div>
                                <br />
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-9 col-md-offset-1">
                                            <div class="input-group">
                                                <span class="input-group-btn">

                                                    <!--campo que guarda no id do usuário para Alterar a senha-->
                                                    <asp:HiddenField ID="hdUsuarioAlterarSenhaID" Value="0" runat="server" />

                                                    <asp:LinkButton ID="lkbNovaSenhaImagem" runat="server" CssClass="btn btn-default btn-sm"><i class="fa fa-lock"></i></asp:LinkButton>
                                                </span>
                                                <asp:TextBox ID="txtNovaSenha" runat="server" class="form-control input-sm" placeholder="Digite a nova senha."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row">
                                        <div class="col-md-9 col-md-offset-1">
                                            <div class="input-group">
                                                <span class="input-group-btn">
                                                    <asp:LinkButton ID="lkbConfirmarSenhaImagem" runat="server" CssClass="btn btn-default btn-sm"><i class="fa fa-lock"></i></asp:LinkButton>
                                                </span>
                                                <asp:TextBox ID="txtConfirmarSenha" runat="server" class="form-control input-sm" placeholder="Repita a nova senha."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row">
                                        <div class="col-md-9 col-md-offset-1">
                                            <asp:LinkButton ID="lkbAlterarSenha" runat="server" class="btn btn-primary btn-sm" ToolTip="Clique para Alterar a senha" OnClick="lkbAlterarSenha_Click"><i class="fa fa-check"> Alterar</i></asp:LinkButton>
                                            <asp:LinkButton ID="lkbCancelarAlterarSenha" runat="server" class="btn btn-default btn-sm" ToolTip="clique para Cancelar" OnClick="lkbCancelarAlterarSenha_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--------------------------------------------------------------------------------------------------------------------------------------------------------------------->

            <!--Script para abrir o modal para recuperar a senha do usuário-->
            <script type="text/javascript">
                function openRecuperarSenhaModal() {
                    $('#RecuperarSenhaModal').modal('show');
                }
            </script>

            <!-- Modal para recuperar senha do usuário -->
            <div class="modal fade" data-keyboard="false" data-backdrop="static" id="RecuperarSenhaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" style="width: 400px;" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title text-center"><i class="">Recuperação de senha</i></h4>
                                </div>
                                <br />
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-9 col-md-offset-1">
                                            <asp:TextBox ID="txtUsuarioRecuperarSenha" runat="server" class="form-control input-sm" placeholder="Digite o seu usuário."></asp:TextBox>
                                        </div>
                                    </div>

                                    <br />
                                    <br />

                                    <div class="row">
                                        <div class="col-md-9 col-md-offset-1">
                                            <asp:LinkButton ID="lkbRecuperarSenha" runat="server" class="btn btn-primary btn-sm" ToolTip="Clique para Alterar a senha" OnClick="lkbRecuperarSenha_Click"><i class="fa fa-check"> Recuperar</i></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-default btn-sm" ToolTip="clique para Cancelar" OnClick="lkbCancelarRecuperarSenha_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--------------------------------------------------------------------------------------------------------------------------------------------------------------------->

            <!--Script para abrir o modal para mostrar a senha do Usuário-->
            <script type="text/javascript">
                function openMostrarSenhaModal() {
                    $('#MostrarSenhaModal').modal('show');
                }
            </script>

            <!-- Modal para mostrar a senha do usuário -->
            <div class="modal fade" data-keyboard="false" data-backdrop="static" id="MostrarSenhaModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" style="width: 400px;" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <h4 class="panel-title text-center"><i class="">Sua senha</i></h4>
                                </div>
                                <br />
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvMostrarSenha" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_UsuarioID">
                                            <Columns>
                                                <asp:BoundField DataField="_Usuario" HeaderText="Usuário" />
                                                <asp:BoundField DataField="_Senha" HeaderText="Senha" />

                                            </Columns>
                                            <EmptyDataTemplate>Nenhum usuário encontrado.</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>

                                    <asp:LinkButton ID="lbCancelarMostrarSenha" runat="server" class="btn btn-default btn-sm" ToolTip="clique para Cancelar" OnClick="lbCancelarMostrarSenha_Click"><i class="fa fa-reply"> fechar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>

</body>
</html>
