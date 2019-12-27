using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMajiang : OpenDoor
{
    public int number1 = 2;
    public int number2 = 3;
    public int number3 = 4;
    public int word1 = 10;
    public int word2 = 20;
    public int word3 = 30;
    public int word4 = 40;
    public int word5 = 50;
    public int word6 = 60;
    public int word7 = 70;
    // Start is called before the first frame update
    void Start()
    {
        nextScene = "MaJiangScene";
        student = GameObject.Find("Student");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public void Prepare()
    {
        PlayerPrefs.SetInt("number1", number1);
        PlayerPrefs.SetInt("number2", number2);
        PlayerPrefs.SetInt("number3", number3);
        PlayerPrefs.SetInt("word1", word1);
        PlayerPrefs.SetInt("word2", word2);
        PlayerPrefs.SetInt("word3", word3);
        PlayerPrefs.SetInt("word4", word4);
        PlayerPrefs.SetInt("word5", word5);
        PlayerPrefs.SetInt("word6", word6);
        PlayerPrefs.SetInt("word7", word7);
    }
}
