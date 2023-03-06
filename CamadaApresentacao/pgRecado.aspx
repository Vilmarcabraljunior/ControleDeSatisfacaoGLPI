<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgRecado.aspx.cs" Inherits="CamadaApresentacao.pgCalendAcademico" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head id="Head1" runat="server">

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-133809415-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-133809415-1');
    </script>

    <title>Portal Administrativo</title>
    <link rel="icon" href="Imagem/AthenasLogo4.png" />

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
    <!-- Material Kit CSS -->
    <link href="assets/css/material-dashboard.css?v=2.1.1" rel="stylesheet" />
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="assets/demo/demo.css" rel="stylesheet" />

</head>

<body>
    <div class="wrapper ">
        <div class="sidebar" data-color="azure" data-background-color="white" data-image="assets/img/sidebar-1.jpg">
            <!--
        Tip 1: You can change the color of the sidebar using: data-color="purple | azure | green | orange | danger"

        Tip 2: you can also add an image using data-image tag
    -->
            <div class="logo">
                </br> 
	
                <div>
                    <img src="assets/img/logoAzul.png" class="img-fluid" alt="" style="height: 30px; margin: 15px">
                </div>
                </br>
       
                <a href="#" class="simple-text logo-normal">Portal Administrativo 
                </a>
            </div>
            <div class="sidebar-wrapper">
                <ul class="nav">
                    <li class="nav-item">
                        <a class="nav-link" href="pgIndex.aspx">
                            <i class="material-icons">dashboard</i>
                            <p>Dashboard</p>
                        </a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="pgRecado.aspx">
                            <i class="material-icons">textsms</i>
                            <p>Mural Administrativo</p>
                        </a>
                    </li>
                    <asp:Panel ID="pnlPortaria" runat="server" Visible="false">
                        <li class="nav-item">
                            <a class="nav-link" href="pgPortaria.aspx">
                                <i class="material-icons">attach_file</i>
                                <p>Regimento Interno</p>
                            </a>
                        </li>
                    </asp:Panel>
                    <asp:Panel ID="pnlPerfilUsuario" runat="server" Visible="false">
                        <li class="nav-item ">
                            <a class="nav-link" href="pgUsuarioNovo.aspx">
                                <i class="material-icons">person</i>
                                <p>Perfil de Usuario</p>
                            </a>
                        </li>
                    </asp:Panel>

                    <li class="nav-item ">
                        <a class="nav-link" href="pgCarregamentoSaida.aspx">
                            <i class="material-icons">unarchive</i>
                            <p>SAIR</p>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="main-panel">
            <!-- Navbar -->
            <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
                <div class="container-fluid">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="navbar-toggler-icon icon-bar"></span>
                        <span class="navbar-toggler-icon icon-bar"></span>
                        <span class="navbar-toggler-icon icon-bar"></span>
                    </button>
                    <div class="collapse navbar-collapse justify-content-end">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link" href="#pablo">
                                    <i class="material-icons">person</i>
                                    <asp:Label ID="lblUsuarioNomeNivel" runat="server" Text="Label"></asp:Label>
                                </a>
                            </li>
                            <!-- your navbar here -->
                        </ul>
                    </div>
                </div>
            </nav>
            <!-- End Navbar -->
            <div class="content">
                <div class="container-fluid">
                    <form id="formPrincipal" runat="server">

                        <asp:Panel ID="pnlRecadosGV" runat="server" Visible="true">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="card card-chart">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-lg-10 col-md-10 col-sm-10">
                                                    <asp:CheckBoxList ID="ckbCarregarRecados" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Lido ">Lido</asp:ListItem>
                                                        <asp:ListItem Value="Não Lido" Selected="True">Não Lido</asp:ListItem>
                                                    </asp:CheckBoxList>

                                                    <asp:LinkButton ID="lkbCarregarRecados" runat="server" CssClass="btn btn-info btn-sm" OnClick="lkbCarregarRecados_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lkbAbrirNovoRecado" runat="server" CssClass="btn btn-info btn-sm" OnClick="lkbAbrirNovoRecado_Click"><i class="fa fa-plus"></i></asp:LinkButton>

                                                </div>
                                            </div>
                                            <asp:Panel ID="pnlScroll" runat="server" Height="450px" ScrollBars="Vertical">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvRecado" runat="server" class="table table-hover table-condensed table-striped busca" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_RecadoID" OnRowUpdating="gvRecado_RowUpdating" OnRowDeleting="gvRecado_RowDeleting">
                                                        <Columns>

                                                            <asp:BoundField DataField="_DataCadastro" HeaderText="inserido" />
                                                            <asp:BoundField DataField="_Unidade_fis" HeaderText="unidade" />
                                                            <asp:BoundField DataField="_Setor" HeaderText="setor" />
                                                            <asp:BoundField DataField="_Assunto" HeaderText="assunto" />

                                                            <asp:TemplateField ShowHeader="True" HeaderText="ver" ControlStyle-Width="60px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lkbVisualizarRecado" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm" CommandName="Update"><i class="fa fa-eye"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField ShowHeader="True" HeaderText="editar" ControlStyle-Width="60px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lkbEditarRecado" runat="server" CausesValidation="False" CssClass="btn btn-info btn-sm" CommandName="Delete"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <EmptyDataTemplate><b>0 Recados</b></EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div class="card-footer">
                                            <div class="stats">
                                                Mural Administrativo
                 
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnlRecadoNovo" runat="server" Visible="false">
                            <!-- Novo Recado-->
                            <div class="panel panel-success">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <asp:Label ID="lblRecadoNovoTitulo" runat="server" Text="Adicionar Recado" CssClass="fa fa-plus-circle"></asp:Label></h3>
                                </div>
                                <div class="panel-body">
                                    <asp:HiddenField ID="hdRecadoID" runat="server" Value="0" />
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <b>
                                                    <asp:Label ID="Label1" runat="server" Text="Inserido:"></asp:Label></b>
                                                <asp:TextBox ID="txtDataCadastroRecado" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <b>
                                                    <asp:Label ID="Label3" runat="server" Text="*Assunto:"></asp:Label></b>
                                                <asp:TextBox ID="txtAssunto" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-md-offset-1">
                                            <div class="form-group">
                                                <b>
                                                    <asp:Label ID="Label13" runat="server" Text="*Recado:"></asp:Label></b>
                                                <FTB:FreeTextBox ID="txtRecado" runat="server" Height="250px" ValidateRequestMode="Disabled" BackColor="gainsboro" EnableHtmlMode="false"></FTB:FreeTextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <b>
                                                    <asp:Label ID="Label50" runat="server" Text="Link :"></asp:Label></b>
                                                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row">
                                        <div class="col-md-12 col-md-offset-1">
                                            <asp:LinkButton ID="lkbSalvarRecado" runat="server" CssClass="btn btn-info btn-sm" OnClick="lkbSalvarRecado_Click"><i class="fa fa-save"> Salvar</i></asp:LinkButton>
                                            <asp:LinkButton ID="lkbCancelarRecado" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarRecado_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnlRecadoVisualizar" runat="server" Visible="false">
                            <!--  Visualizar recado-->
                            <div class="panel panel-success">

                                <div class="panel-body">
                                    <asp:HiddenField ID="hdDetalhesRecadoID" runat="server" Value="0" />
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <strong>
                                                    <asp:Label ID="Label5" runat="server" Text="Inserido:"></asp:Label></strong>
                                                <asp:Label ID="lblDataCadastroDetalhesRecado" runat="server" CssClass="form-control input-sm"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server" Text="Assunto:"></asp:Label></strong>
                                                <asp:TextBox ID="lblAssuntoDetalhesRecado" runat="server" CssClass="form-control input-sm" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-md-offset-1">
                                            <div class="form-group">
                                                <strong>
                                                    <asp:Label ID="Label8" runat="server" Text="Recado:"></asp:Label></strong>
                                                <br />
                                                <p>
                                                    <FTB:FreeTextBox ID="lblDetalhesRecado" runat="server" Height="250px" ValidateRequestMode="Disabled" BackColor="gainsboro" ReadOnly="true" EnableToolbars="false" EnableHtmlMode="false"></FTB:FreeTextBox>
                                                </p>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-8 col-md-offset-1">
                                            <div class="form-group">
                                                <strong>
                                                    <asp:Label ID="lblRotuloLinkDetalhes" runat="server" Text="Link:" Visible="false"></asp:Label></strong>
                                                <asp:TextBox ID="txtLinkDetalhes" runat="server" CssClass="form-control input-sm" Visible="false" ReadOnly="true"></asp:TextBox>
                                                <asp:LinkButton ID="lkbLinkDetalhes" runat="server" CssClass="form-control input-sm" OnClick="lkbLinkDetalhes_Click" Visible="false"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1">
                                            <strong>
                                                <asp:Label ID="Label2" runat="server" Text="Marcar como lido:" Visible="false"></asp:Label></strong>
                                            <asp:CheckBox ID="CkbLido" runat="server" Visible="false" />
                                        </div>
                                    </div>

                                    <br />

                                    <div class="row">
                                        <div class="col-md-12 col-md-offset-1">
                                            <asp:LinkButton ID="lkbAtualizarDetalhesRecado" runat="server" CssClass="btn btn-info btn-sm" OnClick="lkbAtualizarDetalhesRecado_Click" Visible="false"><i class="fa fa-pencil"> Editar</i></asp:LinkButton>
                                            <asp:LinkButton ID="lkbCancelarDetalhesRecado" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelarDetalhesRecado_Click"><i class="fa fa-reply"> Voltar</i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </form>

                </div>
            </div>
        </div>

        <footer class="footer">
            <div class="container-fluid">
                <nav class="float-left">
                    <ul>
                        <li>
                            <a href="#">Athenas Grupo Educacional
                            </a>
                        </li>
                    </ul>
                </nav>
                <div class="copyright float-right">
                    &copy;
           
                    <script>
                        document.write(new Date().getFullYear())
                    </script>
                    ,   by
           
                    <a href="#">GTI</a>.
         
                </div>
                <!-- your footer here -->
            </div>
        </footer>
    </div>
    </div>
  
  
  


    <script src="assets/js/core/jquery.min.js"></script>
    <script src="assets/js/core/popper.min.js"></script>
    <script src="assets/js/core/bootstrap-material-design.min.js"></script>
    <script src="assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
    <!-- Plugin for the momentJs  -->
    <script src="assets/js/plugins/moment.min.js"></script>
    <!--  Plugin for Sweet Alert -->
    <script src="assets/js/plugins/sweetalert2.js"></script>
    <!-- Forms Validations Plugin -->
    <script src="assets/js/plugins/jquery.validate.min.js"></script>
    <!-- Plugin for the Wizard, full documentation here: https://github.com/VinceG/twitter-bootstrap-wizard -->
    <script src="assets/js/plugins/jquery.bootstrap-wizard.js"></script>
    <!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
    <script src="assets/js/plugins/bootstrap-selectpicker.js"></script>
    <!--  Plugin for the DateTimePicker, full documentation here: https://eonasdan.github.io/bootstrap-datetimepicker/ -->
    <script src="assets/js/plugins/bootstrap-datetimepicker.min.js"></script>
    <!--  DataTables.net Plugin, full documentation here: https://datatables.net/  -->
    <script src="assets/js/plugins/jquery.dataTables.min.js"></script>
    <!--	Plugin for Tags, full documentation here: https://github.com/bootstrap-tagsinput/bootstrap-tagsinputs  -->
    <script src="assets/js/plugins/bootstrap-tagsinput.js"></script>
    <!-- Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
    <script src="assets/js/plugins/jasny-bootstrap.min.js"></script>
    <!--  Full Calendar Plugin, full documentation here: https://github.com/fullcalendar/fullcalendar    -->
    <script src="assets/js/plugins/fullcalendar.min.js"></script>
    <!-- Vector Map plugin, full documentation here: http://jvectormap.com/documentation/ -->
    <script src="assets/js/plugins/jquery-jvectormap.js"></script>
    <!--  Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
    <script src="assets/js/plugins/nouislider.min.js"></script>
    <!-- Include a polyfill for ES6 Promises (optional) for IE11, UC Browser and Android browser support SweetAlert -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/core-js/2.4.1/core.js"></script>
    <!-- Library for adding dinamically elements -->
    <script src="assets/js/plugins/arrive.min.js"></script>
    <!--  Google Maps Plugin    -->
    <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
    <!-- Chartist JS -->
    <script src="assets/js/plugins/chartist.min.js"></script>
    <!--  Notifications Plugin    -->
    <script src="assets/js/plugins/bootstrap-notify.js"></script>
    <!-- Control Center for Material Dashboard: parallax effects, scripts for the example pages etc -->
    <script src="assets/js/material-dashboard.js?v=2.1.1" type="text/javascript"></script>
    <!-- Material Dashboard DEMO methods, don't include it in your project! -->
    <script src="assets/demo/demo.js"></script>

    <!--Referencia do jquery bdt-->
    <link href="jqueryBDT/jquery.bdt.css" rel="stylesheet" />

    <!--Referencia do jquery bdt javascript-->
    <script src="jqueryBDT/jquery.bdt.js"></script>

    <!--Código para buscar automática no gridview bdt-->
    <script>
        $(document).ready(function () {
            $('.busca').bdt();
        });
    </script>

    <script>
        $(document).ready(function () {
            $().ready(function () {
                $sidebar = $('.sidebar');

                $sidebar_img_container = $sidebar.find('.sidebar-background');

                $full_page = $('.full-page');

                $sidebar_responsive = $('body > .navbar-collapse');

                window_width = $(window).width();

                fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

                if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
                    if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
                        $('.fixed-plugin .dropdown').addClass('open');
                    }

                }

                $('.fixed-plugin a').click(function (event) {
                    // Alex if we click on switch, stop propagation of the event, so the dropdown will not be hide, otherwise we set the  section active
                    if ($(this).hasClass('switch-trigger')) {
                        if (event.stopPropagation) {
                            event.stopPropagation();
                        } else if (window.event) {
                            window.event.cancelBubble = true;
                        }
                    }
                });

                $('.fixed-plugin .active-color span').click(function () {
                    $full_page_background = $('.full-page-background');

                    $(this).siblings().removeClass('active');
                    $(this).addClass('active');

                    var new_color = $(this).data('color');

                    if ($sidebar.length != 0) {
                        $sidebar.attr('data-color', new_color);
                    }

                    if ($full_page.length != 0) {
                        $full_page.attr('filter-color', new_color);
                    }

                    if ($sidebar_responsive.length != 0) {
                        $sidebar_responsive.attr('data-color', new_color);
                    }
                });

                $('.fixed-plugin .background-color .badge').click(function () {
                    $(this).siblings().removeClass('active');
                    $(this).addClass('active');

                    var new_color = $(this).data('background-color');

                    if ($sidebar.length != 0) {
                        $sidebar.attr('data-background-color', new_color);
                    }
                });

                $('.fixed-plugin .img-holder').click(function () {
                    $full_page_background = $('.full-page-background');

                    $(this).parent('li').siblings().removeClass('active');
                    $(this).parent('li').addClass('active');


                    var new_image = $(this).find("img").attr('src');

                    if ($sidebar_img_container.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                        $sidebar_img_container.fadeOut('fast', function () {
                            $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                            $sidebar_img_container.fadeIn('fast');
                        });
                    }

                    if ($full_page_background.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                        var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                        $full_page_background.fadeOut('fast', function () {
                            $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                            $full_page_background.fadeIn('fast');
                        });
                    }

                    if ($('.switch-sidebar-image input:checked').length == 0) {
                        var new_image = $('.fixed-plugin li.active .img-holder').find("img").attr('src');
                        var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                        $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                        $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                    }

                    if ($sidebar_responsive.length != 0) {
                        $sidebar_responsive.css('background-image', 'url("' + new_image + '")');
                    }
                });

                $('.switch-sidebar-image input').change(function () {
                    $full_page_background = $('.full-page-background');

                    $input = $(this);

                    if ($input.is(':checked')) {
                        if ($sidebar_img_container.length != 0) {
                            $sidebar_img_container.fadeIn('fast');
                            $sidebar.attr('data-image', '#');
                        }

                        if ($full_page_background.length != 0) {
                            $full_page_background.fadeIn('fast');
                            $full_page.attr('data-image', '#');
                        }

                        background_image = true;
                    } else {
                        if ($sidebar_img_container.length != 0) {
                            $sidebar.removeAttr('data-image');
                            $sidebar_img_container.fadeOut('fast');
                        }

                        if ($full_page_background.length != 0) {
                            $full_page.removeAttr('data-image', '#');
                            $full_page_background.fadeOut('fast');
                        }

                        background_image = false;
                    }
                });

                $('.switch-sidebar-mini input').change(function () {
                    $body = $('body');

                    $input = $(this);

                    if (md.misc.sidebar_mini_active == true) {
                        $('body').removeClass('sidebar-mini');
                        md.misc.sidebar_mini_active = false;

                        $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

                    } else {

                        $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar('destroy');

                        setTimeout(function () {
                            $('body').addClass('sidebar-mini');

                            md.misc.sidebar_mini_active = true;
                        }, 300);
                    }

                    // we simulate the window Resize so the charts will get updated in realtime.
                    var simulateWindowResize = setInterval(function () {
                        window.dispatchEvent(new Event('resize'));
                    }, 180);

                    // we stop the simulation of Window Resize after the animations are completed
                    setTimeout(function () {
                        clearInterval(simulateWindowResize);
                    }, 1000);

                });
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            // Javascript method's body can be found in assets/js/demos.js
            md.initDashboardPageCharts();

        });
    </script>
</body>

</html>
