using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sripts
{
    public class Presenter : MonoBehaviour
    {
        [SerializeField] Text score;
        [SerializeField] Text startGame;

        bool isGameStarted = false;

        private void Update()
        {
            if (!isGameStarted)
            {
                Time.timeScale = 0;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    startGame.enabled = false;
                    isGameStarted = true;
                    Time.timeScale = 1;
                }
            }
        }

        private void OnEnable()
        {
            Player.InfoPrinted += HandleInfoPrinted;
        }

        private void OnDisable()
        {
            Player.InfoPrinted -= HandleInfoPrinted;
        }

        private void HandleInfoPrinted(int info)
        {
            score.text = info.ToString();
        }
    }
}