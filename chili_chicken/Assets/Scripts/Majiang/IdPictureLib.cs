using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdPictureLib : MonoBehaviour
{
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Material Id_to_material(int id)
    {
        try
        {
            return materials[id];
        }
        catch
        {
            return null;
        }
            
    }

}
