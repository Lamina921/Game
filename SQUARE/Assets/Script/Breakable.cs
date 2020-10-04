using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breakable : MonoBehaviour
{
    float power=0;
    Animation ani;
    public GameObject canvas;
    public Image power_bar;
    private void Start()
    {
        ani = GetComponent<Animation>();
    }
    private void Update()
    {
        if (power>0)
        {
            if(canvas != null)
                power_bar.fillAmount = power;
            if (power > 1f)
            {
                ani.Play("Break");
                Control.Strive -= this.Breaking;
                if (Control.Strive == null)
                    Control.Strive = Gamemanager.now_action;
            }

            power -= 0.005f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Control.Strive == Gamemanager.now_action)
            Control.Strive = null;
        Control.Strive += this.Breaking;
        if(canvas!=null)
            canvas.SetActive(true);
    }
    public void Breaking()
    {
        power += 0.1f;
    }
    public void Destroy_parent()
    {
        Destroy(transform.parent.gameObject);
    }
}
