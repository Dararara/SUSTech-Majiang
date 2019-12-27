using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public abstract class OpenDoor : MonoBehaviour
{
    public float[] position = new float[3];
    public GameObject student;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        student = GameObject.Find("Student");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        SavePosition();
        Prepare();
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        



        //SceneManager.LoadScene("MaJiangScene", LoadSceneMode.Single);
    }
    private void SavePosition()
    {
        PlayerPrefs.SetFloat("position_x", position[0]);
        PlayerPrefs.SetFloat("position_y", position[1]);
        PlayerPrefs.SetFloat("position_z", position[2]);
    }

    public virtual void Prepare()
    {

    }

}
