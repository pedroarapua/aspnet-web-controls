using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace Web.Controls.Components
{
    public class AjaxEventArgument
    {
        #region atributos

        private Dictionary<String, object> _arguments;
        private String _argumentsString;
        private Dictionary<String, object> _argumentsResponse;
        private String _argumentsStringResponse;

        #endregion

        #region construtores

        public AjaxEventArgument()
        {
            this._arguments = new Dictionary<String, object>();
            this._argumentsString = String.Empty;
            this._argumentsResponse = new Dictionary<String, object>();
            this._argumentsStringResponse = String.Empty;
        }

        public AjaxEventArgument(String argumentsString)
        {
            // instancia de objetos
            this._argumentsResponse = new Dictionary<String, object>();
            this._argumentsStringResponse = String.Empty;

            this._argumentsString = argumentsString;
            object obj = new JavaScriptSerializer().DeserializeObject(this._argumentsString);
			if(obj == null)
				obj = new Dictionary<String, object>();
            this._arguments =  obj as Dictionary<String, object>;
        }

        #endregion

        #region propriedades

        public Dictionary<String, object> Arguments
        {
            get { return this._arguments; }
            set { this._arguments = value; }
        }

        public String ArgumentsString
        {
            get { return this._argumentsString; }
            set { this._argumentsString = value; }
        }

        public Dictionary<String, object> ArgumentsResponse
        {
            get { return this._argumentsResponse; }
            set { this._argumentsResponse = value; }
        }

        public String ArgumentsStringResponse
        {
            get { return new JavaScriptSerializer().Serialize(this._argumentsResponse); }
        }

        #endregion

    }
}