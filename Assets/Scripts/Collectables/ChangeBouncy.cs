using UnityEngine;

public class ChangeBouncy : MonoBehaviour
{
    [SerializeField] float changeRate;
    [SerializeField] PhysicsMaterial2D material;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeAll();
    }

    #region ChangeAll
    public void ChangeAll()
    {
        if (gameObject.tag == "IncreaseBouncy")
        {
            GameObject.Find("Ball").GetComponent<CircleCollider2D>().enabled = false;// to renew the bounciness 
            IncreaseBouncy();                                          //without this bounciness value
            GameObject.Find("Ball").GetComponent<CircleCollider2D>().enabled = true; // doesnt change
            Destroy(gameObject);
        }
        else if (gameObject.tag == "DecreaseBouncy")
        {
            GameObject.Find("Ball").GetComponent<CircleCollider2D>().enabled = false;
            DecreaseBouncy();
            GameObject.Find("Ball").GetComponent<CircleCollider2D>().enabled = true;
            Destroy(gameObject);
        }
    }
    #endregion

    #region IncreaseBouncy
    public void IncreaseBouncy()
    {
        if ((material.bounciness + changeRate) <= 0.7f)
        {
            material.bounciness += changeRate;
        }
        else material.bounciness = 0.7f;
    }
    #endregion

    #region DecreaseBouncy
    public int DecreaseBouncy()
    {
        if (material.bounciness > 0)
        {
            material.bounciness -= changeRate;
            return 0;
        }
        else if (material.bounciness <= 0) return 1;
        else return 2;
    }
    #endregion
}
