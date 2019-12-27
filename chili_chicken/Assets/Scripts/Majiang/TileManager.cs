using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<int> tiles;
    public List<int> out_tiles;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Initialize()
    {
        tiles = new List<int>();
        out_tiles = new List<int>();
        AddNumber(PlayerPrefs.GetInt("number1"));
        AddNumber(PlayerPrefs.GetInt("number2"));
        AddNumber(PlayerPrefs.GetInt("number3"));
        AddWord(PlayerPrefs.GetInt("word1"));
        AddWord(PlayerPrefs.GetInt("word2"));
        AddWord(PlayerPrefs.GetInt("word3"));
        AddWord(PlayerPrefs.GetInt("word4"));
        AddWord(PlayerPrefs.GetInt("word5"));
        AddWord(PlayerPrefs.GetInt("word6"));
        AddWord(PlayerPrefs.GetInt("word7"));


        Randomize(tiles);
        //Randomize(tiles);
    }
    private void AddNumber(int temp)
    {
        temp *= 10;
        for(int i = 1; i < 10; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                tiles.Add(temp + i);
            }
        }
    }
    private void AddWord(int temp)
    {
        for(int i = 0; i < 4; i++)
        {
            tiles.Add(temp);
        }
    }



    public void Randomize(List<int> ls)
    {
        System.Random rnd = new System.Random();
        for(int i = 0; i < ls.Count; i++)
        {
            Swap(ls, i, rnd.Next(0, ls.Count));
        }
    }
    private void Swap(List<int> ls, int a, int b)
    {
        int temp = ls[a];
        ls[a] = ls[b];
        ls[b] = temp;
    }

    public int Sent()
    {
        if(tiles.Count > 0)
        {
            int tile_id = tiles[0];
            tiles.Remove(tile_id);
            return tile_id;
        }
        return -1;
    }


    void Update()
    {
        
    }
}
