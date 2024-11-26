using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsScreen : MainMenu
{
    public override void GoToControls()
    {
        gameObject.SetActive(true);
    }

    public override void GoToMenu()
    {
        gameObject.SetActive(false);
    }
}
