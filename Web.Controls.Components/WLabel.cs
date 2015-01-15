using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Controls.Components
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:WLabel runat=server></{0}:WLabel>")]
	public class WLabel : WebControl, INamingContainer , ITextControl
	{


		#region Attributes
		protected Label _fieldCaption;
		protected Label _fieldValue;
		#endregion Attributes


		#region Properties
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("Caption")]
		[Localizable(true)]
		public string Caption
		{
			get
			{
				base.EnsureChildControls();
				return this._fieldCaption.Text;
			}
			set
			{
				base.EnsureChildControls();
				this._fieldCaption.Text = value;
			}
		}

		public bool ShowCaption
		{
			get
			{
				base.EnsureChildControls();
				return this._fieldCaption.Visible;
			}
			set
			{
				base.EnsureChildControls();
				this._fieldCaption.Visible = value;
			}
		}

		public string Text
		{
			get
			{
				base.EnsureChildControls();
				return this._fieldValue.Text;
			}
			set
			{
				base.EnsureChildControls();
				this._fieldValue.Text = value;
			}
		}

		public string CssClassOfCaption
		{
			get
			{
				base.EnsureChildControls();
				return this._fieldCaption.CssClass;
			}
			set
			{
				base.EnsureChildControls();
				this._fieldCaption.CssClass = value;
			}
		}

		public string CssClassOfValue
		{
			get
			{
				base.EnsureChildControls();
				return this._fieldValue.CssClass;
			}
			set
			{
				base.EnsureChildControls();
				this._fieldValue.CssClass = value;
			}
		}

       #endregion Properties


        #region Methods
        public WLabel()
        {
            base.EnsureChildControls();
            this.CssClass = "FieldArea";
            this._fieldCaption.CssClass = "FieldCaption";
            this._fieldValue.CssClass = "FieldText";

            this._fieldCaption.Text = "Caption";
        }

		protected override void CreateChildControls()
		{
			base.Controls.Clear();

			this._fieldCaption = new Label();
			this._fieldCaption.ID = "Caption";
			base.Controls.Add(this._fieldCaption);

			this._fieldValue = new Label();
			this._fieldValue.ID = "Value";
			base.Controls.Add(this._fieldValue);
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
			base.AddAttributesToRender(writer);

			writer.AddAttribute(HtmlTextWriterAttribute.For, this._fieldValue.ClientID);
			writer.RenderBeginTag(HtmlTextWriterTag.Label);

			this._fieldCaption.RenderControl(writer);
			this._fieldValue.RenderControl(writer);

			writer.RenderEndTag();

            if (!Page.ClientScript.IsClientScriptBlockRegistered("GeralAfterJS"))
            {
                Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "GeralAfterJS", String.Concat("<script src=\"", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.script.geral-after.js"), "\" type=\"text/javascript\"></script>"));
            }
		}
		#endregion Methods

	}
}
