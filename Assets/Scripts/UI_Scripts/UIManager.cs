using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject exitMenu;
    [SerializeField] GameObject gameWin;
    [SerializeField] GameObject gameLose;
    [SerializeField] GameObject combatScreen;
    [SerializeField] GameObject inventoryButton;
    [SerializeField] Text PlayerHealth;
    [SerializeField] Text EnemyHealth;
    [SerializeField] Text winScreenScore;
    [SerializeField] Text gameOverScreenScore;

    public static UIManager Instance;

    public static bool PlayerCanLeave = false;
    public bool InventoryOpen = false;
    private bool buttonActive = true;

    private void Awake()
    {
        Instance = this;
    }

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
        PlayerController.Instance.Score += 500;
        winScreenScore.text = $"Final score: {PlayerController.Instance.Score}";
        gameWin.SetActive(true);
        PlayerCanLeave = false;
    }

    public void ShowGameOver()
    {
        gameOverScreenScore.text = $"Final score: {PlayerController.Instance.Score}";
        gameLose.SetActive(true);
        GameManager.GamePaused = true;
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

    public void HideCombatScreen()
    {
        if (PlayerController.Instance.InCombat)
        {
            combatScreen.SetActive(false);
        }
    }

    public void ShowCombatScreen()
    {
        if (PlayerController.Instance.InCombat)
        {
            combatScreen.SetActive(true);
        }
    }

    public void ToggleInventoryButton()
    {
        if (buttonActive)
        {
            inventoryButton.SetActive(false);
            buttonActive = false;
        }
        else if (!buttonActive)
        {
            inventoryButton.SetActive(true);
            buttonActive = true;
        }
    }

    public void UpdatePlayerHP(string value)
    {
        PlayerHealth.text = value;
    }

    public void UpdateEnemyHP(string value)
    {
        EnemyHealth.text = value;
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
                    HideCombatScreen();

                    if (!PlayerController.Instance.InCombat)
                    {
                        ToggleInventoryButton();
                    }

                    GameManager.GamePaused = true;
                }
                else if (GameManager.GamePaused == true)
                {
                    pauseMenu.SetActive(false);
                    ShowCombatScreen();

                    if (!PlayerController.Instance.InCombat)
                    {
                        ToggleInventoryButton();
                    }

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
