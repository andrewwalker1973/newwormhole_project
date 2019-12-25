using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownHandler : MonoBehaviour
{
    // Define base var for player = 2 ( not playing) and ship 1
    public int player1_playing_input = 0;
    public int player1_ship = 0;

    public int player2_playing_input = 1;
    public int player2_ship = 1 ;

    public int player3_playing_input = 1;
    public int player3_ship= 2 ;

    public int player4_playing_input = 1;
    public int player4_ship = 3 ;

   
   
         


    // Start is called before the first frame update
    void Start()
    {
        // Add in code to reset player prefs 
        PlayerPrefs.SetFloat("player1_playing_input", player1_playing_input);
        PlayerPrefs.SetFloat("player2_playing_input", player2_playing_input);
        PlayerPrefs.SetFloat("player3_playing_input", player3_playing_input);
        PlayerPrefs.SetFloat("player4_playing_input", player4_playing_input);

        PlayerPrefs.SetFloat("player1_ship", 0);
        PlayerPrefs.SetFloat("player2_ship", 1);
        PlayerPrefs.SetFloat("player3_ship", 2);
        PlayerPrefs.SetFloat("player4_ship", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Setup variables for Player1 drop box for if playing/Human/Computer
    public void DropDownInput_player1_playing(int player1_playing_input)
    {
       
        PlayerPrefs.SetFloat("player1_playing_input", player1_playing_input);
    }

    // Setup variables for Player1 ship selection
    public void DropDownInput_player1_ship(int player1_ship)
    {
       
        player1_ship = 1; //ADDEd i code to force ship setting
        PlayerPrefs.SetFloat("player1_ship", player1_ship);
    }


    // Setup variables for Player2 drop box for if playing/Human/Computer
    public void DropDownInput_player2_playing(int player2_playing_input)
    {
 
        PlayerPrefs.SetFloat("player2_playing_input", player2_playing_input);
    }

    // Setup variables for Player2 ship selection
    public void DropDownInput_player2_ship(int player2_ship)
    {
      
        player2_ship = 2; //ADDEd in code to force ship setting
        PlayerPrefs.SetFloat("player2_ship", player2_ship);
    }


    // Setup variables for Player3 drop box for if playing/Human/Computer
    public void DropDownInput_player3_playing(int player3_playing_input)
    {
        
        PlayerPrefs.SetFloat("player3_playing_input", player3_playing_input);
    }

    // Setup variables for Player3 ship selection
    public void DropDownInput_player3_ship(int player3_ship)
    {
      
        player3_ship = 3; //ADDEd i code to force ship setting
        PlayerPrefs.SetFloat("player3_ship", player3_ship);

    }

    // Setup variables for Player4 drop box for if playing/Human/Computer
    public void DropDownInput_player4_playing(int player4_playing_input)
    {
       
        PlayerPrefs.SetFloat("player4_playing_input", player4_playing_input);
    }

    // Setup variables for Player3 ship selection
    public void DropDownInput_player4_ship(int player4_ship)
    {
        
        //ADDEd i code to force ship setting
        player4_ship = 4;
        PlayerPrefs.SetFloat("player4_ship", player4_ship);
    }

}
