﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGLib : MonoBehaviour
{
    public List<AudioClip> musics = new List<AudioClip>();
    public List<Sprite> background_imgs = new List<Sprite>();
    public List<Sprite> character_imgs = new List<Sprite>();
    public List<List<string>> contents = new List<List<string>>();
    private Dictionary<string, int> name_to_id = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Initialize();
    }
    private void AddCG(string name, List<string> content)
    {
        name_to_id.Add(name, name_to_id.Count);
        contents.Add(content);
    }
    public void Initialize()
    {
        AddCG("计算机系结局", new List<string> {"寒夜里灯火通明的企鹅大厦某处，你提交完了今天最后一发commit，正在伸展着早已僵硬的身体。" +
            "\n看着窗外，望着熟悉的城市，你又想起了自己的大学生活。" +
            "\n已经过去一年了啊，感觉好快呀",
            
            "大四那年，你通过实习，成功获得了转正的机会，拿到了企鹅的offer\n虽然工作很辛苦，但报酬还算令人满意。" +
            "\n你过着令外人羡慕的生活，是家人口中的精英\n但这其中经历的辛酸，却只有你一个人知道。",

            "你仍然单身一人，忙碌着，什么时候才能脱单呢？\n看着满屋的大汉，你陷入了沉思" +
            "\n计算机系结局，完"
        });

        AddCG("数学系结局", new List<string> {"一支铅笔一杯纸，一道实变变一天" +
            "\n一个黑板一粉笔，一道证明证一年" +
            "\nPhD的生活就是如此的充实而又无趣",


            "啊，又是个充实的周末呀，又是没有证明出来的一天" +
            "\n你拿着上周五刚领的那盒粉笔走出了教室，准备换一盒新的" +
            "\n教室里只留下一个被写满草稿的黑板"+
            "\n数学系结局，完"
        });
        AddCG("金融系结局", new List<string> {"把头发梳成大人模样，穿上一身帅气西装，像过去的三百六十五天一样，你来到了某证券公司的办公区。" +
            "\n一年前，你四处奔波，拼尽全力，终于找到了一份在某证券公司投资银行部工作的机会",



            "怀抱着在金融界呼风唤雨的理想而来，然后发现自己只能从最基础的杂事做起" +
            "\n也对，毕竟那些呼风唤雨的人物，相比金融行业的海量从业者来说，只是极少数而已" +
            "\n接受了这一事实的你，踏踏实实地干着最基础的事情，一直努力提升自己",



            "不过那些都不重要了，" +
            "\n“今天晚上工作结束后，一起去吃晚饭吗？”" +
            "\n微信上，那个你一直暗恋的大学同学，第一次主动邀请了你"+
            "\n金融系结局，完"

        });
        AddCG("电子系结局", new List<string> {"虽然不太情愿，但在大学毕业后，你仍然选择了菊花厂，他们给的实在是太多了。。。" +
            "\n没办法，要恰饭的嘛。。。",


            "虽然正式工作之后，没有想象中地狱般的恐怖，但狼性文化还是让你感觉身心俱疲。" +
            "\n看着弹幕里一遍遍刷着的中华有为，再回想自己过去一年的工作生活。" +
            "\n你不经苦笑，自己大概就是光鲜巨轮上的一颗螺丝钉吧",



            "这种生活，自己还能忍受多长时间呢？或者说，公司还能让我继续干多长时间呢？" +
            "\n你无法回答。" +
            "\n未来还在看不穿的迷雾中等待着你"+
            "\n电子系结局，完"
        });
        AddCG("超神结局", new List<string>{
            "什么嘛，我还蛮厉害的嘛",

            "毕业之后，你没有像大家一样找工作或是升学，你想要用自己的知识改变世界" +
            "\n你和大学时的几个伙伴一起创办了自己的公司" +
            "\n其中经历了不少辛酸，但你们都扛下来了",

            "三年来，公司一直在困境中不断前进着" +
            "\n如今，终于迎来收获的时节" +
            "\n心情前所未有的轻松愉快",

            "“喂，今天好好休息吧，明天敲钟的时候千万别像之前一样睡着了呀”" +
            "\n“知道了，知道了”" +
            "\n之前你曾因为睡眠不足好几次在公司会议上睡着。" +
            "不过，这一次，终于可以睡个好觉了",

            "真怀念呐" +
            "\n你看着对面南科大灯火通明的自习室，想起了自己曾经那段辛苦而快乐的大学生活，恍如昨日"+
            "\n超神结局，完"
        });
        AddCG("普通结局", new List<string>
        {
            "”爸，妈，我回来了“" +
            "\n“哎哟，快看看是谁回来了”" +
            "\n妈妈脸上写满了高兴，在厨房里做晚饭的爸爸也满脸笑容地欢迎你的回来",


            "”你猜猜我给你们带谁来了？“" +
            "\n”谁啊，难不成。。。“" +
            "\n”就是我之前给你们说的那个“" +
            "\n”我家单身狗终于脱单啦？来来，快请进快请进“" +
            "\n”叔叔阿姨好“",

            "大学毕业后，你没有留在深圳，你没能找到特别理想的工作，也不喜欢大城市快节奏的生活。" +
            "\n最终，你选择了回家",

            "你在老家找到了一份薪酬不错的工作，虽然和深圳比差一些，但在你所在的城市，也算的上体面" +
            "\n工作不是很忙，你每天都有不少时间干自己喜欢的事情" +
            "\n偶尔会像今天一样去父母家看看",

            "不久前，你找到了心仪的另一半，很巧，是你的高中同学。" +
            "\n你们曾经在高中有一段青涩而模糊的感情，没想到今天竟然能结出成熟的果实" +
            "\n全新的生活就在前方等着你，你想着，也许，这样平淡的生活也不错"+
            "\n普通结局，完"


        });
        AddCG("开场", new List<string>
        {
             "一座巨大的校园\n坐落在深圳大学城的黄金地段\n这就是公立南方科技大学",
            "包括数学，物理，金融，计算机\n将对各个领域充满热情的一流高中生云集于此\n并加以培养\n是被寄予无限希望的教改先锋",
            "像我这样的菜鸡\n能在这样厉害的学校待下去吗？",
            "反正我能考上这里也只是靠运气而已\n总之，先进去吧",
            "全新的校园生活即将由此展开。。。\n这本应该是充满希望的一步才对，然而。。。",
            "出现在我眼前的是一片黑暗\n这就是修仙的开始\n也是健康作息的结束",
            "在这一刻我可能还没意识到\n我之所以能进入南方科技大学\n并不是因为什么超乎常人的幸运\n只是单纯的特别能肝才对",
            "欢迎来到南方科技大学"
        });

        AddCG("毕业", new List<string>
        {
            "恭喜你完成了四年的学业，现在是毕业的时候了",
            "虽然有点舍不得，但确实是该道别的时候了\n时间永远不会等待你，它只会无情地向前\n而我们能做的，就是追赶它的步伐",
            "生命已经走过四分之一，我想是时候让你直面整个真实世界了\n带着在大学的回忆，去更广大的世界闯荡一番吧",
            "不要忘了，你们可是希望的象征啊\n人类社会不就是靠着一批又一批怀抱理想的年轻人推动着前进的吗",
            "虽然可能会犯错，可能会遇到困境\n但是千万不要失去希望，只要希望还在，即使垂垂老矣，你也还是少年",
            "希望是绝对的好的东西，它必须充满无限的诚意与幸福与梦想才行——就宛如是幻想一样的概念。\n但是，如果是拥有向前看的意志与才能的你们的话，应该是能够将之体现出来的。",
            "哦，抱歉，说了一些无关紧要的事情\n这是我承诺的毕业证，虽然简陋了些，也算是一份心意\n带着它，上路吧，如果有机会的话，在现实世界里，来这里看看吧",
            "再见"
            
        });
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string cg;
    public int id;
    public SimpleCG getCGByName(string s)
    {
        cg = s;

        id = name_to_id[s];
        return new SimpleCG(musics[id], background_imgs[id], character_imgs[id], contents[id]);
    }
}
