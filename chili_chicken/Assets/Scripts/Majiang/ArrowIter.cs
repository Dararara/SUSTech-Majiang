using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIter : MonoBehaviour
{
    public GameObject[] arrows;
    public GameController game_controller;
    // Start is called before the first frame update
    void Start()
    {
        game_controller = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
        arrows[game_controller.current_player].SetActive(true);
    }
}
