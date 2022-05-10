using UnityEngine;

public class ToggleSelection : MonoBehaviour
{
    [SerializeField] CanvasGroup selectionPanel;
    public void ToggleSelectionOpen()
    {

        if (selectionPanel.alpha == 0)
        {
            selectionPanel.alpha = 1;
            selectionPanel.blocksRaycasts = true;
        }
        else if (selectionPanel.alpha == 1)
        {
            selectionPanel.alpha = 0;
            selectionPanel.blocksRaycasts = false;
        }
    }
}
