using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Tab;

    bool isPaused;

    Move playerMovement;

    void Start()
    {
        playerMovement = FindAnyObjectByType<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePaused();
        }
    }

    void TogglePaused()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (playerMovement)
                playerMovement.canMove = false;
            if (Time.timeScale > 0)
            { Time.timeScale = 0; }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (playerMovement)
                playerMovement.canMove = true;
            if (Time.timeScale == 0)
            { Time.timeScale = 1; }
        }
    }
}
