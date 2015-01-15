using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Web.Controls.Components;
using System.Collections.Generic;

namespace Web.Controls.Test
{
    public partial class Pagina : BasePage
    {
        #region     .....:::::     EVENTOS     :::::.....

        protected void Page_Load(object sender, EventArgs e)
        {
            //ConfigurationManager.AppSettings[""]
            if (!IsPostBack)
                Pesquisar(1, 10);
        }


        /// <summary>
        /// evento disparado ao clicar no botão Limpar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLimpar_Click(object sender, EventArgs e)
        {
            LimparCamposBusca();
        }

        /// <summary>
        /// evento disparado ao clicar no botão Pesquisar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar(1, 10);
        }

        /// <summary>
        /// evento disparado ao clicar no botão editar do grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            LimparCamposForm();
            PreencherCampos((sender as LinkButton).CommandArgument);
        }

        /// <summary>
        /// evento disparado ao clicar no botão novo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            LimparCamposForm();
            this.mtvConteudo.ActiveViewIndex = 1;
        }

        /// <summary>
        /// evento disparado ao clicar no botão salvar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        /// <summary>
        /// evento que cancela uma edição ou cadastro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Pesquisar(1, 10);
        }

        /// <summary>
        /// evento que atualiza o grid com sua paginação
        /// </summary>
        /// <param name="PageIndex"></param>
        protected void grdTeste_OnPageIndexChange(int PageIndex)
        {
            Pesquisar(PageIndex, 10);
        }

        #endregion

        #region     .....:::::     MÉTODOS     :::::.....

		/// <summary>
		/// metodo chamado para limpar os campos do form
		/// </summary>
        private void LimparCamposBusca()
        { }

        /// <summary>
        /// metodo chamado para pesquisar informações
        /// </summary>
        private void Pesquisar(Int32 pageIndex, Int32 pageSize)
        {
            int totalRegistros = 100;
            List<String> lst = new List<String>();
            for (int i = 0; i < pageIndex; i++)
                lst.Add(i.ToString());
            grdTeste.DataSource = lst;
            grdTeste.DataBind();
            grdTeste.LoadPagination(totalRegistros / base.PageSize, pageIndex, lst.Count);
            this.mtvConteudo.ActiveViewIndex = 0;
        }

        /// <summary>
        /// Carrega as informações nos campos quando esta sendo alterado
        /// </summary>
        private void PreencherCampos(String id)
        {
            this.mtvConteudo.ActiveViewIndex = 1;
        }

        /// <summary>
		/// metodo chamado para salvar um centro d ecusto
		/// </summary>
		private void Salvar()
		{
			this.mtvConteudo.ActiveViewIndex = 0;
		}

		/// <summary>
		/// limpa os campos do formulario
		/// </summary>
        private void LimparCamposForm()
        { }

        #endregion
    }
}
