using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate_camera : MonoBehaviour
{
    
    private Ray ra;
    private RaycastHit hit;
    public int player_id;
    public Player player;
    public float rotateSpeed = 50;
    public  float sightCenter;
    public float count1 = 0;
    public float count2 = 0;
    public float count3 = 0;
    public float count4 = 0;
    public GameController g;
    public List<Player> players;
    public bool sight_lock = true;
    // Start is called before the first frame update
    void Start()
    {
        GetRole(0);
        idtoinfo = g.GetComponent<IdToInfo>();
    }
    void GetRole(int id)
    {
        g = GameObject.Find("GameManager").GetComponent<GameController>();
        players = g.players;
        player = players[id];
        player_id = id;
        sightCenter = 0 + 90f * id;
        transform.rotation = Quaternion.Euler(0.0f, sightCenter, 0.0f);
    }

    // Update is called once per frame
    void Rotate()
    {
        //rotate camera and light
        float horizontalInput = Input.GetAxis("Horizontal");

        count1 = transform.rotation.y;
        count2 = transform.rotation.x;
        count3 = transform.rotation.z;
        count4 = transform.rotation.w;
        float current_angle = transform.rotation.eulerAngles.y;
        float add_angle = -horizontalInput * rotateSpeed * Time.deltaTime;
        float next_angle = current_angle + add_angle;
        next_angle = Quaternion.Euler(0.0f, next_angle, 0.0f).eulerAngles.y;
        float lower_bound = Quaternion.Euler(0.0f, sightCenter - 30f, 0.0f).eulerAngles.y;
        float upper_bound = Quaternion.Euler(0.0f, sightCenter + 30f, 0.0f).eulerAngles.y;
        if (player_id != 0)
        {
            if (sight_lock)
            {
                if (next_angle > lower_bound && next_angle < upper_bound)
                {
                    transform.rotation = Quaternion.Euler(0.0f, next_angle, 0.0f);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0.0f, next_angle, 0.0f);
            }
            

        }
        if (player_id == 0)
        {
            if (sight_lock)
            {
                if (next_angle < 30.0f + SightBroader() || next_angle > 330f - SightBroader())
                {
                    transform.rotation = Quaternion.Euler(0.0f, next_angle, 0.0f);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0.0f, next_angle, 0.0f);
            }
           
        }
        
    }
    float SightBroader()
    {

        return (float)System.Math.Pow(System.Math.Max(Game.getRole().getWisdom() - 80, 0), 0.5)/1.5f;
    }
    public bool temp;
    public List<MyTile> temps;
    public IdToInfo idtoinfo;
    void UserClick()
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Light light = FindObjectOfType<Light>();
        if (Input.GetMouseButtonDown(0))
        {

            ra = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent<MyTile>(out MyTile tile))
                {
                    temps = player.my_tiles;
                    temp = player.my_tiles.Contains(tile);
                    if (temp)
                    {
                        idtoinfo.update_info(tile.tile_id);

                        for (int i = 0; i < player.my_tiles.Count; i++)
                        {
                            if (player.my_tiles[i] != tile && !player.my_tiles[i].potential_choose) player.my_tiles[i].sit_down();
                        }
                        
                        tile.show();
                    }
                }
            }
        }
    }
    void Update()
    {
        Rotate();
        UserClick();
        
    }
}
