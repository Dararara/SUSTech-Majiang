using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public MyTile tile;
    public List<MyTile> tiles_1;
    public List<MyTile> tiles_2;
    public List<MyTile> tiles_3;
    public List<MyTile> tiles_4;
    public float tile_x;
    public float tile_z;
    public float tile_y;
    public float chessboard_z;
    public float chessboard_x;
    public float chessboard_y;
    public static float base_height;
    public static float show_base_height;
    // Start is called before the first frame update
    public GameObject chessboard;
    void Start()
    {



    }
    public void Initialize()
    {
        chessboard = GameObject.Find("Chessboard");
        tile = Resources.Load<MyTile>("Pretabs/Tile");
        //float tile_x = tiles[0].transform.lossyScale.x;
        //float tile_z = tiles[0].transform.lossyScale.z;
        //float tile_y = tiles[0].transform.lossyScale.y;
        tiles_1 = new List<MyTile>();
        tiles_2 = new List<MyTile>();
        tiles_3 = new List<MyTile>();
        tiles_4 = new List<MyTile>();
        tile_x = 1.0f;
        tile_z = 0.5f;
        tile_y = 1.6f;
        chessboard_z = chessboard.transform.lossyScale.z;
        chessboard_x = chessboard.transform.lossyScale.x;
        chessboard_y = chessboard.transform.lossyScale.y;
        base_height = chessboard.transform.position.y + tile_y / 2 + chessboard_y / 2;
        show_base_height = chessboard.transform.position.y + tile_z / 2 + chessboard_y / 2;
    }

    public void Generate3(Player p)
    {
        p.SortTiles();
        List<MyTile> tiles = p.my_tiles;
        List<MyTile> show_tiles = p.show_tiles;
        for (int i = 0; i < tiles.Count; i++)
        {
            MyTile temp = tiles[i];
            temp.transform.position = new Vector3(-tile_x * ((tiles.Count - 1) / 2.0f - (float)(i)),
                base_height,
                chessboard_z / 2 - tile_z*2);
            
            
            temp.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            if (temp.is_showing)
            {
                temp.is_showing = false;
                temp.ResetPotential();
                temp.show();
            }
            //temp.transform.LookAt(temp.transform.position + Vector3.up * 10);
        }
        for (int i = 0; i < show_tiles.Count; i++)
        {
            MyTile temp = show_tiles[i];
            temp.transform.position = new Vector3(-tile_x * ((show_tiles.Count - 1) / 2.0f - (float)(i)),
                show_base_height,
                chessboard_z / 2 - tile_z * 2 - tile_y);
            
            temp.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        }
    }
    public void Generate1(Player p)
    {
        p.SortTiles();
        List<MyTile> tiles = p.my_tiles;
        List<MyTile> show_tiles = p.show_tiles;
        for (int i = 0; i < tiles.Count; i++)
        {
            MyTile temp = tiles[i];
            temp.transform.position = new Vector3(-tile_x * ((tiles.Count - 1) / 2.0f - (float)(i)),
                base_height,
                -(chessboard_z / 2 - tile_z * 2));
            temp.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            if (temp.is_showing)
            {
                temp.is_showing = false;
                temp.ResetPotential();
                temp.show();
            }
        }
        for(int i = 0; i < show_tiles.Count; i++)
        {
            MyTile temp = show_tiles[i];
            temp.transform.position = new Vector3(-tile_x * ((show_tiles.Count - 1) / 2.0f - (float)(i)),
                show_base_height,
                -(chessboard_z / 2 - tile_z * 2 - tile_y));
            temp.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, -180.0f);
        }
    }
    public void Generate2(Player p)
    {
        p.SortTiles();
        List<MyTile> tiles = p.my_tiles;
        List<MyTile> show_tiles = p.show_tiles;
        for (int i = 0; i < tiles.Count; i++)
        {
            MyTile temp = tiles[i];
            temp.transform.position = new Vector3(-(chessboard_x / 2 - tile_x*2),
                base_height,
                -tile_x * ((tiles.Count - 1) / 2.0f - (float)(i)));
            temp.transform.rotation = Quaternion.Euler(-180.0f, 90.0f, 180.0f);
            if (temp.is_showing)
            {
                temp.is_showing = false;
                temp.ResetPotential();
                temp.show();
            }
        }
        for (int i = 0; i < show_tiles.Count; i++)
        {
            MyTile temp = show_tiles[i];
            temp.transform.position = new Vector3(-(chessboard_x / 2 - tile_x * 2 - tile_y),
                show_base_height,
                -tile_x * ((show_tiles.Count - 1) / 2.0f - (float)(i)));
            temp.transform.rotation = Quaternion.Euler(-90.0f, 90.0f, 180.0f);
        }
    }
    public void Generate4(Player p)
    {
        p.SortTiles();
        List<MyTile> tiles = p.my_tiles;
        List<MyTile> show_tiles = p.show_tiles;
        for (int i = 0; i < tiles.Count; i++)
        {
            MyTile temp = tiles[i];
            temp.transform.position = new Vector3(chessboard_x / 2 - tile_x*2,
                base_height,
                tile_x * ((tiles.Count - 1) / 2.0f - (float)(i)));
            temp.transform.rotation = Quaternion.Euler(-180.0f, -90.0f, 180.0f);
            if (temp.is_showing)
            {
                temp.is_showing = false;
                temp.ResetPotential();
                temp.show();
                
            }
        }
        for (int i = 0; i < show_tiles.Count; i++)
        {
            MyTile temp = show_tiles[i];
            temp.transform.position = new Vector3(chessboard_x / 2 - tile_x * 2 - tile_y,
                show_base_height,
                tile_x * ((show_tiles.Count - 1) / 2.0f - (float)(i)));
            temp.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 90.0f);
        }
    }
    
    public void Generate()
    {
        
        for (int i = 0; i < tiles_1.Count; i++)
        {
            MyTile temp;
            temp = Instantiate(tiles_1[i], new Vector3(-tile_x * ((tiles_1.Count - 1) / 2.0f - (float)(i)),
                base_height,
                chessboard_z / 2 - tile_z),
                new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            temp.Initialize(20);

        }
        
        for (int i = 0; i < tiles_2.Count; i++)
        {
            Instantiate(tiles_2[i], new Vector3(-tile_x * ((tiles_2.Count - 1) / 2.0f - (float)(i)),
                base_height,
                -(chessboard_z / 2 - tile_z)),
                new Quaternion(0.0f, 180.0f, 0.0f, 0.0f));
        }
        for (int i = 0; i < tiles_3.Count; i++)
        {
            Instantiate(tiles_3[i], new Vector3(-(chessboard_x / 2 - tile_x),
                base_height,
                -tile_x * ((tiles_3.Count - 1) / 2.0f - (float)(i))),
                new Quaternion(0.0f, -1.0f, 0.0f, 1.0f));
        }
        for (int i = 0; i < tiles_4.Count; i++)
        {
            Instantiate(tiles_4[i], new Vector3(chessboard_x / 2 - tile_x,
                base_height,
                tile_x * ((tiles_4.Count - 1) / 2.0f - (float)(i))),
                new Quaternion(0.0f, 1.0f, 0.0f, 1.0f));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
