using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCGPlayer : CGPlayer
{
    public GameObject end_panel;
    public GameObject text;
    void Start()
    {
        Initial();
        SetCountDown(1);
    }
    public override void DoSelfStaff()
    {
        
        if (AllDisplayed())
        {

            end_panel.SetActive(true);
            text.transform.position += Vector3.up;
        }
    }
    //CGPlayer的扩展，可以在所有文字展示结束之后升起结束字母

}
