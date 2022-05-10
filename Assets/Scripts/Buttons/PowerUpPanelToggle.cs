using UnityEngine;

public class PowerUpPanelToggle : MonoBehaviour
{
    [SerializeField] CanvasGroup powerUpPanel;

    public void ToggleOpen()
    {

        if (powerUpPanel.alpha == 0)
        {
            powerUpPanel.alpha = 1;
            powerUpPanel.blocksRaycasts = true;
        }
        else if (powerUpPanel.alpha == 1)
        {
            powerUpPanel.alpha = 0;
            powerUpPanel.blocksRaycasts = false;
        }
    }
}
