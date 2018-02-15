using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static bool hud = true;
    public GameObject hudPanel;

    public Text coinText;
    public int num;

    void Start()
    {
        num = -1;
        SetCountText();
    }

   public void SetCountText()
    {
        num++;
        coinText.text = " " + num.ToString();

        if(GameOverMenu.isOver == true)
        {
            num = 0;
        }
    }
    
}
