using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOT.Triggers;

public class ButtonTextTriggerAction : TriggerAction<Button>
{
    /// <summary>
    /// Change the button text when the click event is triggered
    /// </summary>
    /// <param name="button">The button to change text</param>
    protected override void Invoke(Button button)
    {
        if (button != null)
        {
            if (button.Text == "Follow")
            {
                button.Text = "Followed";
            }
            else if (button.Text == "Followed")
            {
                button.Text = "Follow";
            }
        }
    }
}
