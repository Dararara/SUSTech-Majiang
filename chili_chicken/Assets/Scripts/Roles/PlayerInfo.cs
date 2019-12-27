using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo {

    public List<InfoItem> inforList = new List<InfoItem>();
   
}
[System.Serializable]
public class InfoItem
{
    public int id;
    public string Name;
    public int Type;
    public bool isMale;
    //学期数
    public int Semester;
    //角色属性:专业能力
    public int Computer_c;
    public int Mathmatic_c;
    public int Electronic_c;
    public int Financial_c;
    //角色属性：个人素养
    public int Wisdom;
    public int EQ;
    public int Strength;
    public int Hair;
    public int Charm;
    public float GPA;
    public Dictionary<string, string> otherstates = new Dictionary<string, string>();
    public InfoItem()
    {
    }
    public InfoItem(Role role)
    {
        this.Type = role.getType();
        this.isMale = role.getGender();
        this.Name = role.getName();
        this.Semester = role.getSemester();
        //角色属性:专业能力
        this.Computer_c = role.getComputer_c();
        this.Mathmatic_c = role.getMathmatic_c();
        this.Electronic_c = role.getElectronic_c();
        this.Financial_c = role.getFinancial_c();
        //角色属性：个人素养
        this.Wisdom = role.getWisdom();
        this.EQ = role.getEQ();
        this.Strength = role.getStrength();
        this.Hair = role.getHair();
        this.Charm = role.getCharm();
        this.GPA = role.getGPA();

    }
}
