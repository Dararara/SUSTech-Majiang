using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessboard : MonoBehaviour
{
    public Material chessboard_outlook;
    // Start is called before the first frame update
    void Start()
    {
        
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = chessboard_outlook;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
