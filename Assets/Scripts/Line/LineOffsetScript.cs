using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineOffsetScript : MonoBehaviour
{
    public TextMeshProUGUI[] valueTxts;
    public int multiplier;
    PlayerSettingsData playerData;
    float xOffset;
    float yOffset;
    float width;
    float gameSpeed;

    private void Awake()
    {
        UpdateData();
    }

    private void Start()
    {
        playerData = SaveDatas.LoadData();

        if (playerData.lineWidth == 0 || playerData == null) playerData.lineWidth = 0.5f;

        GameObject.Find("SliderY").GetComponent<Slider>().value = playerData.lineOffsetY / multiplier;
        GameObject.Find("SliderX").GetComponent<Slider>().value = playerData.lineOffsetX / multiplier;
        GameObject.Find("LineWidthSlider").GetComponent<Slider>().value = playerData.lineWidth;
        //GameObject.Find("SliderSpeed").GetComponent<Slider>().value = playerData.gameSpeed;
    }


    #region UpdateData
    private void UpdateData()
    {
        if (SaveDatas.LoadData() != null) return;
        else SaveDatas.SaveData(0, 0, 0.5f, 1);
    }
    #endregion

    //to define how far the line is from the touch point on x axis
    #region XAxisOffset 
    public void XAxisOffset()
    {
        xOffset = GameObject.Find("SliderX").GetComponent<Slider>().value;
        valueTxts[0].text = xOffset.ToString("f0");
    }
    #endregion

    //to define how far the line is from the touch point on y axis
    #region YAxis
    public void YAxis()
    {
        yOffset = GameObject.Find("SliderY").GetComponent<Slider>().value;
        valueTxts[1].text = yOffset.ToString("f0");
    }
    #endregion


    #region SetWidth
    public void SetWidth()
    {
        width = GameObject.Find("LineWidthSlider").GetComponent<Slider>().value;
        valueTxts[2].text = width.ToString("f2");
    }
    #endregion

    #region GameSpeed
    public void GameSpeed()
    {
        gameSpeed = GameObject.Find("SliderSpeed").GetComponent<Slider>().value;
        valueTxts[3].text = gameSpeed.ToString("f2");
    }
    #endregion

    #region Save
    public void Save()
    {
        SaveDatas.SaveData(xOffset * multiplier, yOffset * multiplier, width, gameSpeed);
    }
    #endregion
}
