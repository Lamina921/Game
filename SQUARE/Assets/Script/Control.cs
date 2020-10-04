using UnityEngine;
using System;
public class Control : MonoBehaviour
{
    const string strStrive = "Strive";
    const string strMe_up = "Me_up";
    const string strMe_down = "Me_down";
    const string strLover_up = "Lover_up";
    const string strLover_down = "Lover_down";
    const string strMenu = "Menu";
    public static bool Me_up;
    public static bool Me_down;
    public static bool Lover_up;
    public static bool Lover_down;
    public static bool isPause=false;
    public static  Action Strive;
    public static MenuControl game_over;
    public static MenuControl menu;
    private void Start()
    {
        menu = transform.GetChild(0).GetComponent<MenuControl>();
        game_over = transform.GetChild(1).GetComponent<MenuControl>();
    }
    void Update()
    {
        if (!isPause)
        {
            if (Input.GetButtonDown(strStrive)) Strive();
            Me_up = Input.GetButton(strMe_up);
            Me_down = Input.GetButton(strMe_down);
            Lover_up = Input.GetButton(strLover_up);
            Lover_down = Input.GetButton(strLover_down);
        }
        if (Input.GetButtonDown(strMenu)) Pause();
    }
    private static void Pause()
    {
        if (isPause)
        {
            menu.Appear(false);
            isPause = false;
            Time.timeScale = 1;
        }
        else
        {
            menu.Appear(true);
            isPause = true;
            Time.timeScale = 0;
        }
        
    }
}
