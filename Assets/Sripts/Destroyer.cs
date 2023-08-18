using Assets.Scripts;
using UnityEngine;

namespace Assets.Sripts
{
    public class Destroyer : MonoBehaviour
    {
        private void Update()
        {
            transform.Translate(new Vector2(Player.speed * Time.deltaTime, 0));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
