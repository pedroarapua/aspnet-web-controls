using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Controls.Components;

namespace Web.Controls.Test
{
    public partial class Teste : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //grdTeste.OnPageIndexChange += new Web.Controls.Components.WGrid.PageIndexChangeHandler(grdTeste_OnPageIndexChange);
            //lnkPesquisar.Click += new WButton.OnClickHandler(teste_click);
            if(!IsPostBack)
            {
                grdTeste_OnPageIndexChange(1);
            }
        }

        protected void grdTeste_OnPageIndexChange(int PageIndex)
        {
            List<String> lst = new List<String>();
            for (int i = 0; i < PageIndex;i++ )
                lst.Add(i.ToString());
            grdTeste.DataSource = lst;
            grdTeste.DataBind();
            
            grdTeste.LoadPagination(5, PageIndex, 10);
        }

        protected void teste_click(object sender, EventArgs e)
        {
            lnkPesquisar.Text = "Trocou de texto";
            List<String> lst = new List<String>(new String[] { "a", "b", "c", "d" });
            grdTeste.DataSource = lst;
            grdTeste.DataBind();
        }

        
    }
}
