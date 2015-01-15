<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="Web.Controls.Test.Teste" %>

<%@ Register Assembly="Web.Controls.Components" Namespace="Web.Controls.Components"
    TagPrefix="WC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
    <script type="text/javascript">
        function teste(e, tab)
        {
            return ValidateForm('vgSalvar');
            
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlBusca" runat="server">
            <div class="form">
                <div class="titleForm"> 
                    Gerenciar Clientes
                </div>
                <WC:WTextBox ID="txtCodigoBusca" runat="server" Required="true" MaxLength="10" TypeTextField="Numeric"
                    Caption="Código" ValidationGroup="vgSalvar" />
                <WC:WTextBox ID="txtTituloBusca" runat="server" Required="true" MaxLength="50" Caption="Descrição" TypeTextField="Date" BubbleTip=" adf da fas dfads a"
                    ValidationGroup="vgSalvar" />
                <WC:WDropDownList ID="ddlTesteBusca" runat="server" Required="true" Caption="asdf" BubbleTip=" adf da fas dfads a"
                    ValidationGroup="vgSalvar">
                </WC:WDropDownList>
                <WC:WRadioButtonList runat="server" ID="rdbStatus" Caption="Status" Required="true" BubbleTip=" adf da fas dfads a"
                    ValidationGroup="vgSalvar">
                    <asp:ListItem Text="Todos" Value="0" />
                    <asp:ListItem Text="Ativo" Value="1" />
                    <asp:ListItem Text="Inativo" Value="2" />
                </WC:WRadioButtonList>
                <div class="divBotoes">
                    <WC:WButton ID="lnkPesquisar" runat="server" Text="Pesquisar" IconPrimary="ui-icon-search" OnClick="teste_click">
                        <Listeners>
                            <WC:ButtonListener Fn="function(){ return true; }" Type="click" />
                        </Listeners>
                    </WC:WButton>
                    <WC:WButton ID="lnkLimpar" runat="server" Text="Limpar" IconPrimary="ui-icon-trash"></WC:WButton>
                    <WC:WButton ID="lnkNovo" runat="server" Text="Novo" IconPrimary="ui-icon-circle-plus"></WC:WButton>
                </div>
            </div>
            <WC:WGrid runat="server" ID="grdTeste" AutoGenerateColumns="true" OnPageIndexChange="grdTeste_OnPageIndexChange" ShowCaption="false" Caption="Caption" Title="teste"  AllowPaging="true" BubbleTip=" adf da fas dfads a">
                <FooterStyle BorderWidth="0" />
            </WC:WGrid>
        </asp:Panel>
        <asp:Panel ID="pnlFormularioEdicao" runat="server">
            <div class="form">
                <div class="titleForm"> 
                    Cadastro/Alteração
                </div>
                <WC:WTextBox ID="txtCodigo" runat="server" Required="true" MaxLength="10" Caption="Código" BubbleTip=" adf da fas dfads a" TypeTextField="CNPJ"
                    ValidationGroup="vgSalvar" />
                <WC:WTextBox ID="txtTitulo" runat="server" Required="true" MaxLength="50" Caption="Descrição" BubbleTip=" adf da fas dfads a" TypeTextField="CPF"
                    ValidationGroup="vgSalvar" />
                <WC:WCheckBox ID="chkStatus" runat="server" Caption="Ativo" BubbleTip=" adf da fas dfads a" />
                <div class="divBotoes">
                    <WC:WButton runat="server" ID="btnSalvar" Text="Salvar" IconPrimary="ui-icon-disk">
                        <Listeners>
                            <WC:ButtonListener Type="click" Fn="teste" />
                        </Listeners>
                    </WC:WButton>
                    <WC:WButton runat="server" ID="btnCancelar" Text="Cancelar" IconPrimary="ui-icon-cancel"></WC:WButton>
                </div>
                <%--<div class="divBotoes">
                    <asp:LinkButton runat="server" ID="btnSalvar" CssClass="buttonSalvar" ValidationGroup="vgSalvar"><span>Salvar</span></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnCancelar" CssClass="buttonCancelar"><span>Cancelar</span></asp:LinkButton>
                </div>--%>
                <asp:ValidationSummary ID="vsCentroCusto" runat="server" ValidationGroup="vgSalvar"
                        EnableClientScript="true" DisplayMode="BulletList" ShowMessageBox="false" ShowSummary="false" />
            </div>
        </asp:Panel>
        
        <WC:WTab runat="server" ID="tabTeste" ActiveTab="1" >
            <Items>
                <WC:TabItem Href="Default.aspx" Titulo="abc" />
                <WC:TabItem Href="Default.aspx" Titulo="abc1" />
                <WC:TabItem Href="Default.aspx" Titulo="abc2" />
                <WC:TabItem Titulo="abc3" AssociateBodyAbasId="aba3" />
            </Items>
            <BodyAbas>
                <WC:BodyAbas Id="aba3" Html=" asdf das fdas fdsa adsf da o dsaop dasfop dasf dafs" />
            </BodyAbas>
            <%--<Listeners>
                <WC:TabListener Type="activate" Fn="teste" /> 
            </Listeners>--%>
        </WC:WTab>
        <WC:WAccordion runat="server" ID="pnlAccordion">
            <Items>
                <WC:PanelAccordion Titulo="Section 1" Html="<p>
                    Mauris mauris ante, blandit et, ultrices a, suscipit eget, quam. Integer
                    ut neque. Vivamus nisi metus, molestie vel, gravida in, condimentum sit
                    amet, nunc. Nam a nibh. Donec suscipit eros. Nam mi. Proin viverra leo ut
                    odio. Curabitur malesuada. Vestibulum a velit eu ante scelerisque vulputate.
                    </p>" />
                <WC:PanelAccordion Titulo="Section 2" Html="<p>
                    Sed non urna. Donec et ante. Phasellus eu ligula. Vestibulum sit amet
                    purus. Vivamus hendrerit, dolor at aliquet laoreet, mauris turpis porttitor
                    velit, faucibus interdum tellus libero ac justo. Vivamus non quam. In
                    suscipit faucibus urna.
                    </p>" />
            </Items>
        </WC:WAccordion>
        <asp:LinkButton runat="server" OnClick="teste_click" Text="abc"></asp:LinkButton>
   
    </form>
    <script type="text/javascript">
        $(function() {
            
            //$('#btnNovo').bind('click', function(){ alert('teste'); return false; });
        });
//        $('#grdTeste').flexigrid({height:'auto',striped:false, singleSelect:true});
        $('#grid2').flexigrid();
    </script>
</body>
</html>
