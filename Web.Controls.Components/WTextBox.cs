using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Web.Controls.Components
{
	public class WTextBox : TextBox, IWControl
	{

		#region Enumerators
		public enum ETypeMaskTextField
		{
			Numeric,
			Money,
			CPF,
			CNPJ,
			Phone,
			CEP,
			Email,
			Hour,
			Date,
			Default
		}
		#endregion Enumerators


		#region Attributes
		protected Label _caption;
		protected RequiredFieldValidator _RFV;
		protected RegularExpressionValidator _REV;
        protected HtmlGenericControl _qtip;
        private const String dateFormat = "dd/mm/yy";
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

		public ETypeMaskTextField TypeTextField
        {
			get
			{
				if (this.ViewState["TypeTextField"] == null)
				{
					this.ViewState["TypeTextField"] = ETypeMaskTextField.Default;
				}
				return (ETypeMaskTextField)this.ViewState["TypeTextField"];
			}
			set { this.ViewState["TypeTextField"] = value; }
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
        
        public WTextBox()
        {
			this.Caption = "Caption";
			this.ShowCaption = true;
			this.Required = false;
			this.ErrorMessage = "O campo {0} é obrigatório";
			this.CssClassForArea = "FieldArea";
			this.CssClassForCaption = "FieldCaption";
			this.CssClass = "FieldValue";
			this.TypeTextField = ETypeMaskTextField.Default;
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

            this._REV = new RegularExpressionValidator();
			this._REV.ID = String.Concat(this.ID, "_REV");
            this._REV.ControlToValidate = this.ID;
            this._REV.Display = ValidatorDisplay.Dynamic;
            this._REV.Text = "<img class='imgInvalid' id='" + ID + "_img_invalid_rfv' src='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.images.erro.gif") + "' title='" + this.ErrorMessage + "'/>";
            this._REV.CssClass = "asterisco";
            base.Controls.Add(this._REV);

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

            if (this.TypeTextField == ETypeMaskTextField.Date)
            {
                base.Attributes["control"] = "date";
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

			if (this.TypeTextField != ETypeMaskTextField.Default)
			{
				base.Attributes.Add("onkeyup", getFormat(TypeTextField));
                base.Attributes.Add("onblur", getFormat(TypeTextField));
				base.MaxLength = getMaxLenghtFormat(TypeTextField);
			}

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

			this._REV.ErrorMessage = String.Format(getMessageErrorExpression(this.TypeTextField), this.Caption);
			this._REV.ValidationExpression = GetValidationExpression(this.TypeTextField);
            this._REV.Display = ValidatorDisplay.Dynamic;
            this._REV.Enabled = ((this.TypeTextField != ETypeMaskTextField.Default) && (this.TypeTextField != ETypeMaskTextField.Numeric));
            this._REV.Text = "<img class='imgInvalid' id='" + ID + "_img_invalid_rev' src='" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.images.erro.gif") + "' title='" + this._REV.ErrorMessage + "'/>";
            this._REV.ValidationGroup = this.ValidationGroup;

			this._caption.RenderControl(writer);
			base.Render(writer);
			this._RFV.RenderControl(writer);
			this._REV.RenderControl(writer);
            if(this._qtip != null)
                this._qtip.RenderControl(writer);
			writer.RenderEndTag();

            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("$(function() {");
            if (this._qtip != null)
            {
                strScript.AppendLine(String.Concat("\t$('#", this.ClientID, "').bubbletip("));
                strScript.AppendLine(String.Concat("\t\t$('#", this._qtip.ClientID, "'), {"));
                strScript.AppendLine(String.Concat("\t\t\tdeltaDirection: '", BubbleTipTypeDirection.ToString().ToLower(), "'"));
				strScript.AppendLine("\t\t\t,bindShow: 'focus'");
                strScript.AppendLine("\t\t\t,bindHide: 'blur'");
			    strScript.AppendLine("\t\t}");
                strScript.AppendLine("\t);");
            }

            if (this.TypeTextField == ETypeMaskTextField.Date)
            {
                strScript.AppendLine("\t\t$(\"#" + this.ClientID + "\" ).datepicker({ showOn: 'button', buttonImage: '" + Page.ClientScript.GetWebResourceUrl(this.GetType(), "Web.Controls.Components.images.calendar.gif") + "', buttonImageOnly: true, dateFormat:'"+ dateFormat +"' });");
            }

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

		private String getFormat(ETypeMaskTextField e)
        {
            String str = string.Empty;
            switch (e)
            {
                case ETypeMaskTextField.CEP: str = "maskCep(this)"; break;
                case ETypeMaskTextField.CNPJ: str = "maskCnpj(this)"; break;
                case ETypeMaskTextField.CPF: str = "maskCpf(this)"; break;
                case ETypeMaskTextField.Money: str = "maskMoney(this)"; break;
                case ETypeMaskTextField.Numeric: str = "maskNumber(this)"; break;
                case ETypeMaskTextField.Phone: str = "maskPhone(this)"; break;
                case ETypeMaskTextField.Hour: str = "maskHour(this)"; break;
                case ETypeMaskTextField.Date: str = "maskDate(this)"; break;
            }
            return str;
        }
        private Int32 getMaxLenghtFormat(ETypeMaskTextField e)
        {
            Int32 length = 0;
            switch (e)
            {
                case ETypeMaskTextField.CEP: length = 9; break;
                case ETypeMaskTextField.CNPJ: length = 18; break;
                case ETypeMaskTextField.CPF: length = 14; break;
                case ETypeMaskTextField.Money: length = 10; break;
                case ETypeMaskTextField.Phone: length = 14; break;
                case ETypeMaskTextField.Hour: length = 5; break;
                case ETypeMaskTextField.Date: length = 10; break;
                default: length = this.MaxLength; break;
            }
            return length;
        }

		private String GetValidationExpression(ETypeMaskTextField e)
		{
            switch (e)
            {
				case ETypeMaskTextField.Email: return @"[\w!#$%&'*+\/=?^`{|}~-]+(\.[\w!#$%&'*+\/=?^`{|}~-]+)*@(([\w-]+\.)+[A-Za-z]{2,6}|\[\d{1,3}(\.\d{1,3}){3}\])";
				//case ETypeMaskTextField.Date: return @"((0?[1-9]|[12]\d)\/(0?[1-9]|1[0-2])|30\/(0?[13-9]|1[0-2])|31\/(0?[13578]|1[02]))\/(19|20)?\d{2}";
				case ETypeMaskTextField.Date: return @"((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))";
				case ETypeMaskTextField.CPF: return @"(\d{3}\.\d{3}\.\d{3}-\d{2})|(\d{11})";
				case ETypeMaskTextField.CEP: return @"([0-9]){5}([-])([0-9]){3}";
				case ETypeMaskTextField.CNPJ: return @"(\d{2,3})\.?(\d{3})\.?(\d{3})\/?(\d{4})\-?(\d{2})";
				case ETypeMaskTextField.Money: return @"\d{1,3}(\.\d{3})*\,\d{2}";
				case ETypeMaskTextField.Phone: return @"\(?\d{2}\)?[\s-]?\d{4}-?\d{4}";
				case ETypeMaskTextField.Hour: return @"([0-1]\d|2[0-3]):[0-5]\d";
				default: return String.Empty;
			}
		}

		//private String getTypeExpressionText(ETypeMaskTextField e)
		//{
		//    String str = String.Empty;
		//    switch (e)
		//    {
		//        case ETypeMaskTextField.CEP: str = "cep"; break;
		//        case ETypeMaskTextField.CNPJ: str = "cnpj"; break;
		//        case ETypeMaskTextField.CPF: str = "cpf"; break;
		//        case ETypeMaskTextField.Money: str = "money"; break;
		//        case ETypeMaskTextField.Phone: str = "phone"; break;
		//        case ETypeMaskTextField.Hour: str = "hour"; break;
		//        case ETypeMaskTextField.Date: str = "date"; break;
		//        case ETypeMaskTextField.Email: str = "email"; break;
		//    }
		//    return str;
		//}
        private String getMessageErrorExpression(ETypeMaskTextField e)
        {
            String str = "{0} inválido. ";
            switch (e)
            {
                case ETypeMaskTextField.CEP: str += "Ex: 111111-000."; break;
                case ETypeMaskTextField.CNPJ: str += "Ex: 65.685.024/0001-77."; break;
                case ETypeMaskTextField.CPF: str += "Ex: 111.111.111-11."; break;
                case ETypeMaskTextField.Money: str += "Ex: 111.111,12."; break;
                case ETypeMaskTextField.Phone: str += "Ex: (11) 1111-1111."; break;
                case ETypeMaskTextField.Hour: str += "Ex: 00:00."; break;
                case ETypeMaskTextField.Date: str += "Ex: 01/01/2001."; break;
                case ETypeMaskTextField.Email: str += "Ex: teste@teste.com."; break;
            }
            return str;
        }
        #endregion Methods

    }
}
