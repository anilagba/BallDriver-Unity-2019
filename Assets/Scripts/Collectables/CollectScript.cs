using UnityEngine;

public class CollectScript : MonoBehaviour
{
    Vector3 touchPos;

    void Update()
    {
        if (Time.timeScale != 0 && Input.GetKey(KeyCode.Mouse0)) DetectCollectables();
    }

    private void DetectCollectables()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 2) touchPos = new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y, 1);
            else touchPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1);
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), Vector3.zero, LayerMask.GetMask("Coin", "Star", "Booster", "SizeChangers", "BouncyChangers")); ;

        if (!hit) return;

        else
        {
            if (hit.collider.GetComponent<AddPoints>()) hit.collider.GetComponent<AddPoints>().Add(1);
            else if (hit.collider.GetComponent<BoostTheScore>()) hit.collider.GetComponent<BoostTheScore>().Boost(10);
            else if (hit.collider.GetComponent<ChangeSize>()) hit.collider.GetComponent<ChangeSize>().Change();
            else if (hit.collider.GetComponent<ChangeBouncy>()) hit.collider.GetComponent<ChangeBouncy>().ChangeAll();
            else return;
        }
    }
}
