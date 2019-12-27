using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using static JsonTools;

public class new_login: MonoBehaviour{

    //Toggle
    public static Role role = new Lolita();
	public Toggle male;
	public Toggle female;

	//inputfield
	public new InputField name;
    
	
	//intro
	public string intro; 

	//gender
	public static bool isMale;
	//name
	public static string Name;
	//type
	public static int Type = 0;

	//data for write json file
	static class data{
		public static string Name;
    	public static bool isMale;
    	public static int Type;

		//get, set method to be added
	}
    public Button btn_login;
	void Start(){

        PlayerPrefs.SetString("湖底之伞", "");
        PlayerPrefs.SetString("HuiYuanYHH", "");
        PlayerPrefs.SetString("YiJiaoYHH", "");
        PlayerPrefs.SetString("YiHaoMenYHH", "");
        PlayerPrefs.SetString("XinYuanYHH", "");
        PlayerPrefs.SetString("JiaoshiGongyuYHH", "");
        PlayerPrefs.SetString("HupanYHH", "");
        PlayerPrefs.SetString("ErQiYHH", "");


    }

	void onClick(){
		bool[] ok = {false, false, false};
		if(string.Equals(name.text, null)){
			//Debug.Log("请输入姓名！");
		}else{
			Name = name.text;
			ok[1] = true;
			//Debug.Log("name = " + Name);
		}

		if(male.isOn){
			isMale = true;
			ok[0] = true;
			// Debug.Log("male");
		}else if(female.isOn){
			isMale = false;
			ok[0] = true;
			// Debug.Log("female");
		}else{
			//Debug.Log("请选择性别！");
		}

		if(Type < 1 || Type > 6){
			//Debug.Log("请选择角色！");
		}else{
			ok[2] = true;
			//Debug.Log("type = " + Type);
		}

		if(ok[0] && ok[1] && ok[2]){
			//login_info(Name, isMale, Type);		// method from sjp's script
			Role role;

            Game.createRole(Name, isMale, Type);
            /*Debug.Log("charm = " + role.getCharm());
			Debug.Log("cs_c = " + role.getComputer_c());
			Debug.Log("math_c = " + role.getMathmatic_c());
			Debug.Log("fin_c = " + role.getFinancial_c());
			Debug.Log("ee_c = " + role.getElectronic_c());
			Debug.Log("EQ = " + role.getEQ());
			Debug.Log("ismale = " + role.getGender());
			Debug.Log("gpa = " + role.getGPA());
			Debug.Log("hair = " + role.getHair());
			Debug.Log("name = " + role.getName());
			Debug.Log("sem = " + role.getSemester());
			Debug.Log("strength = " + role.getStrength());
			Debug.Log("type = " + role.getType());
			Debug.Log("wisdom = " + role.getWisdom());*/
            // jump to another scene, a string to be changed


            PlayerPrefs.SetFloat("position_x", 455f);
            PlayerPrefs.SetFloat("position_y", 15f);
            PlayerPrefs.SetFloat("position_z", -30);
            PlayerPrefs.SetFloat("euler_x", 0);
            PlayerPrefs.SetFloat("euler_y", 0);
            PlayerPrefs.SetFloat("euler_z", 0);
            PlayerPrefs.SetString("cg_id", "开场");
            PlayerPrefs.SetString("next_scene", "BeginScene");
            PlayerPrefs.SetString("char_image", "character_image/" + RoleFactory.GetRoleNameByType(Type));


            SetInitialTransform();
			SceneManager.LoadScene("CGScene");
		}
	}

    void SetInitialTransform()
    {
        PlayerPrefs.SetFloat("position_x", 460);
        PlayerPrefs.SetFloat("position_y", 15);
        PlayerPrefs.SetFloat("position_z", -30);
        PlayerPrefs.SetFloat("euler_x", 0);
        PlayerPrefs.SetFloat("euler_y", 0);
        PlayerPrefs.SetFloat("euler_z", 0);
    }

	void Update(){
        GameController.CheckQuit();

	}

	
}