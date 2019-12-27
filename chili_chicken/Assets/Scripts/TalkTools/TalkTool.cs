using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkTool : MonoBehaviour
{
    // Start is called before the first frame update
    // 拿到一个Text和一段脚本，以及一个接口，展示完脚本之后，通知观察者展示结束

    private GameTalkCaller gameTalkCaller;
    public List<string> contents;
    public Text content_view;
    public bool isworking = false;
    void Start()
    {
        
    }
    

    public int current_content_id;
    // Update is called once per frame

    public float count_down;
    public string current_string;
    public int current_string_len;
    // Update is called once per frame
    void Update()
    {
        if (isworking)
        {

            if (Input.GetMouseButtonDown(1))
            {
                isworking = false;
                content_view.text = contents[contents.Count - 1];
                gameTalkCaller.TalkFinish();
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (current_content_id >= contents.Count && current_string_len == current_string.Length)
                {
                    isworking = false;
                    gameTalkCaller.TalkFinish();
                    return;
                }
                if (current_string_len < current_string.Length)
                {
                    current_string_len = current_string.Length - 1;
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
                if (current_string_len < current_string.Length)
                {
                    current_string_len += 1;
                    content_view.text = current_string.Substring(0, current_string_len);

                }
                count_down = 0.03f;
            }
        }
    }
    public string helo = "";
    public void GetWork(GameTalkCaller gameTalkCaller, List<string> contents, Text content_view)
    {

        isworking = true;
        this.gameTalkCaller = gameTalkCaller;
        this.contents = contents;
        this.content_view = content_view;
        current_string_len = 0;
        current_string = contents[0];
        current_content_id = 1;
    }

}
