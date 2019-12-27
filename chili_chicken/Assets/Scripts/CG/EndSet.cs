using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSet : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetString("cg_id", Game.GetEndName());
        PlayerPrefs.SetString("next_scene", "Login");

        PlayerPrefs.SetString("hide_char_image", "hide");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
