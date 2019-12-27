using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusNPC : SimpleTalkNPC
{
    // Start is called before the first frame update

   
    // Update is called once per frame
    void Update()
    {
        
    }
    public int computer, math, fin, ee, IQ, EQ, strength, hair, charm, semester;
    public float bonus_gpa = 0;
    public override void GetSentences()
    {
        if (PlayerPrefs.GetString(talk_name) == talk_down)
        {
            string meta_talk_name = talk_name;
            talk_name += "_after";
            base.GetSentences();
            talk_name = meta_talk_name;
        }
        else
        {
            base.GetSentences();
        }
        
    }
    string talk_down = "talk_done";
    public override void TalkFinish()
    {
        if(PlayerPrefs.GetString(talk_name) != talk_down)
        {
            PlayerPrefs.SetString(talk_name, talk_down);
            Role role = Game.getRole();
            role.addComputer_c(computer);
            role.addMathmatic_c(math);
            role.addFinancial_c(fin);
            role.addElectronic_c(ee);
            role.addWisdom(IQ);
            role.addEQ(EQ);
            role.addStrength(strength);
            role.addHair(hair);
            role.addCharm(charm);
            role.addGPA(bonus_gpa);
            for(int i = 0; i < semester; i++)
            {
                role.addSemester();
            }
            
        }
        InfoClickListener info_shower = GameObject.Find("infoCanvas").GetComponent<InfoClickListener>();
        info_shower.UpdateAllAttr();
        
        base.TalkFinish();

    }
}
