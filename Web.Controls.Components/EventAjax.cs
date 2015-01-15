using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;

namespace Web.Controls.Components
{
    public class EventAjax 
    {
        #region     .....:::::     ATRIBUTOS     :::::.....

        private String _methodName;
        private List<Argument> _arguments;
        
        #endregion

        #region     .....:::::     CONSTRUTORES     :::::.....

        public EventAjax()
        {
            this._arguments = new List<Argument>();
        }

        #endregion

        #region     .....:::::     PROPRIEDADES     :::::.....

        public String MethodName
        {
            get { return this._methodName; }
            set { this._methodName = value; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Argument> Arguments
        {
            get { return this._arguments; }
            set { this._arguments = value; }
        }

        #endregion
    }

    public class Argument
    {

        #region     .....:::::     ATRIBUTOS     :::::.....

        private String _name;
        private String _value;
        private ETypeArgument _type;

        #endregion

        #region     .....:::::     CONSTRUTORES     :::::.....

        public Argument()
        {
            this._type = ETypeArgument.Static;
        }

        #endregion

        #region     .....:::::     PROPRIEDADES     :::::.....

        public String Name
        {
            get { return _name; }
            set { this._name = value; }
        }

        public String Value
        {
            get { return _value; }
            set { this._value = value; }
        }

        public ETypeArgument Type
        {
            get { return _type; }
            set { this._type = value; }
        }

        #endregion
    }

    public enum ETypeArgument
    {
        Dinamyc = 0,
        Static = 1
    }
}
