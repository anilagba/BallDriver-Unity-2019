using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Change();
    }

    public void Change()
    {
        GameObject ball = GameObject.Find("Ball");

        if (gameObject.tag == "MakeBigger")
        {
            if (ball.transform.localScale.x < 3.5f && ball.transform.localScale.y < 3.5f)
                ball.transform.localScale *= 1.3f;
            Destroy(gameObject);
        }
        else if (gameObject.tag == "MakeSmaller")
        {
            if (ball.transform.localScale.x > 0.3f && ball.transform.localScale.y > 0.3f)
                ball.transform.localScale /= 1.3f;
            Destroy(gameObject);
        }
    }
}
