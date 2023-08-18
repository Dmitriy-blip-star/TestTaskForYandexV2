using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float jumpPower, fallSpeed;
        [SerializeField] private Rigidbody2D rb;
        public static float speed { get; private set; } = 10;

        private int coin = 0;

        public delegate void InfoPrintedEventHandler(int info);
        public static event InfoPrintedEventHandler InfoPrinted;

        private void Update()
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, -fallSpeed * Time.deltaTime));

            if (Input.GetButton("Jump") || Input.GetMouseButton(0))
            {
                rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, jumpPower);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Coin")
            {
                Destroy(collision.transform.parent.gameObject);
                coin++;
                PrintInfo(coin);
            }

            if (collision.tag == "Obstacle")
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }
        }

        private void PrintInfo(int info)
        {
            Debug.Log(info);
            InfoPrinted?.Invoke(info);
        }
    }
}