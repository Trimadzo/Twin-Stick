using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{

    public bool recording = true;

    private float initialFixedDeltaTime;
    private bool isPaused = false;

    void Start()
    {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlocked(1));
        print(PlayerPrefsManager.IsLevelUnlocked(2));
        initialFixedDeltaTime = Time.fixedDeltaTime;
        print(initialFixedDeltaTime);
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            ResumeGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = initialFixedDeltaTime;
        isPaused = false;
    }

    private void OnApplicationPause (bool pauseStatus)
    {
        isPaused = pauseStatus;
    }

}
