using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.Controls.Components
{
    [PersistChildren(false), ParseChildren(true)]
    public class WTab : CompositeControl, INamingContainer
    {
        #region Attributes

        private Panel _pnlTabs;
        private HtmlGenericControl _ul;
        private HtmlGenericControl _li;
        private HtmlGenericControl _link;
        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<TabItem> Items
        {
            get
            {
                if (this.ViewState["Items"] == null)
                    this.ViewState["Items"] = new List<TabItem>();
                return (List<TabItem>)this.ViewState["Items"];
            }
            set { this.ViewState["Items"] = value; }

        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<BodyAbas> BodyAbas
        {
            get
            {
                if (this.ViewState["BodyAbas"] == null)
                    this.ViewState["BodyAbas"] = new List<BodyAbas>();
                return (List<BodyAbas>)this.ViewState["BodyAbas"];
            }
            set { this.ViewState["BodyAbas"] = value; }

        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<TabListener> Listeners
        {
            get
            {
                if (this.ViewState["Listeners"] == null)
                    this.ViewState["Listeners"] = new List<TabListener>();
                return (List<TabListener>)this.ViewState["Listeners"];
            }
            set { this.ViewState["Listeners"] = value; }

        }

        public Boolean Disabled
        {
            get 
            { 
                if(this.ViewState["Disabled"] == null)
                    this.ViewState["Disabled"] = false;
                return Convert.ToBoolean(this.ViewState["Disabled"]);
            }
            set {
                this.ViewState["Disabled"] = value;
            }
        }

        public Int32 ActiveTab
        {
            get
            {
                if (this.ViewState["ActiveTab"] == null)
                    this.ViewState["ActiveTab"] = 0;
                return Convert.ToInt32(this.ViewState["ActiveTab"]);
            }
            set
            {
                this.ViewState["ActiveTab"] = value;
            }
        }

        #endregion

        #region     .....:::::     EVENTOS     :::::.....

        protected override void CreateChildControls()
        {
            this._pnlTabs = new Panel();
            this._pnlTabs.ID = this.ID;
            this._pnlTabs.Attributes["control"] = "tab";
            this.Controls.Add(this._pnlTabs);

            this._ul = new HtmlGenericControl("ul");
            this._ul.ID = "tabs";

            this._pnlTabs.Controls.Add(this._ul);

            foreach (BodyAbas bodyAbas in this.BodyAbas)
            {
                HtmlGenericControl control = new HtmlGenericControl("div");
                control.ID = bodyAbas.Id;
                control.InnerHtml = bodyAbas.Html;
                this._pnlTabs.Controls.Add(control);
            }
            
            int index = 0;
            foreach (TabItem item in Items)
            {
                this._li = new HtmlGenericControl("li");
                this._li.ID = String.Concat("tab",index);
                this._ul.Controls.Add(this._li);

                this._link = new HtmlGenericControl("a");
                if (!String.IsNullOrEmpty(item.AssociateBodyAbasId))
                {
                    BodyAbas bodyAbas = this.BodyAbas.Find(delegate(BodyAbas b) { return b.Id == item.AssociateBodyAbasId; });
                    if (bodyAbas != null)
                    {
                        HtmlGenericControl control = this._pnlTabs.FindControl(bodyAbas.Id) as HtmlGenericControl;
                        if(control != null)
                            this._link.Attributes["href"] = String.Concat("#", control.ClientID);
                    }
                }
                else if(!String.IsNullOrEmpty(item.Href))
                {
                    this._link.Attributes["href"] = item.Href;
                }
                this._link.InnerHtml = item.Titulo;
                this._link.ID = String.Concat("link", index);
                this._li.Controls.Add(this._link);

                index++;
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
            this._pnlTabs.RenderControl(writer);
            
            if (this.Disabled)
            {
                foreach (TabItem item in this.Items)
                {
                    item.Disabled = true;
                }
            }

            List<String> lstTabDisabled = new List<String>();
            this.Items.ForEach(delegate(TabItem item) { if (item.Disabled) lstTabDisabled.Add(this.Items.IndexOf(item).ToString()); });

            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("$(function() {");
            strScript.AppendLine(String.Concat("$('#", this._pnlTabs.ClientID, "').tabs({"));
            strScript.AppendLine(String.Format("active: {0}", this.ActiveTab));
            strScript.AppendLine(String.Format(",disabled: [{0}]", String.Join(",", lstTabDisabled.ToArray())));
            foreach (TabListener e in this.Listeners)
                strScript.AppendLine(String.Format(", {0}: {1} ", e.Type.ToString(), e.Fn));
            strScript.AppendLine("});");
            strScript.AppendLine("});");
            strScript.AppendLine("");
            
            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this._pnlTabs.ClientID, strScript.ToString(), true);

            if (!Page.ClientScript.IsClientScriptBlockRegistered("GeralAfterJS"))
            {
                Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "GeralAfterJS", String.Concat("<script src=\"", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral-after.js"), "\" type=\"text/javascript\"></script>"));
            }
        }

        #endregion
    }

    [Serializable]
    public class BodyAbas
    {
        private String _html;
        private String _id;

        public String Html
        {
            get { return this._html; }
            set { this._html = value; }
        }

        public String Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
    }

    public class TabListener : EventListener
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
            beforeLoad = 2,
            create = 3,
            load = 4
        }
    }
}
