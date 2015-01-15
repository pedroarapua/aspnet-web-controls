using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;

namespace Web.Controls.Components
{
    public class EventListener 
    {
        #region     .....:::::     ATRIBUTOS     :::::.....

        private String _fn;
        
        #endregion

        #region     .....:::::     PROPRIEDADES     :::::.....

        public String Fn
        {
            get { return this._fn; }
            set { this._fn = value; }
        }

        #endregion
    }
}
