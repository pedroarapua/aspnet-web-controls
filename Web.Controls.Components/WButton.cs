using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Web.Controls.Components
{
    [PersistChildren(false), ParseChildren(true)]
    public class WButton : CompositeControl, IPostBackEventHandler, INamingContainer
    {
        #region Attributes

        private LinkButton _a;
        
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<ButtonListener> Listeners
        {
            get
            {
                if (this.ViewState["Listeners"] == null)
                    this.ViewState["Listeners"] = new List<ButtonListener>();
                return (List<ButtonListener>)this.ViewState["Listeners"];
            }
            set { this.ViewState["Listeners"] = value; }

        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<ButtonAjaxEvent> AjaxEvents
        {
            get
            {
                if (this.ViewState["AjaxEvents"] == null)
                    this.ViewState["AjaxEvents"] = new List<ButtonAjaxEvent>();
                return (List<ButtonAjaxEvent>)this.ViewState["AjaxEvents"];
            }
            set { this.ViewState["AjaxEvents"] = value; }

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

        public String Text
        {
            get
            {
                if (this.ViewState["Text"] == null)
                    this.ViewState["Text"] = "";
                return this.ViewState["Text"].ToString();
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        public String IconPrimary
        {
            get
            {
                if (this.ViewState["IconPrimary"] == null)
                    this.ViewState["IconPrimary"] = "";
                return this.ViewState["IconPrimary"].ToString();
            }
            set
            {
                this.ViewState["IconPrimary"] = value;
            }
        }

        public String CommandArgument
        {
            get
            {
                if (this.ViewState["CommandArgument"] == null)
                    this.ViewState["CommandArgument"] = "";
                return this.ViewState["CommandArgument"].ToString();
            }
            set
            {
                this.ViewState["CommandArgument"] = value;
            }
        }

        public String IconSecondary
        {
            get
            {
                if (this.ViewState["IconSecondary"] == null)
                    this.ViewState["IconSecondary"] = "";
                return this.ViewState["IconSecondary"].ToString();
            }
            set
            {
                this.ViewState["IconSecondary"] = value;
            }
        }

        #endregion

        #region     .....:::::     DECLARAÇÃO DE DELEGATES E EVENTOS     :::::.....

        public delegate void OnClickHandler(object sender, EventArgs e);
        public event OnClickHandler Click;

        #endregion

        #region     .....:::::     EVENTOS     :::::.....

        protected override void CreateChildControls()
        {
            this._a = new LinkButton();
            this._a.ID = this.ID;
            this._a.Text = this.Text;
            this._a.CausesValidation = false;
            this._a.Attributes["control"] = "button";
            
            if (Click != null)
            {
                this._a.Click += new EventHandler(Link_Click);
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
            if(Click == null)
                this._a.Attributes["href"] = "#";
            else
                this._a.Attributes["href"] = String.Format("javascript:{0};", this.Page.ClientScript.GetPostBackEventReference(this, "", false));
            this._a.RenderControl(writer);

            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("\t$(function() {");
            strScript.AppendLine(String.Concat("\t\t$('#", this._a.ClientID, "').button({"));
            strScript.AppendLine(String.Format("\t\t\tdisabled: {0}", this.Disabled.ToString().ToLower()));
            strScript.AppendLine(String.Concat("\t\t\t,icons: { primary: '", this.IconPrimary, "', secondary: '", this.IconSecondary, "'}"));
            strScript.AppendLine("\t});");

            foreach (ButtonListener e in this.Listeners)
                strScript.AppendLine(String.Format(String.Concat("$('#", this._a.ClientID, "').{0}({1});"), e.Type.ToString(), e.Fn));
                
            strScript.AppendLine("});");
            strScript.AppendLine("");

            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this._a.ClientID, strScript.ToString(), true);

            if (!Page.ClientScript.IsClientScriptBlockRegistered("GeralAfterJS"))
            {
                Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "GeralAfterJS", String.Concat("<script src=\"", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral-after.js"), "\" type=\"text/javascript\"></script>"));
            }
        }

        protected void Link_Click(object sender, EventArgs e)
        {
            this.Click(sender, e);
        }

        #endregion

        #region IPostBackEventHandler Members

        public virtual void RaisePostBackEvent(string eventArgument)
        {
            Link_Click(this._a, new EventArgs());
        }

        #endregion
    }

    [Serializable]
    public class ButtonListener : EventListener
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
            click = 0
        }
    }

    [Serializable]
    public class ButtonAjaxEvent : EventAjax
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
            click = 0
        }
    }
}
