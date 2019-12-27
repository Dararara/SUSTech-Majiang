using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGPlayer : MonoBehaviour
{
    public CGLib cgLib;
    public Image back_image;
    public Image char_image;
    public Text content_text;
    public AudioSource audio_source;
    public AudioClip clip;
    public SimpleCG simpleCG;
    public List<string> contents;
    public string cgname;
    public string char_pic;
    public GameObject char_pic_panel;
    // Start is called before the first frame update
    void Start()
    {
        Initial();

        
    }
    public virtual void Initial()
    {
        //从CGLib里面获得一个CG，然后从CG里面获取对话文本，人物图片，背景音乐，背景图片
        //返回目录在跳转时设置next_scene字符串
        //CGLib.
        countDown = 0;
        cgname = PlayerPrefs.GetString("cg_id");

        cgLib = gameObject.GetComponent<CGLib>();

        simpleCG = cgLib.getCGByName(cgname);
        back_image.sprite = simpleCG.background_pic;

        char_pic_panel.SetActive(true);
        char_pic = PlayerPrefs.GetString("char_image");
        if (PlayerPrefs.GetString("hide_char_image") == "hide")
        {
            char_pic_panel.SetActive(false);
            PlayerPrefs.SetString("hide_char_image", "no");

        }
        else if (PlayerPrefs.GetString("char_image") == "")
        {
            char_image.sprite = simpleCG.char_pic;
        }
        else
        {
            char_image.sprite = Resources.Load<Sprite>(char_pic);
            PlayerPrefs.SetString("char_image", "");
        }

        audio_source.clip = simpleCG.audio;
        audio_source.Play();
        audio_source.clip = simpleCG.audio;
        contents = simpleCG.contents;

        current_string_len = 0;
        current_string = contents[0];
        current_content_id = 1;
    }


    private int current_content_id;
    // Update is called once per frame

    public float count_down;
    public string current_string;
    public int current_string_len;
    
    public virtual void Prepare()
    {

    }
    public bool AllDisplayed()
    {
        return current_content_id >= contents.Count && current_string_len == current_string.Length;
    }
    public int countDown;
    public void SetCountDown(int temp)
    {
        countDown = temp;
    }
    void Update()
    {
        //点击更新句子
        if (Input.GetMouseButtonDown(1))
        {
            current_string = contents[contents.Count - 1];
            content_text.text = current_string;
            current_string_len = current_string.Length;
            current_content_id = contents.Count;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (AllDisplayed())
            {
                if (countDown <= 0)
                {
                    Prepare();
                    SceneManager.LoadScene(PlayerPrefs.GetString("next_scene"), LoadSceneMode.Single);
                }
                else
                {
                    countDown -= 1;
                }
                return;
            }
            
            if(current_string_len < current_string.Length)
            {
                current_string_len = current_string.Length-1;
                count_down = -1;
            }
            else
            {
                current_string = contents[current_content_id];
                current_string_len = 0;
                current_content_id += 1;
            }
            
        }
        count_down -= Time.deltaTime;

        //更新一个字
        if (count_down <= 0)
        {
            if(current_string_len < current_string.Length)
            {
                current_string_len += 1;
                content_text.text = current_string.Substring(0, current_string_len);
                
            }
            count_down = 0.03f;
        }
        DoSelfStaff();

        GameController.CheckQuit();


    }
    public virtual void DoSelfStaff()
    {

    }
}
