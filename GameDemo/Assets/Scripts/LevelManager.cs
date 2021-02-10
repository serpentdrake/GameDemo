using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnarea;
    public GameObject menu;

    private bool isShowing;

    private void Awake()
    {
        instance = this;
    }

   public void Retry()
    {
        isShowing = !isShowing;
        menu.SetActive(isShowing);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
