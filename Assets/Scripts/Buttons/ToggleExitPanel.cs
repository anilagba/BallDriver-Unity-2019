using UnityEngine;

public class ToggleExitPanel : MonoBehaviour
{
    public void ToggleOpen()
    {
        CanvasGroup exitPanelCanvas = GameObject.Find("ExitPanel").GetComponent<CanvasGroup>();

        if (exitPanelCanvas.alpha == 0)
        {
            exitPanelCanvas.alpha = 1;
            exitPanelCanvas.blocksRaycasts = true;
        }

        else if (exitPanelCanvas.alpha == 1)
        {
            exitPanelCanvas.alpha = 0;
            exitPanelCanvas.blocksRaycasts = false;
        }
    }
}
