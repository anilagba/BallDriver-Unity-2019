using UnityEngine;

public class RenewBouncy : MonoBehaviour
{
    [SerializeField] PhysicsMaterial2D material;
    private void Start()
    {
        material.bounciness = 0.2f;

        GetComponent<CircleCollider2D>().enabled = false;// to renew the bounciness 
        GetComponent<CircleCollider2D>().enabled = true;//without this, bounciness value doesnt change
    }
}
