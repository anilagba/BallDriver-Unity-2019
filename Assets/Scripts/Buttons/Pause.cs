using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Sprite gamePaused;
    [SerializeField] Sprite gameResume;
    [SerializeField] GameObject pausePanel;

    public void TogglePause()
    {
        CanvasGroup canvasGroup = pausePanel.GetComponent<CanvasGroup>();

        if (Time.timeScale == 1)
        {
            transform.parent.GetComponent<Image>().sprite = gamePaused;
            Time.timeScale = 0;
            FindObjectOfType<FollowCamera>().enabled = false;
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            transform.parent.GetComponent<Image>().sprite = gameResume;
            Time.timeScale = 1;
            FindObjectOfType<FollowCamera>().enabled = true;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
