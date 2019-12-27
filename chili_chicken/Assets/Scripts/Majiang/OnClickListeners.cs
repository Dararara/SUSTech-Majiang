using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickListeners : MonoBehaviour
{
    public GameObject info_panel;
    public GameObject help_panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInfoClick()
    {
        info_panel.SetActive(!info_panel.activeSelf);
    }
    public void OnHelpClick()
    {
        help_panel.SetActive(!help_panel.activeSelf);
    }

}
