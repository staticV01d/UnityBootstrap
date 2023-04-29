using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;

    public void OnGameOver()
    {
        if (gameOverScreen && gameOverText)
        {
            FindObjectOfType<Move>().canMove = false;
            var timer = FindAnyObjectByType<TimerScript>();
            gameOverText.text = string.Format("Congratulations!\nYou made it to the goal in {0:0} minutes and {1:00} seconds", timer.Minutes, timer.Seconds);
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
