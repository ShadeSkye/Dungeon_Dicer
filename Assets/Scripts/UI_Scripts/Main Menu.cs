using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void ButtonStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public virtual void GoToControls()
    {
        gameObject.SetActive(false);
    }

    public virtual void GoToMenu()
    {
        gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
