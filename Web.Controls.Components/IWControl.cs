using System;

namespace Web.Controls.Components
{
	public interface IWControl
	{
		String Caption { get; set; }
		Boolean ShowCaption { get; set; }
		String ErrorMessage { get; set; }
		Boolean Required { get; set; }
		String CssClassForArea { get; set; }
		String CssClassForCaption { get; set; }
        String BubbleTip { get; set; }
        ETypeDirection BubbleTipTypeDirection { get; set; }

		Boolean IsValid();
	}

    public enum ETypeDirection
    {
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
    }
}
