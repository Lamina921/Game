using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public  CanvasGroup menu;
    private void Start()
    {
        menu=GetComponent<CanvasGroup>();
    }
    public  void Appear(bool turnOn)
    {
        if (turnOn)
        {
            menu.alpha = 1;
            menu.interactable = true;
        }
        else
        {
            menu.alpha = 0;
            menu.interactable = false;
        }
    }
    public  void Reload_The_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Appear(false);
    }
    public  void Exit()
    {
        SceneManager.LoadScene("Title");
        Appear(false);
    }
}
