using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkNPCWithChoose : SimpleTalkNPC, Choose_caller
{
    // Start is called before the first frame update
    public List<List<string>> choose1 = new List<List<string>>()
    {
        {new List<string>{"我呀，负责在这里引导学生们啊\n无论是新生还是老生，只要有问题，都可以问我哟", "我非常期待你们的未来\n因为，你们才是真正的希望的象征啊" }},
        {new List<string>{"?这是个好问题\n我也考虑过复现真实的生活\n但那样你肯定玩不下去的，所以我就稍微魔改了一下" , "每局游戏里面你打出的那些课程牌，虽然玩起来很轻松，但实际上，你操纵的角色很可能是肝了好几个通宵才搞定的呢",
            "不然，也不会在胜利的时候掉头发了", "总之，这就是个我魔改过的游戏啦,不要太当真\n就像水一样。。。\n啊，当我什么都没说", "好啦好啦，那些水呀，实际上是我做的一层幻觉啦\n你要是想过普通的校园生活，就不应该故意进到湖里边去\n如果你非要这么做，我也拦不住你，出于安全考虑，我就只做了一层幻觉\n表面上看着是水，实际上是陆地呀，很安全吧"}},

        {new List<string>{"简而言之，就是去不同的教学区参加学习\n到处逛逛校园，多和同学们聊聊天，虽然他们很多人只是复读机", "等你学完了八个学期，也就是完成了八局游戏之后，你就可以顺利毕业了\n到时候，会由我来给你颁发毕业证",
            "当然啦，毕业证是我亲手做的，也不知道别人认不认\n不过，作为你通关的奖励来说，还是足够的\n",
            "顺带一提，我还根据你的表现准备了好几个结局\n像你这样优秀的人，应该能够拿到最棒的结局吧",
            "如果你想拿到真正的毕业证...emmm\n大概等你把八个学期里面打的牌对应的课程都学完了，就会有了吧\n我也不太清楚，毕竟我也没拿过"
        } }
    };

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<string> chooses = new List<string>() { "蔡虚坤", "团长"};
    
    public override void TalkFinish()
    {
        talkWindow.ShowButtons(chooses, this);
    }
    public virtual void ButtonOnClick(int button_id)
    {
        
        talkWindow.HideButtons();
        if(button_id < choose1.Count)
        {
            talkTool.GetWork(this, choose1[button_id], text);
        }
        else
        {
            TalkOver();
        }
                
    }
    
}
public interface Choose_caller
{
    void ButtonOnClick(int button_id);
}