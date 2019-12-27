using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajiangNPC : TalkNPCWithChoose
{
    // Start is called before the first frame update
    public string next_scene = "MajiangScene";

    public bool satisfy = false;
    public override void ButtonOnClick(int button_id)
    {
        if(satisfy == false)
        {
            TalkOver();
        }
        if(button_id == 1)
        {
            gameObject.GetComponent<StartMajiang>().Open();
        }
        else
        {
            TalkOver();
        }
    }
    public static List<string> not_satisfy = new List<string>
    {
        "emmm，看上去你还没有满足来这里上课的条件呢\n" +
        "专业核心课相比专业基础课而言，会需要更多的相关专业的知识，所以需要你有一定的基础\n",
        "要求不算太高，只要你通过学习专业先修课将自己对应专业的能力提升到60分，就可以来上专业核心课了\n" +
        "我能理解你的心情，但是处于教学质量的考虑，我不得不拒绝你，请满足要求以后再来吧",

    };
    public override void TalkFinish()
    {
        if (CheckSatisfy(gameObject.GetComponent<StartMajiang>().number1)&&
            CheckSatisfy(gameObject.GetComponent<StartMajiang>().number2) &&
            CheckSatisfy(gameObject.GetComponent<StartMajiang>().number3) 
            )
        {
            satisfy = true;
            base.TalkFinish();
        }
        else if(chooses.Count == 1)
        {
            talkWindow.ShowButtons(chooses, this);
            chooses = new List<string> { "让我想想", "现在就开始吧" };
        }
        else
        {
            chooses = new List<string> { "好的，我先去其他地方看看" };
            talkTool.GetWork(this, not_satisfy, text);
        }

        
    }

    private bool CheckSatisfy(int number)
    {
        switch (number)
        {
            case 3:
                if(Game.getRole().getComputer_c() < 60){
                    return false;
                }
                break;
            case 5:
                if (Game.getRole().getFinancial_c() < 60)
                {
                    return false;
                }
                break;
            case 7:
                if (Game.getRole().getMathmatic_c() < 60)
                {
                    return false;
                }
                break;
            case 9:
                if (Game.getRole().getElectronic_c() < 60)
                {
                    return false;
                }
                break;
        }

        return true;
    }
    
}
