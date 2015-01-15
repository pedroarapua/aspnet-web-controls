using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Web.Controls.Components
{
	public class WNumberBox : TextBox, IWControl
	{

		#region Attributes
		protected Label _caption;
		protected RequiredFieldValidator _RFV;
		protected HtmlGenericControl _qtip;
		#endregion Attributes


		#region Properties
		
        public String Caption
		{
			get
			{
				if (this.ViewState["Caption"] == null)
				{
					this.ViewState["Caption"] = String.Empty;
				}
				return (String)this.ViewState["Caption"];
			}
			set { this.ViewState["Caption"] = value; }
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

		public String ErrorMessage
		{
			get
			{
				if (this.ViewState["ErrorMessage"] == null)
				{
					this.ViewState["ErrorMessage"] = String.Empty;
				}
				return String.Format((String)this.ViewState["ErrorMessage"], this.Caption);
			}
			set { this.ViewState["ErrorMessage"] = value; }
		}

		public Boolean Required
		{
			get
			{
				if (this.ViewState["Required"] == null)
				{
					this.ViewState["Required"] = false;
				}
				return (Boolean)this.ViewState["Required"];
			}
			set { this.ViewState["Required"] = value; }
		}

		public String CssClassForArea
		{
			get
			{
				if (this.ViewState["CssClassForArea"] == null)
				{
					this.ViewState["CssClassForArea"] = String.Empty;
				}
				return (String)this.ViewState["CssClassForArea"];
			}
			set { this.ViewState["CssClassForArea"] = value; }
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

		public String BubbleTip
        {
            get
            {
                if (this.ViewState["BubbleTip"] == null)
                {
                    this.ViewState["BubbleTip"] = String.Empty;
                }
                return (String)this.ViewState["BubbleTip"];
            }
            set { this.ViewState["BubbleTip"] = value; }
        }

        public String Prefix
        {
            get
            {
                if (this.ViewState["Prefix"] == null)
                {
                    this.ViewState["Prefix"] = String.Empty;
                }
                return (String)this.ViewState["Prefix"];
            }
            set { this.ViewState["Prefix"] = value; }
        }

        public String Suffix
        {
            get
            {
                if (this.ViewState["Suffix"] == null)
                {
                    this.ViewState["Suffix"] = String.Empty;
                }
                return (String)this.ViewState["Suffix"];
            }
            set { this.ViewState["Suffix"] = value; }
        }

        public String CentsSeparator
        {
            get
            {
                if (this.ViewState["CentsSeparator"] == null)
                {
                    this.ViewState["CentsSeparator"] = ",";
                }
                return (String)this.ViewState["CentsSeparator"];
            }
            set { this.ViewState["CentsSeparator"] = value; }
        }

        public String ThousandsSeparator
        {
            get
            {
                if (this.ViewState["ThousandsSeparator"] == null)
                {
                    this.ViewState["ThousandsSeparator"] = String.Empty;
                }
                return (String)this.ViewState["ThousandsSeparator"];
            }
            set { this.ViewState["ThousandsSeparator"] = value; }
        }

        public Int32 CentsLimit
        {
            get
            {
                if (this.ViewState["CentsLimit"] == null)
                {
                    this.ViewState["CentsLimit"] = 2;
                }
                return Convert.ToInt32(this.ViewState["CentsLimit"]);
            }
            set { this.ViewState["CentsLimit"] = value; }
        }

        public Boolean ClearPrefix
        {
            get
            {
                if (this.ViewState["ClearPrefix"] == null)
                {
                    this.ViewState["ClearPrefix"] = true;
                }
                return Convert.ToBoolean(this.ViewState["ClearPrefix"]);
            }
            set { this.ViewState["ClearPrefix"] = value; }
        }

        public Boolean ClearSuffix
        {
            get
            {
                if (this.ViewState["ClearSuffix"] == null)
                {
                    this.ViewState["ClearSuffix"] = true;
                }
                return Convert.ToBoolean(this.ViewState["ClearSuffix"]);
            }
            set { this.ViewState["ClearSuffix"] = value; }
        }

        public Boolean AllowNegative
        {
            get
            {
                if (this.ViewState["AllowNegative"] == null)
                {
                    this.ViewState["AllowNegative"] = false;
                }
                return Convert.ToBoolean(this.ViewState["AllowNegative"]);
            }
            set { this.ViewState["AllowNegative"] = value; }
        }

        public ETypeDirection BubbleTipTypeDirection
        {
            get
            {
                if (this.ViewState["BubbleTipTypeDirection"] == null)
                {
                    this.ViewState["BubbleTipTypeDirection"] = ETypeDirection.Down;
                }
                return (ETypeDirection)this.ViewState["BubbleTipTypeDirection"];
            }
            set { this.ViewState["BubbleTipTypeDirection"] = value; }
        }

        #endregion Properties


		#region Constructors

        public WNumberBox()
        {
			this.Caption = "Caption";
			this.ShowCaption = true;
			this.Required = false;
			this.ErrorMessage = "O campo {0} é obrigatório";
			this.CssClassForArea = "FieldArea";
			this.CssClassForCaption = "FieldCaption";
			this.CssClass = "FieldValue";
        }
		
        #endregion Constructors


		#region Events
        
        protected override void CreateChildControls()
        {
			base.CreateChildControls();

			this._caption = new Label();
			this._caption.ID = String.Concat(this.ID, "_Caption");
			base.Controls.Add(this._caption);

            this._RFV = new RequiredFieldValidator();
			this._RFV.ID = String.Concat(this.ID, "_RFV");
            this._RFV.ControlToValidate = this.ID;
            this._RFV.Display = ValidatorDisplay.Dynamic;
            this._RFV.Text = "<img class='imgInvalid' id='" + ID + "_img_invalid_rfv' src='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.images.erro.gif") + "' title='" + this.ErrorMessage + "'/>";
            this._RFV.CssClass = "asterisco";
			base.Controls.Add(this._RFV);

            if (!String.IsNullOrEmpty(this.BubbleTip))
            {
                this._qtip = new HtmlGenericControl("div");
                this._qtip.Style.Add("display", "none");
                this._qtip.ID = String.Concat(this.ID, "_qtip");

                HtmlGenericControl pre = new HtmlGenericControl("pre");
                pre.InnerHtml = this.BubbleTip;
                pre.Attributes["class"] = "tip";

                this._qtip.Controls.Add(pre);
                base.Controls.Add(this._qtip);
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
                Page.ClientScript.RegisterClientScriptInclude("FlexigridJS", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.flexigrid.js"));
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

			writer.AddAttribute(HtmlTextWriterAttribute.Id, String.Concat(this.ClientID, "_Area"));
			writer.AddAttribute(HtmlTextWriterAttribute.For, this.ClientID);
			if (!String.IsNullOrEmpty(this.CssClassForArea))
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClassForArea);
			}
			writer.RenderBeginTag(HtmlTextWriterTag.Label);

			this._caption.Text = this.Caption;
			this._caption.Visible = this.ShowCaption;
			this._caption.CssClass = this.CssClassForCaption;

			if (String.IsNullOrEmpty(this.ErrorMessage))
			{
				this.ErrorMessage = "O campo {0} é obrigatório";
			}

			this._RFV.ErrorMessage = this.ErrorMessage;
			this._RFV.Enabled = this.Required;
            this._RFV.Display = ValidatorDisplay.Dynamic;
            this._RFV.Text = "<img class='imgInvalid' id='" + ID + "_img_invalid_rfv' src='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.images.erro.gif") + "' title='" + this.ErrorMessage + "'/>";
            this._RFV.ValidationGroup = this.ValidationGroup;

			this._caption.RenderControl(writer);
			base.Render(writer);
			this._RFV.RenderControl(writer);
			
            if(this._qtip != null)
                this._qtip.RenderControl(writer);
			writer.RenderEndTag();

            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("$(function() {");

            strScript.AppendLine(String.Concat("\t$('#", this.ClientID, "').priceFormat({"));
            strScript.AppendLine(String.Concat("\t\tprefix: '", this.Prefix, "'"));
            strScript.AppendLine(String.Concat("\t\t,suffix: '", this.Suffix, "'"));
			strScript.AppendLine(String.Concat("\t\t,centsSeparator: '", this.CentsSeparator ,"'"));
            strScript.AppendLine(String.Concat("\t\t,thousandsSeparator: '", this.ThousandsSeparator, "'"));
            strScript.AppendLine(String.Concat("\t\t,limit: ", this.MaxLength == 0 ? 5 : this.MaxLength));
            strScript.AppendLine(String.Concat("\t\t,centsLimit: ", this.CentsLimit));
            strScript.AppendLine(String.Concat("\t\t,clearPrefix: ", this.ClearPrefix.ToString().ToLower()));
            strScript.AppendLine(String.Concat("\t\t,clearSuffix: ", this.ClearSuffix.ToString().ToLower()));
            strScript.AppendLine(String.Concat("\t\t,allowNegative: ", this.AllowNegative.ToString().ToLower()));
		    strScript.AppendLine("\t});");
            
            strScript.AppendLine("});");
            strScript.AppendLine("");

            Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID, strScript.ToString(), true);

            if (!Page.ClientScript.IsClientScriptBlockRegistered("GeralAfterJS"))
            {
                Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "GeralAfterJS", String.Concat("<script src=\"", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral-after.js"), "\" type=\"text/javascript\"></script>"));
            }
        }
		#endregion Events


		#region Methods
		public Boolean IsValid()
		{
			if (this.Required)
			{
				return !String.IsNullOrEmpty(this.Text);
			}
			return true;
		}

		#endregion Methods

    }
}
