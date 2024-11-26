using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        GameManager.GamePaused = false;
    }

    public void PlayerWantsToLeave()
    {
        Debug.Log("Player interacted with ladder");
        gameObject.SetActive(true);
    }
}
