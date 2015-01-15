using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;

namespace Web.Controls.Components
{
    public class TabItem 
    {
        #region     .....:::::     ATRIBUTOS     :::::.....

        private String _titulo;
        private String _href;
        private String _associateBodyAbasId;
        private Boolean _disabled;
        
        #endregion

        #region     .....:::::     PROPRIEDADES     :::::.....

        public String Titulo
        {
            get { return this._titulo; }
            set { this._titulo = value; }
        }

        public String Href
        {
            get { return this._href; }
            set { this._href = value; }
        }

        public String AssociateBodyAbasId
        {
            get { return this._associateBodyAbasId; }
            set { this._associateBodyAbasId = value; }
        }

        public Boolean Disabled
        {
            get { return this._disabled; }
            set { this._disabled = value; }
        }

        #endregion
    }
}
