using UnityEngine;
using UnityEngine.UI;

public class ToggleSettingsOpen : MonoBehaviour
{
    CanvasGroup settingsPanel;

    private void Start()
    {
        settingsPanel = GameObject.Find("SettingsPanel").GetComponent<CanvasGroup>();
    }

    #region CloseSettings
    public void CloseSettings()
    {
        settingsPanel.alpha = 0;
        settingsPanel.blocksRaycasts = false;
    }
    #endregion

    #region OpenSettings
    public void OpenSettings()
    {
        settingsPanel.alpha = 1;
        settingsPanel.blocksRaycasts = true;
    }
    #endregion

    #region ReLoadDatas
    public void ReLoadDatas()
    {
        PlayerSettingsData playerData = SaveDatas.LoadData();
        LineOffsetScript lineOffset = FindObjectOfType<LineOffsetScript>();
        lineOffset.valueTxts[0].text = (playerData.lineOffsetX / lineOffset.multiplier).ToString();
        lineOffset.valueTxts[1].text = (playerData.lineOffsetY / lineOffset.multiplier).ToString();
        lineOffset.valueTxts[2].text = (playerData.lineWidth).ToString("f2");
        lineOffset.valueTxts[3].text = (playerData.gameSpeed).ToString("f2");
        GameObject.Find("SliderX").GetComponent<Slider>().value = playerData.lineOffsetX / lineOffset.multiplier;
        GameObject.Find("SliderY").GetComponent<Slider>().value = playerData.lineOffsetY / lineOffset.multiplier;
        GameObject.Find("LineWidthSlider").GetComponent<Slider>().value = playerData.lineWidth;
        // GameObject.Find("SliderSpeed").GetComponent<Slider>().value = playerData.gameSpeed;
    }
    #endregion
}
