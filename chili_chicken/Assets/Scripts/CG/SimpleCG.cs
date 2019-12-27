using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCG
{
    public AudioClip audio;
    public Sprite background_pic;
    public Sprite char_pic;
    public List<string> contents;
    public SimpleCG(AudioClip a, Sprite b_pic, Sprite c_pic, List<string> strings)
    {
        audio = a;
        background_pic = b_pic;
        char_pic = c_pic;
        contents = strings;
    }
    


}
