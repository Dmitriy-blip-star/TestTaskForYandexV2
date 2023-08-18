using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float amplitude = 1.0f;

    private int sign;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        AssignRandomSign();
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector3(transform.position.x, sign * newY, transform.position.z);
    }

    private void AssignRandomSign()
    {
        sign = Random.Range(0, 2) == 0 ? -1 : 1;
    }
}
