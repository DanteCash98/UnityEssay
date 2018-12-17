using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        GameManager.Instance.TogglePauseMenu();
    }

    public void Save()
    {
        GameManager.Instance.Save();
    }

    public void QuitGame()
    {
        GameManager.Instance.Save();
        Application.Quit();
    }
}
