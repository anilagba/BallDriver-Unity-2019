using UnityEngine;

public class InfoPanelToggle : MonoBehaviour
{
    [SerializeField] CanvasGroup infoPanel;
    public void ToggleOpen()
    {
        if (infoPanel.alpha == 0)
        {
            infoPanel.alpha = 1;
            infoPanel.blocksRaycasts = true;
        }
        else
        {
            infoPanel.alpha = 0;
            infoPanel.blocksRaycasts = false;
        }
    }
}
