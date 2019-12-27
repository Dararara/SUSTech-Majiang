using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTalkNPC : MonoBehaviour, GameTalkCaller
{
    public TalkWindow talkWindow;
    public Text text;
    public Canvas canvas;
    public TalkTool talkTool;
    public List<string> sentences;
    public string char_image_path;
    // Start is called before the first frame update
    void Start()
    {
        
        talkWindow = TalkWindow.GetTalkWindow();
        text = talkWindow.content_text;
        canvas = talkWindow.canvas;
        
        talkWindow.SetCharImage(char_image_path);
        
        
        talkTool = GameObject.Find("NPCs").GetComponentInParent<TalkTool>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    StudentController student;
    public string talk_name = "X alice 2";
    public virtual void GetSentences()
    {
        sentences = TalkLib.GetTalkLib().GetTalkContent(talk_name);

    }

    public string back_image_path = "oh";
    public void Talk(StudentController student)
    {
        GetSentences();
        talkWindow.HideButtons();
        talkWindow.SetCharImage(char_image_path);
        talkWindow.SetBackImage(back_image_path);
        canvas.enabled = true;
        this.student = student;
        student.LockMove();
        talkTool.GetWork(this, sentences, text);
    }
    public virtual void TalkOver()
    {
        this.student.UnlockMove();
        canvas.enabled = false;
    }
    public virtual void TalkFinish()
    {
        TalkOver();
    }
}
