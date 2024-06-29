using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void LoadLastSave()
    {
        SceneManager.LoadScene("MainGameScene");
        GameManager.Instance.Load();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
