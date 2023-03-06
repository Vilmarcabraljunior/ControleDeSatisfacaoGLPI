<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageInterna.master" AutoEventWireup="true" CodeBehind="pgUsuarioNovo.aspx.cs" Inherits="CamadaApresentacao.pgUsuarioNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ConteudoInterno" runat="server">

    <!--Área do Usuário------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------>
    <!--Panel para gravar ou buscar um Usuário-->
    <asp:Panel ID="pnlPesquisar" runat="server">
        <div class="panel panel-light">
            <div class="panel-heading">
                <h3 class="panel-title">Usuário</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <asp:LinkButton ID="lkbNovo" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lkbNovo_Click"><i class="fa fa-plus-circle"> Novo Usuário</i></asp:LinkButton>
                        <asp:LinkButton ID="lkbConsultar" runat="server" CssClass="btn btn-primary btn-sm" data-toggle="modal" data-target="#BuscarUsuarioModal"><i class="fa fa-search">Buscar Usuário</i></asp:LinkButton>
                    </div>
                </div>
            </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
    </asp:Panel>

    <!--Script para reabrir modal Novo Usuário-->
    <script type="text/javascript">
        function openNovoUsuarioModal() {
            $('#NovoUsuarioModal').modal('show');
        }
    </script>

    <!-- Modal Novo Usuário -->
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="NovoUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 700px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <asp:Label ID="lblUsuarioNovoTitulo" runat="server" Text="Novo Usuário" CssClass="fa fa-plus-circle"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HiddenField ID="hdUsuarioID" runat="server" Value="0" />
                            <div class="row">
                            </div>
                            <div class="row">
                                <div class="col-md-9 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="*usuário:"></asp:Label>
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control input-sm" placeholder="Digite o seu usuário."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5 col-md-offset-1">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="*Senha:"></asp:Label>
                                        <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control input-sm" placeholder="Digite a sua senha."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4 ">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="Ativo:"></asp:Label>
                                        <asp:DropDownList ID="ddlAtivo" runat="server" class="form-control input-sm" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5 col-md-offset-1 ">
                                    <div class="form-group">
                                        <asp:Label ID="Label4" runat="server" Text="*Unidade física:"></asp:Label>
                                        <asp:DropDownList ID="ddlUnidade_fis" runat="server" class="form-control input-sm">
                                            <asp:ListItem Value="0">>>>Selecione<<<</asp:ListItem>
                                            <asp:ListItem Value="ATHENAS">ATHENAS</asp:ListItem>
                                            <asp:ListItem Value="FAMETA">FAMETA</asp:ListItem>
                                            <asp:ListItem Value="FAP">FAP</asp:ListItem>
                                            <asp:ListItem Value="FAPAN">FAPAN</asp:ListItem>
                                            <asp:ListItem Value="FSP">FSP</asp:ListItem>
                                            <asp:ListItem Value="UNIJIPA">UNIJIPA</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4 ">
                                    <div class="form-group">
                                        <asp:Label ID="Label7" runat="server" Text="*Setor:"></asp:Label>
                                        <asp:DropDownList ID="ddlSetor" runat="server" class="form-control input-sm">
                                            <asp:ListItem Value="0">>>>Selecione<<<</asp:ListItem>
                                            <asp:ListItem Value="Biblioteca">Biblioteca</asp:ListItem>
                                            <asp:ListItem Value="CoordCurso">CoordCurso</asp:ListItem>
                                            <asp:ListItem Value="CoordPedagogica">CoordPedagogica</asp:ListItem>
                                            <asp:ListItem Value="CoordPosGraduacao">CoordPosGraduacao</asp:ListItem>
                                            <asp:ListItem Value="DirSecretaria">DirSecretaria</asp:ListItem>
                                            <asp:ListItem Value="Direcao">Direção</asp:ListItem>
                                            <asp:ListItem Value="EGP">EGP</asp:ListItem>
                                            <asp:ListItem Value="Financeiro">Financeiro</asp:ListItem>
                                            <asp:ListItem Value="Marketing">Marketing</asp:ListItem>
                                            <asp:ListItem Value="NEAD">NEAD</asp:ListItem>
                                            <asp:ListItem Value="Juridico">Jurídico</asp:ListItem>
                                            <asp:ListItem Value="Pedagogico">Pedagogico</asp:ListItem>
                                            <asp:ListItem Value="RH">RH</asp:ListItem>
                                            <asp:ListItem Value="SecAtendimento">SecAtendimento</asp:ListItem>
                                            <asp:ListItem Value="TI">TI</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-md-12 col-md-offset-1">
                                    <asp:LinkButton ID="lkbSalvar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lkbSalvar_Click"><i class="fa fa-check"> Salvar</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbExcluirModal" runat="server" CssClass="btn btn-danger btn-sm" data-toggle="modal" data-target="#ExcluirModal"><i class="fa fa-times"> Excluir</i></asp:LinkButton>
                                    <asp:LinkButton ID="lkbCancelar" runat="server" CssClass="btn btn-default  btn-sm" OnClick="lkbCancelar_Click"><i class="fa fa-reply"> Cancelar</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--Script para reabrir modal Novo Usuário-->
    <script type="text/javascript">
        function openGridViewUsuarioModal() {
            $('#GridViewUsuarioModal').modal('show');
        }
    </script>

    <!-- Modal GridView com os dados do  Usuário -->
    <div class="modal fade" id="GridViewUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" style="width: 1200px;" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Selecione um usuário</i></h3>
                        </div>
                        <div class="panel-body">
                            <!-- Table -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvUsuario" runat="server" class="table table-hover table-condensed" GridLines="None" AutoGenerateColumns="False" DataKeyNames="_UsuarioID" OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="_Usuario" HeaderText="Usuário" />
                                                <asp:BoundField DataField="_Unidade_fis" HeaderText="Unidade Física" />
                                                <asp:BoundField DataField="_Setor" HeaderText="setor" />
                                                <asp:BoundField DataField="_Ativo" HeaderText="Ativo" />
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnSelecionar" runat="server" CausesValidation="False" CssClass="btn btn-primary btn-xs" CommandName="Select"><i class="fa fa-check"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>Nenhum usuário encontrado.</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Opções de Buscar Usuário -->
    <div class="modal fade" id="BuscarUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title"><i class="fa fa-search">Opções de Busca</i></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBuscarPorNome" runat="server" CssClass="form-control input-sm" placeholder="Digite o Nome do usuário."></asp:TextBox>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lkbBuscarFuncionario" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlBuscarPorSetor" runat="server" class="form-control input-sm">
                                            <asp:ListItem Value="0">>>>Selecione o setor<<<</asp:ListItem>
                                            <asp:ListItem Value="Biblioteca">Biblioteca</asp:ListItem>
                                            <asp:ListItem Value="CoordCurso">CoordCurso</asp:ListItem>
                                            <asp:ListItem Value="CoordPedagogica">CoordPedagogica</asp:ListItem>
                                            <asp:ListItem Value="CoordPosGraduacao">CoordPosGraduacao</asp:ListItem>
                                            <asp:ListItem Value="DirSecretaria">DirSecretaria</asp:ListItem>
                                            <asp:ListItem Value="Direcao">Direção</asp:ListItem>
                                            <asp:ListItem Value="EGP">EGP</asp:ListItem>
                                            <asp:ListItem Value="Financeiro">Financeiro</asp:ListItem>
                                            <asp:ListItem Value="Marketing">Marketing</asp:ListItem>
                                            <asp:ListItem Value="NEAD">NEAD</asp:ListItem>
                                            <asp:ListItem Value="Juridico">Jurídico</asp:ListItem>
                                            <asp:ListItem Value="Pedagogico">Pedagogico</asp:ListItem>
                                            <asp:ListItem Value="RH">RH</asp:ListItem>
                                            <asp:ListItem Value="SecAtendimento">SecAtendimento</asp:ListItem>
                                            <asp:ListItem Value="TI">TI</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="LinkButton12" runat="server" CssClass="btn btn-primary btn-sm" OnClick="lkbBuscar_Click"><i class="fa fa-search">Buscar</i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para excluir um Usuário-->
    <div class="modal fade" id="ExcluirModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 400px;">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">Excluir ?</h3>
                        </div>
                        <div class="panel-body">
                            <h5><strong>Tem Certeza que Deseja Excluir este usuário ?</strong></h5>

                            <br />

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:LinkButton ID="lkbExcluir" runat="server" CssClass="btn btn-danger btn-sm" OnClick="lkbExcluir_Click"><i class="fa fa-times"> Excluir</i></asp:LinkButton>
                                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-reply">Cancelar</i></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
