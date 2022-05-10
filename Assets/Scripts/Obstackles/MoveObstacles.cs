using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform pointA, pointB;
    Vector3 currentPosA;
    Vector3 currentPosB;
    Vector3 currentTarget;


    private void Start()
    {
        currentPosA = pointA.position;
        currentPosB = pointB.position;
        currentTarget = currentPosA;
        int random = Random.Range(1, 4);
        speed *= random;
    }


    void Update()
    {
        Move();
    }


    private void Move()
    {
        if (transform.position.y == currentPosA.y) currentTarget = currentPosB;
        else if (transform.position.y == currentPosB.y) currentTarget = currentPosA;

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
