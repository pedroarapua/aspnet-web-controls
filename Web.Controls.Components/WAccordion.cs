using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.Controls.Components
{
    [PersistChildren(false), ParseChildren(true)]
    public class WAccordion : CompositeControl, INamingContainer
    {
        #region Attributes

        private Panel _pnlAccordion;
        private HtmlGenericControl _h3;
        private HtmlGenericControl _div;
        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<PanelAccordion> Items
        {
            get
            {
                if (this.ViewState["Items"] == null)
                    this.ViewState["Items"] = new List<PanelAccordion>();
                return (List<PanelAccordion>)this.ViewState["Items"];
            }
            set { this.ViewState["Items"] = value; }

        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<AccordionListener> Listeners
        {
            get
            {
                if (this.ViewState["Listeners"] == null)
                    this.ViewState["Listeners"] = new List<AccordionListener>();
                return (List<AccordionListener>)this.ViewState["Listeners"];
            }
            set { this.ViewState["Listeners"] = value; }

        }

        public Int32 ActivePanel
        {
            get
            {
                if (this.ViewState["ActivePanel"] == null)
                    this.ViewState["ActivePanel"] = 0;
                return Convert.ToInt32(this.ViewState["ActivePanel"]);
            }
            set
            {
                this.ViewState["ActivePanel"] = value;
            }
        }

        public Boolean Disabled
        {
            get
            {
                if (this.ViewState["Disabled"] == null)
                    this.ViewState["Disabled"] = false;
                return Convert.ToBoolean(this.ViewState["Disabled"]);
            }
            set
            {
                this.ViewState["Disabled"] = value;
            }
        }

        public String IconHeader
        {
            get
            {
                if (this.ViewState["IconHeader"] == null)
                    this.ViewState["IconHeader"] = "ui-icon-triangle-1-e";
                return this.ViewState["IconHeader"].ToString();
            }
            set
            {
                this.ViewState["IconHeader"] = value;
            }
        }

        public String IconActiveHeader
        {
            get
            {
                if (this.ViewState["IconActiveHeader"] == null)
                    this.ViewState["IconActiveHeader"] = "ui-icon-triangle-1-s";
                return this.ViewState["IconActiveHeader"].ToString();
            }
            set
            {
                this.ViewState["IconActiveHeader"] = value;
            }
        }

        #endregion

        #region     .....:::::     EVENTOS     :::::.....

        protected override void CreateChildControls()
        {
            this._pnlAccordion = new Panel();
            this._pnlAccordion.ID = this.ID;
            this._pnlAccordion.Attributes["control"] = "accordion";

            foreach (PanelAccordion pnl in this.Items)
            {
                this._h3 = new HtmlGenericControl("h3");
                this._h3.ID = String.Concat("h3", this.Items.IndexOf(pnl));
                this._h3.InnerHtml = pnl.Titulo;
                this._pnlAccordion.Controls.Add(this._h3);

                this._div = new HtmlGenericControl("div");
                this._div.ID = String.Concat("div", this.Items.IndexOf(pnl));
                this._div.InnerHtml = pnl.Html;
                this._pnlAccordion.Controls.Add(this._div);
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
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this._pnlAccordion.RenderControl(writer);

            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("$(function() {");
            strScript.AppendLine(String.Concat("$('#", this._pnlAccordion.ClientID, "').accordion({"));
            strScript.AppendLine(String.Format("active: {0}", this.ActivePanel));
            //strScript.AppendLine(",disabled: true");
            strScript.AppendLine(String.Format(",disabled: {0}", this.Disabled.ToString().ToLower()));
            strScript.AppendLine(String.Concat(",icons: { header: '", this.IconHeader, "', activeHeader: '", this.IconActiveHeader, "'}"));
            foreach (AccordionListener e in this.Listeners)
                strScript.AppendLine(String.Format(", {0}: {1} ", e.Type.ToString(), e.Fn));
            strScript.AppendLine("});");
            strScript.AppendLine("});");
            strScript.AppendLine("");

            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this._pnlAccordion.ClientID, strScript.ToString(), true);

            if (!Page.ClientScript.IsClientScriptBlockRegistered("GeralAfterJS"))
            {
                Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "GeralAfterJS", String.Concat("<script src=\"", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral-after.js"), "\" type=\"text/javascript\"></script>"));
            }
        }

        #endregion
    }

    [Serializable]
    public class PanelAccordion
    {
        private String _html;
        private String _titulo;
        
        public String Html
        {
            get { return this._html; }
            set { this._html = value; }
        }

        public String Titulo
        {
            get { return this._titulo; }
            set { this._titulo = value; }
        }

    }

    public class AccordionListener : EventListener
    {
        private ETypeListener _type;
        public ETypeListener Type
        {
            get
            {
                return this._type;
            }
            set { this._type = value; }
        }

        public enum ETypeListener
        {
            activate = 0,
            beforeActivate = 1,
            load = 2
        }
    }
}
