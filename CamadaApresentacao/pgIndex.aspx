<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pgIndex.aspx.cs" Inherits="CamadaApresentacao.pgIndex" %>

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
	
                <img class="img-fluid" src="assets/img/logoAzul.png" alt="" style="height: 30px; margin: 15px">
                </br>
       
                <a href="#" class="simple-text logo-normal">Portal Administrativo 
                </a>
            </div>
            <div class="sidebar-wrapper">
                <ul class="nav">
                    <li class="nav-item active  ">
                        <a class="nav-link" href="pgIndex.aspx">
                            <i class="material-icons">dashboard</i>
                            <p>Dashboard</p>
                        </a>
                    </li>
                    <li class="nav-item">
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
                                <a class="nav-link" href="#">
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
                    <h4><strong>Sistemas</strong></h4>
                    <div class="row">

                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="card card-stats">
                                <div class="card-header card-header-info card-header-icon">
                                    <div class="card-icon">
                                        <img class="img-fluid" width="75px" src="Imagem/Lyceum-logo.png" max-width="100%" max-height="100%" />
                                    </div>
                                    <p class="card-category">Lyceum</p>

                                    <a href="https://athenas.lyceum.com.br/Secretaria" target="_blank">Acessar Sistema</a>

                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">date_range</i>SI de Gestão Educacional

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="card card-stats">
                                <div class="card-header card-header-info card-header-icon">
                                    <div class="card-icon">
                                        <img class="img-fluid" width="80px" src="Imagem/Glpi-logo.png" max-width="100%" max-height="100%" />
                                    </div>
                                    <p class="card-category">GLPI</p>

                                    <a href="http://cticathenas.tk/glpi/" target="_blank">Acessar Sistema</a>

                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">date_range</i>SI de Gestão de Serviços

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="card card-stats">
                                <div class="card-header card-header-info card-header-icon">
                                    <div class="card-icon">
                                        <img class="img-fluid" width="80px" src="Imagem/Sap-Logo.png" max-width="100%" max-height="100%" />
                                    </div>
                                    <p class="card-category">SAP</p>

                                    <a href="https://educationone.gennera.com.br/RDWeb/Pages/en-US/login.aspx?ReturnUrl=/RDWeb/Pages/en-US/Default.aspx/" target="_blank">Acessar Sistema</a>

                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">date_range</i>SI de Gestão Educacional

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <h4><strong>Sistema Descontinuado</strong></h4>
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-3">
                            <div class="card card-stats">
                                <div class="card-header card-header-info card-header-icon">
                                    <div class="card-icon">
                                        <img class="img-fluid" width="80px" src="Imagem/Glpi-logo.png" max-width="100%" max-height="100%" />
                                    </div>
                                    <p class="card-category">GLPI - [APENAS CONSULTA]</p>

                                    <a href="http://131.108.61.218:8008" target="_blank">Acessar Sistema</a>

                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">date_range</i><b>[APENAS CONSULTA]</b>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <h4><strong>Relatórios Gerenciais</strong></h4>
                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="card card-chart">
                                <div class="card-header card-header-success">
                                    <div class="ct-chart" id="dailySalesChart"></div>
                                </div>
                                <div class="card-body">
                                    <h6 class="card-title">Matriculas e Pré-Matriculas</h6>
                                    <p class="card-category">
                                        <a href="https://app.powerbi.com/view?r=eyJrIjoiZDdmNmZjYzItMzg3OS00ZjQ2LTliN2ItMzJkNzg5MDBlYTBjIiwidCI6ImI0MWVjZjFlLTBkMTAtNGY1Yi05YzI0LTg0ZWIzOTc1MjFmMCJ9" target="_blank">Acessar Relatório </a>
                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">access_time</i> Atualizado a 30 minutos
                 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="card card-chart">
                                <div class="card-header card-header-warning">
                                    <div class="ct-chart" id="websiteViewsChart"></div>
                                </div>
                                <div class="card-body">
                                    <h6 class="card-title">Rematrículas</h6>
                                    <a href="https://app.powerbi.com/view?r=eyJrIjoiZDJkNjZlZGMtNTZhYy00YmU2LTg2MGYtYzVkNDFiZThhYzNmIiwidCI6ImI0MWVjZjFlLTBkMTAtNGY1Yi05YzI0LTg0ZWIzOTc1MjFmMCJ9" target="_blank">Acessar Relatório </a>
                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">access_time</i> Atualizado a 30 minutos
                 
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="card card-chart">
                                <div class="card-header card-header-danger">
                                    <div class="ct-chart" id="completedTasksChart"></div>
                                </div>
                                <div class="card-body">
                                    <h6 class="card-title">Pós-Graduação</h6>
                                    <a href="https://app.powerbi.com/view?r=eyJrIjoiOWZhYWRjYzYtZDBkMC00ZjYzLTg0MzUtYzhhZDQ4ZDY1YzAxIiwidCI6ImI0MWVjZjFlLTBkMTAtNGY1Yi05YzI0LTg0ZWIzOTc1MjFmMCJ9" target="_blank">Acessar Relatório </a>
                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">access_time</i> Atualizado a 30 minutos
                 
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <div class="card card-chart">
                                <div class="card-header card-header-primary">
                                    <img class="img-fluid" src="Imagem/chartLogo.png" max-width="100%" max-height="100%" />
                                </div>
                                <div class="card-body">
                                    <h6 class="card-title">Aluno Fera</h6>
                                    <a href="https://app.powerbi.com/view?r=eyJrIjoiMjk1NWRjMmItMGIwOC00YTBjLTk2YmEtOTMwOGNlMDQ4YmNlIiwidCI6ImI0MWVjZjFlLTBkMTAtNGY1Yi05YzI0LTg0ZWIzOTc1MjFmMCJ9" target="_blank">Acessar Relatório </a>
                                </div>
                                <div class="card-footer">
                                    <div class="stats">
                                        <i class="material-icons">access_time</i> Atualizado a 30 minutos
                 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <h4><strong>Calendário Acadêmico</strong></h4>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="card card-chart">
                                <div class="card-body">
                                    <asp:Panel ID="pnlCalendarioAcademico" runat="server">
                                        <iframe src="https://calendar.google.com/calendar/b/2/embed?showTitle=0&amp;height=600&amp;wkst=1&amp;bgcolor=%23FFFFFF&amp;src=gti4%40athenaseducacional.com.br&amp;color=%231B887A&amp;src=pt.brazilian%23holiday%40group.v.calendar.google.com&amp;color=%23125A12&amp;ctz=America%2FBoa_Vista" style="border-width: 0" class="table-responsive" height="600" frameborder="0" scrolling="yes"></iframe>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
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
