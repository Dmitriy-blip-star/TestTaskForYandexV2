using Assets.Scripts;
using UnityEditorInternal;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(new Vector2(Player.speed * Time.deltaTime, 0));
    }
}
