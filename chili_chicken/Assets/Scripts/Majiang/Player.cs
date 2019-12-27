using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public List<MyTile> my_tiles = new List<MyTile>();
    public List<int> my_tiles_id = new List<int>();
    public List<MyTile> show_tiles = new List<MyTile>();
    public int show1;
    public int show2;
    public int show3;
    public int over_course;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        over_course = 0;

        audio = gameObject.GetComponent<AudioSource>();
    }
    public void SortTiles()
    {

        my_tiles.Sort((x, y) => x.tile_id.CompareTo(y.tile_id));
        show_tiles.Sort((x, y) => x.tile_id.CompareTo(y.tile_id));

    }
    public void GetTile(int id)
    {
        MyTile tile = CreateTile();
        GetTileId(id);
        tile.Initialize(id);
        my_tiles.Add(tile);
    }
    public MyTile CreateTile()
    {
        GameObject g = Resources.Load("Prefabs/Tile") as GameObject;
        MyTile tile = Instantiate(g).GetComponent<MyTile>();
        return tile;
    }

    public void GetShowTile(int id)
    {
        GameObject g = Resources.Load("Prefabs/Tile") as GameObject;
        MyTile tile = Instantiate(g).GetComponent<MyTile>();
        //GetTileId(id);
        tile.Initialize(id);
        show_tiles.Add(tile);
    }
    

    public void GetTileId(int id)
    {
        my_tiles_id.Add(id);
    }
    public void PlayTile(MyTile tile)
    {
        my_tiles.Remove(tile);
    }
    public float play_time;
    public void clean()
    {
        play_time = 0;
    }
    public static readonly float consider_time = 1;
    public virtual List<MyTile> Play()
    {
        if (play_time < consider_time)
        {
            play_time += Time.deltaTime;
            return null;
        }
        List<MyTile> result = new List<MyTile>();
        if (CheckOver())
        {
            MyTile temp = CreateTile();
            temp.tile_id = -1;
            result.Add(temp);
            return result;
        }


        System.Random rnd = new System.Random();
        if (my_tiles.Count != 0)
        {
            result = new List<MyTile>();
            MyTile tile = my_tiles[rnd.Next(my_tiles.Count)];
            my_tiles.Remove(tile);
            my_tiles_id.Remove(tile.tile_id);
            result.Add(tile);
            return result;
        }
        return null;
    }
    float waitTime = consider_time;
    public int delete_num = 0;
    public List<MyTile> Delete(List<MyTile> tiles)
    {
        waitTime = consider_time;
        for (int i = 0; i < tiles.Count; i++)
        {
            my_tiles_id.Remove(tiles[i].tile_id);
            my_tiles.Remove(tiles[i]);
            show_tiles.Add(tiles[i]);
            tiles[i].ResetPotential();
        }
        delete_num = tiles.Count;
        over_course += 1;
        return tiles;
    }

    public bool CheckThreeToFour(int id)
    {
        int count = 0;
        for(int i = 0; i < show_tiles.Count; i++)
        {
            if(show_tiles[i].tile_id == id)
            {
                count++;
                if(count >= 3)
                {
                    MyTile temp = CreateTile();
                    temp.Initialize(id);
                    show_tiles.Insert(i, temp);
                    return true;
                }
            }
        }
        return false;
    }
    public virtual List<MyTile> Ask_answer(MyTile tile)
    {
        if (waitTime > Time.deltaTime)
        {
            waitTime -= Time.deltaTime;
            return null;
        }

        List<MyTile> out_tiles = new List<MyTile>();

        int match_num = tile.tile_id;

        for (int i = 0; i < my_tiles.Count; i++)
        {
            if (match_num == my_tiles[i].tile_id) out_tiles.Add(my_tiles[i]);
        }
        if (out_tiles.Count == 3)
        {

            return Delete(out_tiles);
        }
        if (out_tiles.Count == 2)
        {
            return Delete(out_tiles);
        }
        out_tiles = new List<MyTile>();
        if (match_num % 10 == 0)
        {
            return new List<MyTile>();
        }

        for(int i = 0; i < my_tiles.Count; i++)
        {
            for(int j = 0; j < my_tiles.Count; j++)
            {
                List<int> temps = new List<int>(new int[] { tile.tile_id, my_tiles[i].tile_id, my_tiles[j].tile_id });
                if (CheckThreeSequence(temps))
                {
                    out_tiles.Add(my_tiles[i]);
                    out_tiles.Add(my_tiles[j]);
                    return Delete(out_tiles);
                }
            }
        }


        out_tiles = new List<MyTile>();

        
        
        
        waitTime = 3;
        return new List<MyTile>();
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public bool CheckThreeSequence(List<int> array)
    {
        if (array.Count != 3) return false;
        array.Sort();
        if (array[0] % 10 == 0 || array[1] % 10 == 0 || array[2] % 10 == 0)
        {
            return false;
        }

        if (array[0] == array[1]-1 && array[1] == array[2] - 1)
        {
            return true;
        }
        return false;
    }
    public bool CheckThreeOrFourSame(List<int> array)
    {
        if (array.Count < 3) return false;
        for(int i = 1; i < array.Count; i++)
        {
            if (array[i - 1] != array[i]) return false;
        }
        return true;
    }
    public bool CheckOver()
    {
        int temp = over_course;
        if (temp >= 5)
        {
            return true;
        }
        List<int> hand_tile_ids = new List<int>();
        for(int i = 0; i < my_tiles.Count; i++)
        {
            hand_tile_ids.Add(my_tiles[i].tile_id);
        }
        
        if(over_course + Game.getTuplesNum(hand_tile_ids) >= 5)
        {
            return true;
        }

        /*
        for (int i = 0; i < my_tiles.Count-2; i++)
        {
            List<int> temp_id = new List<int>();
            temp_id.Add(my_tiles[i].tile_id);
            temp_id.Add(my_tiles[i + 1].tile_id);
            temp_id.Add(my_tiles[i + 2].tile_id);
            if(CheckThreeOrFourSame(temp_id) || CheckThreeSequence(temp_id))
            {
                temp += 1;
                i += 2;
            }
            if(temp >= 5)
            {
                return true;
            }
        }
        */

        return false;
    }
    public void ClearPotential()
    {
        for (int i = 0; i < my_tiles.Count; i++)
        {
            my_tiles[i].ResetPotential();
        }
    }
    public void ShowAll()
    {
        for(int i = 0; i < my_tiles.Count; i++)
        {
            show_tiles.Add(my_tiles[i]);
        }
        my_tiles = new List<MyTile>();
    }
}
