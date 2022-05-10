using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] CalculateScore score;
    [SerializeField] [Tooltip("boost the camera speed by score/SpeedUp")] float speedUp;
    [Tooltip("Slow Down upgrade multiplier")] public float multiplier;

    private void Start()
    {
        multiplier = 1;
       // speedUp /= SaveDatas.LoadData().gameSpeed;
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = new Vector2(transform.position.x + Time.deltaTime * 2f / multiplier + score.score / (speedUp * multiplier),
            Mathf.Lerp(transform.position.y, ball.transform.position.y, 0.025f));
    }
}
