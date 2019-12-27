using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_shower : MonoBehaviour
{
    public Text info_text;
    private RoleDescriptions roleDescription;
    public Scrollbar scrollbar;
    public Image[] images = new Image[6];
    // Start is called before the first frame update
    
    private void Update_sprite()
    {
        for(int i = 0; i < 6; i++)
        {
            string path = "character_image/" + RoleFactory.GetRoleNameByType(i + 1);
            images[i].sprite = Resources.Load<Sprite>(path);
        }
        
    }
    void Start()
    {
        roleDescription = RoleDescriptions.getRoleDescriptions();
        Update_sprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string kunkun = "";
    private void ClickRoleType(int id)
    {
        new_login.Type = id;
        string type_name = RoleFactory.GetRoleNameByType(id);

        info_text.text = "<color=blue><size=24>" + type_name + "</size></color>\n" + roleDescription.getDescription(type_name);
    }
    public void onClick1()
    {
        ClickRoleType(1);
    }
    public void onClick2()
    {
        ClickRoleType(2);
    }
    public void onClick3()
    {
        ClickRoleType(3);
    }
    public void onClick4()
    {
        ClickRoleType(4);
    }
    public void onClick5()
    {
        ClickRoleType(5);
    }
    public void onClick6()
    {
        ClickRoleType(6);

    }
}
