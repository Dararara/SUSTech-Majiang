using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 FindForward(int mode)
    {
        if(mode == 0)
        {
            return Vector3.forward;
        }
        if(mode == 1)
        {
            return Vector3.right;
        }
        if(mode == 2)
        {
            return Vector3.back;
        }
        if(mode == 3)
        {
            return Vector3.left;
        }
        return Vector3.forward;

    }
    
}
