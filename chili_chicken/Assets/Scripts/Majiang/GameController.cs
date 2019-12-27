
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public MyTile origin;
    public int current_player;
    public Player player;
    public HumanPlayer humanPlayer;
    public List<Player> players;
    private TileManager tile_manager;
    private TileGenerator tileGenerator;
    public MyTile current_tile;
    public float count1;
    public float count2;
    public float count3 = 10;
    public float count4;
    public float count5;
    public MyTile tile;
    public Camera mainCamera;
    public Camera highCamera;
    public Camera[] cameras;
    public GameObject p;
    public Rotate_camera rotate_Camera;
    public List<int> player_tiles;
    public List<int> player_outtiles;
    public bool player_win;
    public int play_count_down;
    // Start is called before the first frame update
    void Start()
    {

        
        cameras = GameObject.FindObjectsOfType<Camera>();
        for(int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].CompareTag("MainCamera"))
            {
                mainCamera = cameras[i];
            }
            if (cameras[i].CompareTag("highCamera"))
            {
                highCamera = cameras[i];
            }

        }
        is_normal = true;
        //特殊的下一位，吃碰杠时触发，优先级高于默认，正常情况下为-1
        nextPlayer = -1;
        highCamera.enabled = false;
        players = new List<Player>();
        tile_manager = gameObject.GetComponent<TileManager>();
        tile_manager.Initialize();
        
        //player位置随缘
        players.Add(Instantiate(humanPlayer, transform));
        players.Add(Instantiate(player, transform));
        players.Add(Instantiate(player, transform));
        players.Add(Instantiate(player, transform));
        //players[0] = Instantiate(player, transform);
        //players[1] = Instantiate(player, transform);
        //players[2] = Instantiate(player, transform);
        //players[3] = Instantiate(player, transform);

        //发牌阶段
        int initial_tile = 14;
        current_player = 0;
        for(int i = 0; i < initial_tile + 1; i++)
        {
            GiveOutTile(players[0]);
        }
        for (int i = 0; i < initial_tile; i++)
        {
            GiveOutTile(players[1]);
        }
        for (int i = 0; i < initial_tile; i++)
        {
            GiveOutTile(players[2]);
        }
        for (int i = 0; i < initial_tile; i++)
        {
            GiveOutTile(players[3]);
        }

        tileGenerator = gameObject.GetComponent<TileGenerator>();
        tileGenerator.Initialize();
        tileGenerator.Generate1(players[0]);
        tileGenerator.Generate2(players[1]);
        tileGenerator.Generate3(players[2]);
        tileGenerator.Generate4(players[3]);
        gameover = false;

        wait_count = 0;
        player_win = false;
        player_tiles = new List<int>();
        player_outtiles = new List<int>();
        play_count_down = 144;
        CountDownUpdate(play_count_down);
    }


    public bool wait;
    public float wait_count;
    private bool WaitForSeconds(int waitTime)
    {
        if(wait_count > waitTime)
        {
            wait = false;
            wait_count = 0;
            return true;
        }
        else
        {
            wait_count += Time.deltaTime;
            return false;
        }
    }
    
    public List<MyTile> results;
    public bool[] ok = { false, false, false, false };
    
    // Update is called once per frame
    void CleanPlayer()
    {
        for(int i = 0; i < players.Count; i++)
        {
            players[i].clean();
        }
    }
    public bool gameover = false;
    public ResultDesplayer resultDesplayer;
    public Text CountDownText;
    public void CountDownUpdate(int update_num)
    {
        CountDownText.text = "距离学期结束还有：" + update_num + "天";
    }

    void GameOver(bool player_win = true)
    {
        if(gameover == false)
        {
            //游戏结束，解锁视角
            gameover = true;
            rotate_Camera.sight_lock = false;
            //在这之前，将手牌归档在play_tiles里面等待结算
            player_tiles.Clear();
            player_outtiles.Clear();
            for (int i = 0; i < players[0].my_tiles.Count; i++)
            {
                //Debug.Log(players[0].my_tiles[i].tile_id);
                player_tiles.Add(players[0].my_tiles[i].tile_id);
            }
            for (int i = 0; i < players[0].show_tiles.Count; i++)
            {
                player_outtiles.Add(players[0].show_tiles[i].tile_id);
            }
            if (current_player == 0)
            {
                player_win = true;
            }
            //展示胡牌玩家所有手牌
            if (player_win)
            {
                players[current_player].ShowAll();
            }
            
            Redisplay(current_player);
            resultDesplayer = gameObject.GetComponent<ResultDesplayer>();
            resultDesplayer.FillAndShow(player_tiles, player_outtiles, player_win);
        }
        else
        {
            resultDesplayer.FillAndShow(player_tiles, player_outtiles, player_win);
        }
        
    }
    public AudioSource audio;
    void AskPlayerPlay()
    {
        List<MyTile> answer_tiles = players[current_player].Play();
        if(answer_tiles != null && answer_tiles.Count == 1)
        {
            play_count_down -= 2;
            CountDownUpdate(play_count_down);
            current_tile = answer_tiles[0];

            if(current_tile.tile_id == -1)
            {
                GameOver();
                return;
            }

            //let the tile out
            current_tile.Go_out();
            audio.Play();
            //set the ok of other three people false
            for (int i = 0; i < 4; i++) ok[i] = false;
            ok[current_player] = true;
            //redisplay the current player's tiles
            if (current_player == 0) tileGenerator.Generate1(players[current_player]);
            else if (current_player == 1) tileGenerator.Generate2(players[current_player]);
            else if (current_player == 2) tileGenerator.Generate3(players[current_player]);
            else if (current_player == 3) tileGenerator.Generate4(players[current_player]);

            CleanPlayer();
            wait = true;
        }
        if(answer_tiles != null && answer_tiles.Count == 4)
        {
            play_count_down -= 2;
            CountDownUpdate(play_count_down);
            //AddToOutTiles(answer_tiles);
            players[current_player].GetShowTile(answer_tiles[0].tile_id);
            players[current_player].GetShowTile(answer_tiles[1].tile_id);
            players[current_player].GetShowTile(answer_tiles[2].tile_id);
            players[current_player].GetShowTile(answer_tiles[3].tile_id);
            CleanTile(answer_tiles[0], false);
            CleanTile(answer_tiles[1], false);
            CleanTile(answer_tiles[2], false);
            CleanTile(answer_tiles[3], false);
            players[current_player].ClearPotential();
            GiveOutTile(players[current_player]);
            if (current_player == 0) tileGenerator.Generate1(players[current_player]);
            else if (current_player == 1) tileGenerator.Generate2(players[current_player]);
            else if (current_player == 2) tileGenerator.Generate3(players[current_player]);
            else if (current_player == 3) tileGenerator.Generate4(players[current_player]);
            
        }


    }
    public bool is_normal;
    public int yao;
    void CleanTile(MyTile temp_tile, bool reuse = true)
    {
        //add it back to tile manager
        if (reuse)
        {
            tile_manager.tiles.Add(temp_tile.tile_id);
        }
        
        //destroy the current tile
        temp_tile.Suiside();
    }

    int nextPlayer;

    int GetNextPlayer(int temp_player)
    {
        if(nextPlayer != -1)
        {
            int temp = nextPlayer;
            nextPlayer = -1;
            return temp;
        }
        temp_player += 1;
        temp_player %= 4;
        return temp_player;
    }

    void Redisplay(int player_id)
    {
        if (player_id == 0) tileGenerator.Generate1(players[player_id]);
        else if (player_id == 1) tileGenerator.Generate2(players[player_id]);
        else if (player_id == 2) tileGenerator.Generate3(players[player_id]);
        else if (player_id == 3) tileGenerator.Generate4(players[player_id]);
    }

    void Update()
    {

        
    
        CheckViewChange();
        CheckQuit();
        if (gameover)
        {
            return;
        }
        if (play_count_down <= 0)
        {
            GameOver();
        }
        /*
        for (int i = 0; i < 4; i++)
        {
            if (players[i].CheckOver())
            {
                current_player = i;
                GameOver();
            }
        }*/
        if (!WaitForSeconds(1) && wait)
        {
            return;
        }
        //no tile in the center, ask the current player to play
        if (current_tile == null)
        {
            AskPlayerPlay();
        }

        //if current tile is not null, and everyone is ok, distroy the tile and put it back to tile manager
        if (current_tile != null && ok[0] && ok[1] && ok[2] && ok[3])
        {
            players[0].ClearPotential();
            CleanTile(current_tile);   
            //move on to next player
            current_player = GetNextPlayer(current_player);
            //give the current player a new tile
            if (is_normal)
            {
                GiveOutTile(players[current_player]);
            }
            else
            {
                is_normal = true;
            }
            
            //redisplay the tiles of the new player
            Redisplay(current_player);
            wait = true;
        }
        //else if not all player say ok
        else if(current_tile != null)
        {
            
            for (int i = 0; i < 4; i++)
            {
                //loop through the player ok list, if they are not ok, ask them
                if (!ok[i])
                {
                    results = players[i].Ask_answer(current_tile);
                    if (results != null)
                    {
                        //if result is not null, it means the player has made the decision
                        if(results.Count == 2 || results.Count == 3)
                        {
                            //if it is not null, set other's to ok, break
                            for(int j = 0; j < 4; j++)
                            {
                                ok[j] = true;
                            }
                            //here we need to let gamecontroller to change the pace.
                            yao = i;
                            wait = true;
                            //玩家获取展示的牌，凑成一个三元组或者四元组
                            players[i].GetShowTile(current_tile.tile_id);
                            
                            if(results.Count == 3)
                            {
                                GiveOutTile(players[i]);
                            }
                            Redisplay(i);
                            nextPlayer = i;
                            is_normal = false;

                            //如果游戏结束，那么就结束了，如果没有结束，而且还是玩家打出的，那么将牌组存放在出牌堆
                            if (players[i].CheckOver())
                            {
                                current_player = i;
                                players[current_player].ClearPotential();
                                GameOver();
                            }
                            else if(i == 0)
                            {
                                
                                //results.Add(current_tile);
                                //AddToOutTiles(results);
                            }
                            break;

                        }
                        ok[i] = true;
                        
                        
                    }
                }
            }
        }
    }
    void AddToOutTiles(List<MyTile> tiles)
    {
        for (int j = 0; j < tiles.Count; j++)
        {
            player_outtiles.Add(tiles[j].tile_id);
        }
        player_outtiles.Add(-1);
    }


    void CheckViewChange()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (highCamera.enabled)
            {
                highCamera.enabled = false;
                mainCamera.enabled = true;
            }
            else
            {
                highCamera.enabled = true;
                mainCamera.enabled = false;
            }
        }
    }
    public static void  CheckQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    IEnumerator SetTrue(int id)
    {
        yield return new WaitForSeconds(0.8f);
        ok[id] = true;
    }
    void GiveOutTile(Player player)
    {
        int ti = tile_manager.Sent();
        if (player.CheckThreeToFour(ti))
        {
            GiveOutTile(player);
        }
        else
        {
            player.GetTile(ti);
        }

        
    }
    public void OnGiveUp()
    {
        players[1].over_course = 6;
        players[2].over_course = 6;
        players[3].over_course = 6;
        current_player = 1;
        GameOver();
    }
}
