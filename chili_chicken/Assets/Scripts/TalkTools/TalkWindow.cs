using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkWindow : MonoBehaviour
{
    public Button[] buttons = new Button[4];
    public Canvas canvas;
    public Image talker_image;
    public Text content_text;
    public Image back_image;
    public GameObject talker_image_panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static TalkWindow GetTalkWindow()
    {
        return GameObject.Find("TalkCanvas").GetComponent<TalkWindow>();
    }
    public void HideButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void SetCharImage(string path)
    {

        if(path == "")
        {
            talker_image_panel.SetActive(false);
        }
        else
        {
            talker_image.sprite = Resources.Load<Sprite>(path);
            talker_image_panel.SetActive(true);
        }
        
        
    }
    public void SetBackImage(string path)
    {
        try
        {
            back_image.sprite = Resources.Load<Sprite>(path);
        }
        catch
        {
            back_image.sprite = null;
        }
        
    }
    private Choose_caller chooseCaller;
    public List<string> temp;
    public void ShowButtons(List<string> button_text, Choose_caller talkNPCWithChoose)
    {
        temp = button_text;
        chooseCaller = talkNPCWithChoose;
        for(int i = 0; i < button_text.Count; i++)
        {
            buttons[i].gameObject.SetActive(true);
            Text t = buttons[i].GetComponentInChildren<Text>();
            t.text = button_text[i];
        }
    }
    
    public void OnClick0()
    {
        chooseCaller.ButtonOnClick(0);
    }
    public void OnClick1()
    {
        chooseCaller.ButtonOnClick(1);
    }
    public void OnClick2()
    {
        chooseCaller.ButtonOnClick(2);
    }
    public void OnClick3()
    {
        chooseCaller.ButtonOnClick(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
