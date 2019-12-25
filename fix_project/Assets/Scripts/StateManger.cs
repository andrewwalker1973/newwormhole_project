using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ThePlayers = GameObject.FindObjectOfType<Player>();
        // who is actually playing ?
        
        // 0 = human
        //1 = computer
        //2 = not playing

           

            if (ThePlayers.player1_hum_comp == 0 || ThePlayers.player1_hum_comp == 1)
            {
                countOfPlayersActuallyPlaying++;
            
            
            }

            if (ThePlayers.player2_hum_comp == 0 || ThePlayers.player2_hum_comp == 1)
            {
                countOfPlayersActuallyPlaying++;
            }

            if (ThePlayers.player3_hum_comp == 0 || ThePlayers.player3_hum_comp == 1)
            {
                countOfPlayersActuallyPlaying++;
            }

            if (ThePlayers.player4_hum_comp == 0 || ThePlayers.player4_hum_comp == 1)
            {
                countOfPlayersActuallyPlaying++;
            }

        NumberOfPlayers = countOfPlayersActuallyPlaying;
        Debug.Log("NumberOfPlayers" + NumberOfPlayers);



        
    }
    Player ThePlayers;

    public int NumberOfPlayers = 4; //max number of players playing
    public int CurrentPlayerId = 0;  //set current playerid = 0 Ie - Player1
    public int DiceTotal;           // Total all dice rolls

    public bool IsDoneRolling = false;  // is done rolling false - have we finshed rollling
    public bool IsDoneClicking = false; //have we finished clicking
    public bool IsDoneAnimating = false; // Have we finshed moving

    int countOfPlayersActuallyPlaying = 0;


    public void NewTurn()
    {
     
        
        //start of a players turn
        IsDoneRolling = false;
        IsDoneClicking = false;
        IsDoneAnimating = false;

        // TODO move to next player
            CurrentPlayerId = (CurrentPlayerId + 1) % NumberOfPlayers;   // episode 6 20:56   trys to make sure on the number of players

              


    }

    // Update is called once per frame
    void Update()
    {
        // is the tunrn done ?
        if (IsDoneRolling && IsDoneClicking && IsDoneAnimating)
        {
            Debug.Log ("Turn is done");
            NewTurn();
        }
    }
}
