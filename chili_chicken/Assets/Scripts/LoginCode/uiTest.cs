using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiTest : MonoBehaviour
{
	/// <summary>
	/// 获取UI Text控件的文本
	/// </summary>
	public Text txt; 
	/// <summary>
	/// My toggle.
	/// </summary>
	public Toggle myToggle;

	public InputField myInput;

	void Start () 
	{
		Debug.Log (txt.text); //输出Text的文本
		myInput.inputType = InputField.InputType.Password;
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log (myInput.text);
			if(myToggle.isOn)
			{
				myToggle.isOn = false;
			}
			else
			{
				myToggle.isOn = true;	
			}
		}

		
	}

}
