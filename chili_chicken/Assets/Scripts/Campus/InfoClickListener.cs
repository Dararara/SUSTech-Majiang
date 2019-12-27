using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoClickListener : MonoBehaviour
{
    //负责处理属性显示方面的问题，包括响应点击和及时更新
    public Image character_image;
    public Text gpa_text, healthy_text, semester_text;
    // Start is called before the first frame update
    void Start()
    {
        character_image.sprite = Resources.Load<Sprite>("character_image/" + RoleFactory.GetRoleNameByType(Game.getRole().getType()));
        UpdateAllAttr();
        //info_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject[] panels;
    public GameObject main_panel;
    public Text role_info;
    public Text role_description;
    public void UpdateAllAttr()
    {
        SetGPA();
        SetHealthy();
        SetSemester();
    }
    public void SetGPA()
    {
        gpa_text.text = "GPA: "+ System.Math.Round(Game.getRole().getGPA(), 2).ToString();

    }
    public void SetHealthy()
    {
        healthy_text.text = "头发: " + Game.getRole().getHair().ToString();
    }
    public void SetSemester()
    {
        semester_text.text = "学期: " + Game.getRole().getSemester().ToString();
    }

    void DisActiveAll()
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }
    public void OnHelpClick()
    {
        bool active = panels[1].activeSelf;
        DisActiveAll();
        if (!active)
        {
            main_panel.SetActive(true);
            panels[1].SetActive(!active);

        }
        else
        {
            main_panel.SetActive(false);
        }
        
        
    }
    public void OnInfoClick()
    {
        bool active = panels[0].activeSelf;
        DisActiveAll();
        if (!active)
        {
            main_panel.SetActive(true);
            UpdateInfoDisplay();
            panels[0].SetActive(true);
        }
        else
        {
            main_panel.SetActive(false);
        }
        
        
    }
    public void OnShowClick()
    {
        UpdateInfoDisplay();
        main_panel.SetActive(!main_panel.activeSelf);
        role_description.text = RoleDescriptions.getRoleDescriptions().getDescription(RoleFactory.GetRoleNameByType(Game.getRole().getType()));
    }
    private void UpdateInfoDisplay()
    {
        //更新信息栏里面的个人信息
        Role role = Game.getRole();
        string info = "";

        info += role.getName() + "\n";
        info += RoleFactory.GetRoleNameByType(role.getType()) + "\n";
        info += role.getGenderString() + "\n";
        info += role.getSemester() + "\n\n";
        info += role.getComputer_c() + "\n";
        info += role.getMathmatic_c() + "\n";
        info += role.getElectronic_c() + "\n";
        info += role.getFinancial_c() + "\n\n";
        info += role.getWisdom() + "\n";
        info += role.getEQ() + "\n";
        info += role.getStrength() + "\n";
        info += role.getHair() + "\n";
        info += role.getCharm() + "\n";
        info += role.getGPA() + "\n";
        role_info.text = info;
        role_description.text = RoleDescriptions.getRoleDescriptions().getDescription(RoleFactory.GetRoleNameByType(role.getType()));
    }


}
