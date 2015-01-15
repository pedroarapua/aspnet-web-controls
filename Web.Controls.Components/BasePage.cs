using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Web;
using System.Reflection;
using System.Configuration;

namespace Web.Controls.Components
{
    public class BasePage : System.Web.UI.Page
    {
        #region     .....:::::     PROPRIEDADES     :::::.....

        public Int32 PageSize
        {
            get
            {
                if(!String.IsNullOrEmpty(ConfigurationManager.AppSettings["PageSize"]))
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
                }
                else
                {
                    return 10;
                }
            }
            set
            {
                ConfigurationManager.AppSettings["PageSize"] = value.ToString();
            }

        }

        #endregion

        #region     .....:::::     EVENTOS     :::::.....

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StringBuilder strScript = new StringBuilder();
            strScript.AppendLine("\t$(function() {");
            strScript.AppendLine("\t\t$('.imgInvalid').tooltip({ tooltipClass: 'custom-tooltip-styling', position: { my: 'left+15 center', at: 'right center' } });");
            strScript.AppendLine("\t\t$(\"[control='tab']\").tabs();");
            strScript.AppendLine("\t\t$(\"[control='accordion']\" ).accordion();");
            
            strScript.AppendLine("\t\t$(\"input[onkeyup='maskDate(this)']\").datepicker({ ");
            strScript.AppendLine("\t\t\tdayNames: [ \"Domingo\", \"Segunda\", \"Terça\", \"Quarta\", \"Quinta\", \"Sexta\", \"Sábado\" ],");
            strScript.AppendLine("\t\t\tdayNamesMin: [\"Dom\", \"Seg\", \"Ter\", \"Qua\", \"Qui\", \"Sex\", \"Sáb\" ],");
            strScript.AppendLine("\t\t\tmonthNames: [ \"Janeiro\", \"Fevereiro\", \"Março\", \"Abril\", \"Maio\", \"Junho\", \"Julho\", \"Agosto\", \"Setembro\", \"Outubro\", \"Novembro\", \"Dezembro\" ],");
			strScript.AppendLine("\t\t\tmonthNamesShort: [ \"Jan\", \"Fev\", \"Mar\", \"Abr\", \"Mai\", \"Jun\", \"Jul\", \"Ago\", \"Set\", \"Out\", \"Nov\", \"Dez\" ]");
            strScript.AppendLine("\t\t});");

            strScript.AppendLine("\t\t$(\"[control='button']\").button();");
            strScript.AppendLine("\t});");
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "init", strScript.ToString(), true);
        }

        #endregion

        #region     .....:::::     MÉTODOS     :::::.....

        private void LoadPage()
        {
            String methodName = Request.QueryString["methodName"];
            String transactionType = Request.QueryString["transactionType"];
            if (!String.IsNullOrEmpty(methodName))
            {
                // chama o evento da página

                MethodInfo methodAjax = this.Page.GetType().GetMethod(methodName);
                AjaxEventArgument args;

                if (!String.IsNullOrEmpty(transactionType) && transactionType.Equals("POST"))
                {
                    string parametros = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
                    args = new AjaxEventArgument(parametros);
                }
                else
                {
                    args = new AjaxEventArgument(Request.QueryString["params"]);
                }
                methodAjax.Invoke(this.Page, new object[] { args });

                JavaScriptSerializer json = new JavaScriptSerializer();

                //byte[] bytes = System.Text.Encoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, System.Text.Encoding.Default.GetBytes(args.ArgumentsStringResponse));

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.ContentType = "application/json; charset=utf-8";
                //Response.ContentType = "text/xml; charset=utf-8";
                Response.Write(args.ArgumentsStringResponse);
                //Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.End();
            }
        }

        #endregion

    }
}
