using Assets.Scripts;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject player;

    [SerializeField] public float mapLength;

    [SerializeField] GameObject map, obstacle, coin;

    private float randomY;
    private float randomX;
    private int amountObstacle;
    [SerializeField] float minDistance = 0.5f;

    private float minY = -3.75f;
    private float maxY = 3.25f;
    private float maxX = 1;
    private float minX = 0;

    private Vector2 lastSpawnMap;

    private Vector2 playerPosition;

    private void Update()
    {
        if (player != null)
        {
            playerPosition = player.transform.position;
        }

        if (playerPosition.x > lastSpawnMap.x)
        {
            MapSpawn();
            ObstacleSpawn();
            CoinSpawn();
        }
    }
    private void MapSpawn()
    {
        lastSpawnMap.x += mapLength;
        Instantiate(map, new Vector2(lastSpawnMap.x, 0), transform.rotation);
    }

    private void ObstacleSpawn()
    {
        amountObstacle = Mathf.Clamp(amountObstacle, 1, 4);
        for (int i = 0; i < amountObstacle; i++)
        {
            bool positionIsValid = false;
            do
            {
                randomY = Random.Range(minY, maxY);
                randomX = lastSpawnMap.x + -Random.Range(minX, maxX);
                Collider2D[] colliders = Physics2D.OverlapBoxAll
                    (new Vector2(randomX, randomY), new Vector2(minDistance, minDistance), 45f);
                if (colliders.Length == 0)
                {
                    positionIsValid = true;
                }
            } while (!positionIsValid);

            Instantiate(obstacle, new Vector2(randomX, randomY), transform.rotation);
        }
    }

    private void CoinSpawn()
    {
        Instantiate(coin, new Vector2(lastSpawnMap.x, randomY), transform.rotation);
    }

    private void OnEnable()
    {
        Player.InfoPrinted += CoinsChenged;
    }

    private void OnDisable()
    {
        Player.InfoPrinted -= CoinsChenged;
    }

    private void CoinsChenged(int coin)
    {
        amountObstacle = coin;
    }
}
