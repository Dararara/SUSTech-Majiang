using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTile : MonoBehaviour
{
    public bool is_showing = false;
    public int tile_id;
    public Material front_picture;
    private bool done = false;
    public bool potential_choose;
    public ParticleTime particleTime;
   
    // Start is called before the first frame update
    void Start()
    {
        potential_choose = false;
    }
    public void sit_down()
    {
        if (is_showing)
        {
            show();
            
        }
    }
    public void Initialize(int id)
    {
        tile_id = id;
        IdPictureLib id2p = FindObjectOfType<IdPictureLib>();
        front_picture = id2p.Id_to_material(tile_id);
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material = front_picture;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            Vector3 temp = new Vector3(0, TileGenerator.base_height, -7);
            if (Vector3.Distance(temp, transform.position) >= 1)
            {
                transform.position += (temp - transform.position) / 5;
            }
            else if (Vector3.Distance(temp, transform.position) < 1)
            {
                transform.position = temp;
                Camera g = FindObjectOfType<Camera>();
                transform.LookAt(g.transform);
            }
            else if(Vector3.Distance(temp, transform.position) < 3 && done)
            {
            }
                          
        }
    }
    public void setDone()
    {
        done = true;
    }
    public void show()
    {
        if (is_showing)
        {
            gameObject.transform.position = gameObject.transform.position + Vector3.down;
            is_showing = false;
        }
        else
        {
            gameObject.transform.position = gameObject.transform.position + Vector3.up;
            is_showing = true;
        }
        
    }
    IEnumerator SetBool(bool b)
    {
        //理论上是用来解决某些bug的，但是暂时弃用
        yield return new WaitForSeconds(0.05f);
        is_showing = b;
    }

    private bool go = false;
    public void Go_out()
    {
        if (potential_choose)
        {
            ResetPotential();
        }
        go = true;
    }
    public void Suiside()
    {
        ResetPotential();
        Destroy(gameObject);
    }
    public void SetPotential()
    {
        if(potential_choose == false)
        {
            potential_choose = true;
            GameObject g = Resources.Load("Prefabs/Tile Light") as GameObject;
            particleTime = Instantiate(g).GetComponent<ParticleTime>();
            particleTime.transform.position = transform.position;
        }
        

    }
    public void ResetPotential()
    {
        if(potential_choose == true)
        {
            potential_choose = false;
            if (particleTime != null)
            {
                particleTime.Suicide();
            }
        }
        
        
    }
}
