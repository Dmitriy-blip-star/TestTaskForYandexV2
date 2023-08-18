using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float movementSpeed = 5f;

    [SerializeField] float maxDistanceToPlayer;

    private float distanceToPlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < maxDistanceToPlayer)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;

                transform.Translate(direction * movementSpeed * Time.deltaTime);
            }
        }
    }
}