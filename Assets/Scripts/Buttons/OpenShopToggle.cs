using UnityEngine;

public class OpenShopToggle : MonoBehaviour
{
    [SerializeField] CanvasGroup shopPanel;

    public void ToggleShopOpen()
    {

        if (shopPanel.alpha == 0)
        {
            shopPanel.alpha = 1;
            shopPanel.blocksRaycasts = true;
        }
        else if (shopPanel.alpha == 1)
        {
            shopPanel.alpha = 0;
            shopPanel.blocksRaycasts = false;
        }
    }
}
