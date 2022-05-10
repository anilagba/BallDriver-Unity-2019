using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BoxBreaker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI avoidNumberLeftTxt;
    public int avoidNumber;
    List<GameObject> boxes;
    private void Start()
    {
        boxes = new List<GameObject>();
        avoidNumber = 0;
        DisplayNumb();
    }

    #region OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && avoidNumber > 0)
        {
            bool isAdded = new bool();
            foreach (GameObject box in boxes)
            {
                if (collision.gameObject == box) isAdded = true;
                else isAdded = false;
                if (boxes.Count > 6) boxes.Remove(boxes[boxes.Count - 5]);
            }
            if (isAdded) return;
            else
            {
                boxes.Add(collision.gameObject);
                IncreaseAvoidNumb(-1);
            }
        }
        else return;
    }
    #endregion

    #region IncreaseAvoidNumb
    public void IncreaseAvoidNumb(int numb)
    {
        avoidNumber += numb;
        DisplayNumb();
    }
    #endregion

    #region DisplayNumb
    private void DisplayNumb()
    {
        if (avoidNumber > 0) avoidNumberLeftTxt.text = avoidNumber.ToString();
        else avoidNumberLeftTxt.text = "";
    }
    #endregion
}
