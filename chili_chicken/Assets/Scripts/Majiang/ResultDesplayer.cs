using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultDesplayer : MonoBehaviour
{
    public GameObject resultPanel;
    public Text result_text;
    public Text help_text;
    // Start is called before the first frame update
    private string help_string = "左键选择课程牌，查看课程牌详情" +
        "\n右键确定，出牌" +
        "\n键盘左右键可以水平移动视角" +
        "\n按C可以切换俯视角" +
        "\n发光的牌为推荐出牌，可以打出以获得更大收益" +
        "\n只要修完五门课，也就是拿到五个三元组或四元组，就可以放假了哟";
    void Start()
    {
        help_text.text = help_string;
        HideResult();
        gameover = false;
    }

    // Update is called once per frame

    bool is_showing = false;
    bool gameover = false;
    void Update()
    {
        if (gameover && Input.GetKeyDown(KeyCode.S))
        {
            if (is_showing)
            {
                HideResult();
            }
            else
            {
                ShowResult();
            }
        }
        
    }



    public Text result_description;
    public void FillAndShow(List<int> player_tiles, List<int> player_outtiles, bool player_win)
    {
        for(int i = 0; i < player_tiles.Count; i++)
        {
            //Debug.Log(player_tiles[i]);
        }

        gameover = true;
        
        Role role = Game.getRole();
        int semester = role.getSemester();
        int[] meta_data = {role.getComputer_c(), role.getMathmatic_c(), role.getElectronic_c(), role.getFinancial_c(), role.getWisdom(),
            role.getEQ(), role.getStrength(), role.getHair(), role.getCharm() };

        int[] data = Game.getScores(player_tiles, player_outtiles, player_win);
        //int[] data = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        float gpa = (float)System.Math.Round(Game.getGPA(), 2);
        string gpa_s = "";
        if (gpa >= 3.0)
        {
            gpa_s = green + gpa + postfix;
        }else if(gpa >= 2.0)
        {
            gpa_s += gpa;
        }
        else
        {
            gpa_s = red + gpa + postfix;
        }



        result_text.text = semester.ToString() + "\n" + DataToString(meta_data, data) + gpa_s;

        //result_description.text = Game.getResults();
        ShowResult();
        help_text.text = help_text.text + "\n按s键打开关闭结算界面";
    }
    public void OverSemester()
    {
        if(Game.getRole().getSemester() > 8)
        {
            PlayerPrefs.SetString("cg_id", "毕业");
            PlayerPrefs.SetString("next_scene", "EndScene");
            SceneManager.LoadScene("CGScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("BeginScene", LoadSceneMode.Single);
        }
        
    }

    public void ShowResult()
    {
        is_showing = true;
        resultPanel.SetActive(true);
    }
    public void HideResult()
    {
        is_showing = false;
        resultPanel.SetActive(false);
    }

    
    public string DataToString(int[] meta_data, int[] data)
    {
        string result = "";
        for(int i = 1; i < 5; i++)
        {
            result += meta_data[i-1] + WrapData(data[i]) + "\n";
        }
        result += "\n";
        for(int i = 5; i < 10; i++)
        {
            result += meta_data[i - 1] + WrapData(data[i]) + "\n";
        }

        return result;
    }

    private readonly string red = "<color=#FF0000>";
    private readonly string green = "<color=#33FF00>";
    private readonly string yellow = "<color=#FFFF33>";
    private readonly string postfix = "</color>";
    public string WrapData(int data)
    {
        string result = "";
        if(data >= 0)
        {
            result = green + "+" + data.ToString() + postfix; 
        }
        else
        {
            result = red + data.ToString() + postfix;
        }
        return result;
    }
    public string WrapData(float data)
    {
        string result = "";
        if (data >= 0)
        {
            result = green + "+" + data.ToString() + postfix;
        }
        else
        {
            result = red + data.ToString() + postfix;
        }
        return result;
    }

}
