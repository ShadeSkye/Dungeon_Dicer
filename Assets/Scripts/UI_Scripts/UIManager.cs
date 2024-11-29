using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject exitMenu;
    [SerializeField] GameObject gameWin;

    public static bool PlayerCanLeave = false;
    public bool InventoryOpen = false;

   public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        GameManager.GamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        GameManager.GamePaused = false;
    }

    public void PlayerWantsToLeave()
    {
        exitMenu.SetActive(true);
        GameManager.GamePaused = true;
    }

    public void CloseExitMenu()
    {
        exitMenu.SetActive(false);
    }

    public void ShowWinScreen()
    {
        gameWin.SetActive(true);
        PlayerCanLeave = false;
    }

    public void SetInventoryOpen()
    {
        if (InventoryOpen)
        {
            InventoryOpen = false;
        }
        else if (!InventoryOpen)
        {
            InventoryOpen = true;
        }
    }

    private void Update()
    {
        if (!InventoryOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameManager.GamePaused == false)
                {
                    pauseMenu.SetActive(true);
                    GameManager.GamePaused = true;
                }
                else if (GameManager.GamePaused == true)
                {
                    pauseMenu.SetActive(false);
                    GameManager.GamePaused = false;
                }
            }
            if (PlayerCanLeave && Input.GetKeyDown(KeyCode.E) && !GameManager.GamePaused)
            {
                PlayerWantsToLeave();
            }
        }
    }
}
