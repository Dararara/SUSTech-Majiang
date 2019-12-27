using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    //private Rotate_camera rotate_Camera;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        //rotate_Camera = GameObject.Find("Player").GetComponent<Rotate_camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPotentialIfNotYet(List<MyTile> tiles)
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            tiles[i].SetPotential();
        }
    }
    public override List<MyTile> Ask_answer(MyTile tile)
    {
        List<MyTile> out_tiles = new List<MyTile>();
        List<int> showing_ids = GetShowInts();
        int match_num = tile.tile_id;

        for (int i = 0; i < my_tiles.Count; i++)
        {
            if (match_num == my_tiles[i].tile_id) out_tiles.Add(my_tiles[i]);
        }
        if (out_tiles.Count >= 2)
        {
            SetPotentialIfNotYet(out_tiles);
        }

        for (int i = 0; i < my_tiles.Count; i++)
        {
            for (int j = 0; j < my_tiles.Count; j++)
            {
                List<int> tempss = new List<int>(new int[] { tile.tile_id, my_tiles[i].tile_id, my_tiles[j].tile_id });
                if (CheckThreeSequence(tempss))
                {
                    my_tiles[i].SetPotential();
                    my_tiles[j].SetPotential();
                }
            }
        }


        showing_ids = GetShowInts();
        List<int> temps = new List<int>();
        for (int i = 0; i < showing_ids.Count; i++)
        {
            temps.Add(showing_ids[i]);
        }
        temps.Add(tile.tile_id);
        if(CheckThreeOrFourSame(temps) || CheckThreeSequence(temps))
        {
            if (Input.GetMouseButtonDown(1))
            {
                ClearPotential();
                return Delete(GetShowTiles());
            }
                       
                
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClearPotential();
            return new List<MyTile>();
        }

        return null;
        



    }
    
    public List<int> GetShowInts()
    {
        //get the ids of showing tiles, help to check which tile need to be set to potential
        List<int> results = new List<int>();
        for(int i = 0; i < my_tiles.Count; i++)
        {
            if (my_tiles[i].is_showing) results.Add(my_tiles[i].tile_id);
        }

        return results;
    }
    
    public List<MyTile> GetShowTiles()
    {
        List<MyTile> results = new List<MyTile>();
        for (int i = 0; i < my_tiles.Count; i++)
        {
            if (my_tiles[i].is_showing) results.Add(my_tiles[i]);
        }

        return results;
    }
    private bool ok = false;
    private bool over_set = false;
    public override List<MyTile> Play()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            ok = true;
        }
        if (CheckOver())
        {
            over_set = true;
            SetPotentialAll();
        }
        for(int i = 0; i < my_tiles.Count-3; i++)
        {
            if(my_tiles[i].tile_id == my_tiles[i + 1].tile_id && 
                my_tiles[i + 1].tile_id == my_tiles[i + 2].tile_id && 
                my_tiles[i + 2].tile_id == my_tiles[i + 3].tile_id)
            {
                my_tiles[i].SetPotential();
                my_tiles[i + 1].SetPotential();
                my_tiles[i + 2].SetPotential();
                my_tiles[i + 3].SetPotential();

            }
        }



        int play_id = -1;
        int count = 0;
        for (int i = 0; i < my_tiles.Count; i++)
        {
            if (my_tiles[i].is_showing == true)
            {
                play_id = i;
                count += 1;
            }
        }
        List<MyTile> result = new List<MyTile>();
        //打出一张牌
        if (count == 1 && ok)
        {
            MyTile tile = my_tiles[play_id];
            PlayTile(tile);
            over_set = false;
            result.Add(tile);
            ClearPotential();
            return result;
        }
        bool four = true;

        result = new List<MyTile>();
        for (int i = 0; i < my_tiles.Count; i++)
        {
            if(my_tiles[i].is_showing == true)
            {
                if(my_tiles[i].tile_id == my_tiles[play_id].tile_id)
                {
                    result.Add(my_tiles[i]);
                }
                else
                {

                    four = false;
                }
            }
        }
        //打出四张牌
        if (count == 4 && ok && four)
        {
            for(int i = 0; i < 4; i++)
            {
                PlayTile(result[i]);
            }
            over_set = false;
            ClearPotential();
            over_course += 1;
            return result;
        }

        if(over_set)
        {
            MyTile temp = CreateTile();
            temp.tile_id = -1;
            result = new List<MyTile>();
            result.Add(temp);
            ClearPotential();
            return result;
        } 

        ok = false;
        return null;
    }
    public bool CheckOverChoose()
    {
        //if player choose all the tile with potential, over the game
        for(int i = 0; i < my_tiles.Count; i++)
        {
            if (my_tiles[i].potential_choose)
            {
                if (!my_tiles[i].is_showing)
                {
                    return false;
                }
            }
        }
        return true;
    }


    public void SetPotentialAll()
    {
        for (int i = 0; i < my_tiles.Count - 2; i++)
        {
            List<int> temp_id = new List<int>();
            temp_id.Add(my_tiles[i].tile_id);
            temp_id.Add(my_tiles[i + 1].tile_id);
            temp_id.Add(my_tiles[i + 2].tile_id);
            if (CheckThreeOrFourSame(temp_id) || CheckThreeSequence(temp_id))
            {
                my_tiles[i].SetPotential();
                my_tiles[i+1].SetPotential();
                my_tiles[i+2].SetPotential();
                i += 2;
            }
        }
    }
}
