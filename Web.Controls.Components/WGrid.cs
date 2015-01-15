using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Web.Controls.Components
{
    public class WGrid : GridView
    {
        #region     .....:::::     ATTRIBUTES     :::::.....

        protected Label _caption;
        protected Panel _pnlPaginacao;
        protected Panel _pnlControles;
        protected LinkButton _btnPrimeiro;
        protected Label _btnPrimeiroText;
        protected LinkButton _btnAnterior;
        protected Label _btnAnteriorText;
        protected Label _paginaArea;
        protected Label _paginaCaption;
        protected TextBox _paginaValue;
        protected Label _paginaDeCaption;
        protected Label _paginaDeValue;
        protected LinkButton _btnProximo;
        protected Label _btnProximoText;
        protected LinkButton _btnUltimo;
        protected Label _btnUltimoText;
        protected LinkButton _btnAtualizar;
        protected Label _btnAtualizarText;
        protected Panel _pnlInfo;
        protected Label _lblExibeRegistros;
        
        #endregion

        #region     .....:::::     PROPRIEDADES     :::::.....

        public String Title
        {
            get
            {
                if (this.ViewState["Title"] == null)
                {
                    this.ViewState["Title"] = String.Empty;
                }
                return (String)this.ViewState["Title"];
            }
            set { this.ViewState["Title"] = value; }
        }

        public Boolean ShowCaption
        {
            get
            {
                if (this.ViewState["ShowCaption"] == null)
                {
                    this.ViewState["ShowCaption"] = false;
                }
                return (Boolean)this.ViewState["ShowCaption"];
            }
            set { this.ViewState["ShowCaption"] = value; }
        }

        public String CssClassForCaption
        {
            get
            {
                if (this.ViewState["CssClassForCaption"] == null)
                {
                    this.ViewState["CssClassForCaption"] = String.Empty;
                }
                return (String)this.ViewState["CssClassForCaption"];
            }
            set { this.ViewState["CssClassForCaption"] = value; }
        }

        public override Int32 PageIndex
        {
            get
            {
                Int32 aux = 0;
                if (this.ViewState["PageIndex"] == null || Int32.TryParse(this.ViewState["PageIndex"].ToString(), out aux))
                {
                    if (aux.Equals(0))
                    {
                        this.ViewState["PageIndex"] = 1;
                    }
                }
                else
                {
                    this.ViewState["PageIndex"] = 1;
                }

                return Convert.ToInt32(this.ViewState["PageIndex"]);
            }
            set
            {
                this.ViewState["PageIndex"] = value;
            }
        }

        public override Int32 PageSize
        {
            get
            {
                Int32 aux = 0;
                if (this.ViewState["PageSize"] == null || !Int32.TryParse(this.ViewState["PageSize"].ToString(), out aux))
                {
                    this.ViewState["PageSize"] = 10;
                }
                return Convert.ToInt32(this.ViewState["PageSize"]);
            }
        }

        public Int32 PageCount
        {
            get
            {
                Int32 aux = 0;
                if (this.ViewState["PageCount"] == null || !Int32.TryParse(this.ViewState["PageCount"].ToString(), out aux))
                {
                    this.ViewState["PageCount"] = 1;
                }
                return Convert.ToInt32(this.ViewState["PageCount"]);
            }
            set
            {
                this.ViewState["PageCount"] = value;
            }
        }

        #endregion

        #region .....:::::     CONSTRUTORES     :::::.....

        public WGrid()
        {
            this.CssClassForCaption = "FieldCaption";
		}
		
        #endregion

        #region     .....:::::     DECLARAÇÃO DE DELEGATES E EVENTOS     :::::.....
        
        public delegate void PageIndexChangeHandler(int PageIndex);
        public event PageIndexChangeHandler PageIndexChange;
        
        #endregion

        #region     .....:::::     EVENTOS     :::::.....

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this._caption = new Label();
            this._caption.ID = String.Concat(this.ID, "_Caption");
            this._caption.Text = this.Caption;
            this._caption.Visible = this.ShowCaption;
            this._caption.CssClass = this.CssClassForCaption;
            base.Caption = String.Empty;
            base.Attributes["control"] = "grid";
            
            if (this.AllowPaging)
            {
                _pnlPaginacao = new Panel();
                _pnlPaginacao.ID = String.Format("{0}_pnlPaginacao", this.ID);
                _pnlPaginacao.CssClass = "PanelPaginacao";

                _pnlControles = new Panel();
                _pnlControles.ID = String.Format("{0}_pnlControles", this.ID);
                _pnlControles.CssClass = "PanelControles";

                _btnPrimeiro = new LinkButton();
                _btnPrimeiro.Attributes.Add("runat", "server");
                _btnPrimeiro.ID = String.Format("{0}_btnPrimeiro", this.ID);
                _btnPrimeiro.CssClass = "BotaoPrimeiroInativo";

                _btnPrimeiroText = new Label();
                _btnPrimeiroText.ID = String.Format("{0}_btnPrimeiroText", this.ID);
                _btnPrimeiroText.Text = "Primeiro";

                _btnPrimeiro.Controls.Add(_btnPrimeiroText);
                _pnlControles.Controls.Add(_btnPrimeiro);

                _btnAnterior = new LinkButton();
                _btnAnterior.Attributes.Add("runat", "server");
                _btnAnterior.ID = String.Format("{0}_btnAnterior", this.ID);
                _btnAnterior.CssClass = "BotaoAnteriorInativo";

                _btnAnteriorText = new Label();
                _btnAnteriorText.ID = String.Format("{0}_btnAnteriorText", this.ID);
                _btnAnteriorText.Text = "Primeiro";

                _btnAnterior.Controls.Add(_btnAnteriorText);
                _pnlControles.Controls.Add(_btnAnterior);


                _paginaArea = new Label();
                _paginaArea.ID = String.Format("{0}_PaginaArea", this.ID);
                //_paginaArea.AssociatedControlID = String.Format("{0}_PaginaValue", this.ID);
                _paginaArea.CssClass = "PaginacaoFieldArea";

                _paginaCaption = new Label();
                _paginaCaption.ID = String.Format("{0}_PaginaCaption", this.ID);
                _paginaCaption.Text = "Pagina";
                _paginaCaption.CssClass = "PaginacaoFieldCaption";

                _paginaArea.Controls.Add(_paginaCaption);

                _paginaValue = new TextBox();
                _paginaValue.ID = String.Format("{0}_PaginaValue", this.ID);
                _paginaValue.CssClass = "PaginacaoFieldValue";
                _paginaValue.AutoPostBack = true;
                _paginaValue.Text = this.PageIndex.ToString();
                _paginaValue.Attributes.Add("onkeyup", "maskNumber(this)");

                _paginaArea.Controls.Add(_paginaValue);

                _paginaDeCaption = new Label();
                _paginaDeCaption.ID = String.Format("{0}_PaginaDeCaption", this.ID);
                _paginaDeCaption.Text = " de ";
                _paginaDeCaption.CssClass = "PaginacaoFieldCaption";

                _paginaArea.Controls.Add(_paginaDeCaption);

                _paginaDeValue = new Label();
                _paginaDeValue.ID = String.Format("{0}_PaginaDeValue", this.ID);
                _paginaDeValue.CssClass = "PaginacaoFieldCaption";

                _paginaArea.Controls.Add(_paginaDeValue);

                _pnlControles.Controls.Add(_paginaArea);

                _btnProximo = new LinkButton();
                _btnProximo.Attributes.Add("runat", "server");
                _btnProximo.ID = String.Format("{0}_btnProximo", this.ID);
                _btnProximo.CssClass = "BotaoProximoAtivo";

                _btnProximoText = new Label();
                _btnProximoText.ID = String.Format("{0}_btnProximoText", this.ID);
                _btnProximoText.Text = "Proximo";

                _btnProximo.Controls.Add(_btnProximoText);
                _pnlControles.Controls.Add(_btnProximo);

                _btnUltimo = new LinkButton();
                _btnUltimo.Attributes.Add("runat", "server");
                _btnUltimo.ID = String.Format("{0}_btnUltimo", this.ID);
                _btnUltimo.CssClass = "BotaoUltimoAtivo";

                _btnUltimoText = new Label();
                _btnUltimoText.ID = String.Format("{0}_btnUltimoText", this.ID);
                _btnUltimoText.Text = "Ultimo";

                _btnUltimo.Controls.Add(_btnAnteriorText);
                _pnlControles.Controls.Add(_btnUltimo);

                _btnAtualizar = new LinkButton();
                _btnAtualizar.Attributes.Add("runat", "server");
                _btnAtualizar.ID = String.Format("{0}_btnAtualizar", this.ID);
                _btnAtualizar.CssClass = "BotaoAtualizar";

                _btnAtualizarText = new Label();
                _btnAtualizarText.ID = String.Format("{0}_btnAtualizarText", this.ID);
                _btnAtualizarText.Text = "Atualizar";

                this._btnAtualizar.Click += btnAtualizar_OnTextChanged;
                this._paginaValue.TextChanged += btnAtualizar_OnTextChanged;
                this._btnAnterior.Click += btnAnterior_Click;
                this._btnPrimeiro.Click += btnPrimeiro_Click;
                this._btnProximo.Click += btnProximo_Click;
                this._btnUltimo.Click += btnUltimo_Click;
                
                _btnAtualizar.Controls.Add(_btnAtualizarText);
                _pnlControles.Controls.Add(_btnAtualizar);


                _pnlInfo = new Panel();
                _pnlInfo.ID = String.Format("{0}_pnlInfo", this.ID);
                _pnlInfo.CssClass = "PanelInfo";

                _lblExibeRegistros = new Label();
                _lblExibeRegistros.ID = String.Format("{0}_lblExibeRegistros", this.ID);

                _pnlInfo.Controls.Add(_lblExibeRegistros);

                if (base.Width.Value > 0)
                {
                    this._pnlPaginacao.Width = base.Width;
                }
                else
                {
                    base.Width = new Unit("100%");
                    this._pnlPaginacao.Width = new Unit("100%");
                }

                _pnlPaginacao.Controls.Add(_pnlControles);
                _pnlPaginacao.Controls.Add(_pnlInfo);

                base.Controls.Add(_pnlPaginacao);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            #region Scripts

            if (!Page.ClientScript.IsClientScriptIncludeRegistered("GeralJS"))
            {
                Page.ClientScript.RegisterClientScriptInclude("GeralJS", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral.js"));
                Page.ClientScript.RegisterClientScriptInclude("JQueryJS", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.jquery-1.9.1.js"));
                Page.ClientScript.RegisterClientScriptInclude("JQueryUIJS", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.jquery-ui.js"));
                Page.ClientScript.RegisterClientScriptInclude("JQueryBubbleTipJS", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.jQuery.bubbletip-1.0.6.js"));
                Page.ClientScript.RegisterClientScriptInclude("JQueryPriceFormatJS", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.jquery.price-format.js"));
            }

            #endregion

            #region Estilos

            string[] estilos = { "Web.Controls.Components.css.jquery-ui.css", "Web.Controls.Components.css.bubbletip.css", "Web.Controls.Components.css.flexigrid.css", "Web.Controls.Components.css.geral.css" };
            string[] estilosIE = { "Web.Controls.Components.css.geral-ie.css", "Web.Controls.Components.css.bubbletip-IE.css" };
            foreach (string strRes in estilos)
            {
                string csslink = "<link href='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), strRes) + "' rel='stylesheet' type='text/css' />";
                LiteralControl include = new LiteralControl(csslink);
                Page.Header.Controls.Add(include);
            }

            foreach (string strRes in estilosIE)
            {
                string csslink = "<link href='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), strRes) + "' rel='stylesheet' type='text/css' />";
                csslink = String.Format("{0}{1}{2}", "<!--[if IE]> ", csslink, "<![endif]-->");
                LiteralControl include = new LiteralControl(csslink);
                Page.Header.Controls.Add(include);
            }

            #endregion

            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.EnsureChildControls();
            writer.RenderBeginTag(HtmlTextWriterTag.Label);

            this._caption.RenderControl(writer);

            if (this.Rows.Count > 0)
            {
                HeaderRow.TableSection = TableRowSection.TableHeader;
                base.Render(writer);
                if (this.AllowPaging && this.FindControl(this._pnlPaginacao.ID) == null)
                    this._pnlPaginacao.RenderControl(writer);
            }
            else
            {
                this._pnlPaginacao.Visible = false;
            }
            writer.RenderEndTag();

            #region Scripts

            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("$(function() {");
            strScript.AppendLine(String.Concat("\t$('#", this.ClientID, "').flexigrid({"));
            strScript.AppendLine("\t\theight: 'auto'");
            strScript.AppendLine("\t\t,striped: false");
            strScript.AppendLine("\t\t,singleSelect:true");
            strScript.AppendLine(String.Format("\t\t,title:'{0}'", this.Title));
            strScript.AppendLine("\t});");
            strScript.AppendLine("});");
            
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID, strScript.ToString(), true);

            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), String.Concat(this.ID, "_js"), String.Concat("<script src=\"", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral-after.js"), "\" type=\"text/javascript\"></script>"));
            #endregion
        }

        protected void btnPrimeiro_Click(object sender, EventArgs e)
        {
            this.PageIndex = 1;
            this.PageIndexChange(this.PageIndex);
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            this.PageIndex--;
            this.PageIndexChange(this.PageIndex);
        }

        protected void btnProximo_Click(object sender, EventArgs e)
        {
            this.PageIndex++;
            this.PageIndexChange(this.PageIndex);
        }

        protected void btnUltimo_Click(object sender, EventArgs e)
        {
            this.PageIndex = this.PageCount;
            this.PageIndexChange(this.PageIndex);
        }

        protected void btnAtualizar_OnTextChanged(object sender, EventArgs e)
        {
            this.PageIndex = Convert.ToInt32(this._paginaValue.Text);
            this.PageIndexChange(this.PageIndex);
        }

        #endregion

        #region     .....:::::     MÉTODOS     :::::.....

        /// <summary>
        /// Método que atualiza controle de paginação
        /// </summary>
        /// <param name="pages">quantidade de páginas</param>
        /// <param name="index">index da páginação</param>
        /// <param name="count">quantidade de registros retornados</param>
        public void LoadPagination(Int32 pages, Int32 index, Int32 count)
        {
            if (!this.AllowPaging)
                return;

            if (index > pages)
            {
                index = pages;
            }

            if (index < 0)
            {
                index = 1;
            }

            Int32 registrosAte = index * this.PageSize;
            Int32 registrosDe = ((registrosAte - this.PageSize) + 1) < 0 ? 0 : ((registrosAte - this.PageSize) + 1);
            registrosAte = (registrosAte > count) ? count : registrosAte;
            this.PageCount = pages;

            this._btnPrimeiro.Enabled = (index > 1);
            this._btnAnterior.Enabled = (index > 1);
            this._btnProximo.Enabled = (index < pages);
            this._btnUltimo.Enabled = (index < pages);
            this._paginaArea.Enabled = !count.Equals(0);
            this._btnAtualizar.Enabled = !count.Equals(0);

            this._btnPrimeiro.CssClass = (index > 1) ? "BotaoPrimeiroAtivo" : "BotaoPrimeiroInativo";
            this._btnAnterior.CssClass = (index > 1) ? "BotaoAnteriorAtivo" : "BotaoAnteriorInativo";
            this._btnProximo.CssClass = (index < pages) ? "BotaoProximoAtivo" : "BotaoProximoInativo";
            this._btnUltimo.CssClass = (index < pages) ? "BotaoUltimoAtivo" : "BotaoUltimoInativo";

            this._paginaValue.Text = (index > pages) ? pages.ToString() : index.ToString();
            this._paginaDeValue.Text = pages.ToString();
            this._lblExibeRegistros.Text = string.Format("Exibindo Registros {0} - {1} de {2}", registrosDe.ToString(), registrosAte.ToString(), count.ToString());

            //ExibeRegistros(index, count);
        }

        #endregion
    }
}
