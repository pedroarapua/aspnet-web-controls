<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Pagina.aspx.cs"
    Inherits="Web.Controls.Test.Pagina" %>

<%@ Register Assembly="Web.Controls.Components" Namespace="Web.Controls.Components"
    TagPrefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:MultiView ID="mtvConteudo" runat="server" ActiveViewIndex="0">
            <asp:View ID="mkvBusca" runat="server">
                <asp:Panel ID="pnlBusca" runat="server">
                    <div class="form">
                        <div class="titleForm">
                            Gerenciar Clientes
                        </div>
                        <WC:WTextBox ID="txtCodigoBusca" runat="server" Required="true" MaxLength="10" TypeTextField="Date"
                            Caption="Código" ValidationGroup="vgPesquisar" />
                        <WC:WNumberBox ID="txtTituloBusca" runat="server" Required="true" MaxLength="10"
                            Caption="Descrição" AllowNegative="true" CentsLimit="2" CentsSeparator="," ThousandsSeparator="."
                            BubbleTip=" adf da fas dfads a" ValidationGroup="vgPesquisar" />
                        <WC:WDropDownList ID="ddlTesteBusca" runat="server" Required="true" Caption="asdf"
                            BubbleTip=" adf da fas dfads a" ValidationGroup="vgPesquisar">
                        </WC:WDropDownList>
                        <WC:WRadioButtonList runat="server" ID="rdbStatus" Caption="Status" Required="true"
                            BubbleTip=" adf da fas dfads a" ValidationGroup="vgPesquisar">
                            <asp:ListItem Text="Todos" Value="0" />
                            <asp:ListItem Text="Ativo" Value="1" />
                            <asp:ListItem Text="Inativo" Value="2" />
                        </WC:WRadioButtonList>
                        <div class="divBotoes">
                            <WC:WButton ID="lnkPesquisar" runat="server" Text="Pesquisar" IconPrimary="ui-icon-search"
                                OnClick="lnkPesquisar_Click">
                                <Listeners>
                                    <WC:ButtonListener Fn="function(){ return ValidateForm('vgPesquisar'); }" Type="click" />
                                </Listeners>
                            </WC:WButton>
                            <WC:WButton ID="lnkLimpar" runat="server" Text="Limpar" IconPrimary="ui-icon-trash"
                                OnClick="lnkLimpar_Click">
                            </WC:WButton>
                            <WC:WButton ID="lnkNovo" runat="server" Text="Novo" IconPrimary="ui-icon-circle-plus"
                                OnClick="lnkNovo_Click">
                            </WC:WButton>
                        </div>
                        <asp:ValidationSummary runat="server" ValidationGroup="vgPesquisar" EnableClientScript="true"
                            DisplayMode="BulletList" ShowMessageBox="false" ShowSummary="false" />
                    </div>
                    <WC:WGrid runat="server" ID="grdTeste" AutoGenerateColumns="true" OnPageIndexChange="grdTeste_OnPageIndexChange"
                        ShowCaption="false" Caption="Caption" Title="teste" AllowPaging="true" BubbleTip=" adf da fas dfads a">
                        <FooterStyle BorderWidth="0" />
                    </WC:WGrid>
                </asp:Panel>
            </asp:View>
            <asp:View ID="mkvManter" runat="server">
                <asp:Panel ID="pnlFormularioEdicao" runat="server">
                    <div class="form">
                        <div class="titleForm">
                            Cadastro/Alteração
                        </div>
                        <WC:WTextBox ID="txtCodigo" runat="server" Required="true" MaxLength="10" Caption="Código"
                            BubbleTip=" adf da fas dfads a" TypeTextField="CNPJ" ValidationGroup="vgSalvar" />
                        <WC:WTextBox ID="txtTitulo" runat="server" Required="true" MaxLength="50" Caption="Descrição"
                            BubbleTip=" adf da fas dfads a" TypeTextField="CPF" ValidationGroup="vgSalvar" />
                        <WC:WCheckBox ID="chkStatus" runat="server" Caption="Ativo" BubbleTip=" adf da fas dfads a" />
                        <div class="divBotoes">
                            <WC:WButton runat="server" ID="lnkSalvar" Text="Salvar" IconPrimary="ui-icon-disk"
                                OnClick="lnkSalvar_Click">
                                <Listeners>
                                    <WC:ButtonListener Fn="function(){ return ValidateForm('vgSalvar'); }" Type="click" />
                                </Listeners>
                            </WC:WButton>
                            <WC:WButton runat="server" ID="lnkCancelar" Text="Cancelar" IconPrimary="ui-icon-cancel"
                                OnClick="lnkCancelar_Click">
                            </WC:WButton>
                            <asp:LinkButton runat="server" OnClick="lnkCancelar_Click" Text="Cancelar 2"></asp:LinkButton>
                        </div>
                        <asp:ValidationSummary ID="vsCentroCusto" runat="server" ValidationGroup="vgSalvar"
                            EnableClientScript="true" DisplayMode="BulletList" ShowMessageBox="false" ShowSummary="false" />
                    </div>
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
