using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // set a variable to cater for ship number and player number 
   public  float player1_hum_comp;
    float player1_ship;
    bool player1_onboard;


    public float player2_hum_comp;
    float player2_ship;
    bool player2_onboard;


    public float player3_hum_comp;
    float player3_ship;
    bool player3_onboard;

    public float player4_hum_comp;
    float player4_ship;
    bool player4_onboard;


    //define spawn points for player ships
    public Transform Player1_SpawnPoint;
    public Transform Player2_SpawnPoint;
    public Transform Player3_SpawnPoint;
    public Transform Player4_SpawnPoint;

    //define game objects to refer to player ships
    public GameObject Ship1;
    public GameObject Ship2;
    public GameObject Ship3;
    public GameObject Ship4;

    GameObject player1_ships;
    GameObject player2_ships;
    GameObject player3_ships;
    GameObject player4_ships;

   



    void Start()
    {

        // code to pull the data from player prefs

        player1_hum_comp = PlayerPrefs.GetFloat("player1_playing_input");
        player1_ship = PlayerPrefs.GetFloat("player1_ship");

        player2_hum_comp = PlayerPrefs.GetFloat("player2_playing_input");
        player2_ship = PlayerPrefs.GetFloat("player2_ship");

        player3_hum_comp = PlayerPrefs.GetFloat("player3_playing_input");
        player3_ship = PlayerPrefs.GetFloat("player3_ship");

        player4_hum_comp = PlayerPrefs.GetFloat("player4_playing_input");
        player4_ship = PlayerPrefs.GetFloat("player4_ship");

        


        if (this.gameObject.name == "Player1" && player1_onboard == false)
            {
           
                    switch (player1_hum_comp)
                    {
                        case 0:
                           
                            check_player1_ship();
                            player1_onboard = true;
                            break;
                        case 1:
                            
                            check_player1_ship();
                            player1_onboard = true;
                            break;
                        case 2:
                            
                            // add in code not to show a ship
                            player1_onboard = true;
                            break;
                    }
         
                player1_onboard = true;
            }

        if (this.gameObject.name == "Player2" && player2_onboard == false)
        {
          
            switch (player2_hum_comp)
            {
                case 0:
                   
                    check_player2_ship();
                    player2_onboard = true;
                    break;
                case 1:
                    
                    check_player2_ship();
                    player2_onboard = true;
                    break;
                case 2:
                    
                    // add in code not to show a ship
                    player2_onboard = true;
                    break;
            }
            //check_player1_ship();
            player2_onboard = true;
        }


        if (this.gameObject.name == "Player3" && player3_onboard == false)
        {
            
            switch (player3_hum_comp)
            {
                case 0:
                    
                    check_player3_ship();
                    player3_onboard = true;
                    break;
                case 1:
                    
                    check_player3_ship();
                    player3_onboard = true;
                    break;
                case 2:
                   
                    // add in code not to show a ship
                    player3_onboard = true;
                    break;
            }
            //check_player1_ship();
            player3_onboard = true;
        }

        if (this.gameObject.name == "Player4" && player4_onboard == false)
        {
            
            switch (player4_hum_comp)
            {
                case 0:
                    
                    check_player4_ship();
                    player4_onboard = true;
                    break;
                case 1:
                    
                    check_player4_ship();
                    player4_onboard = true;
                    break;
                case 2:
                    
                    // add in code not to show a ship
                    player4_onboard = true;
                    break;
            }
            //check_player1_ship();
            player4_onboard = true;
        }
    }

        // Update is called once per frame
        void Update()
        {

        }

        void check_player1_ship()
        {

            // Code to instantiate player 1 ship type
            switch (player1_ship)
            {
                case 0:
                    player1_ships = Instantiate(Ship1, Player1_SpawnPoint.transform.position, Player1_SpawnPoint.transform.rotation);
                    player1_ships.transform.localScale = new Vector3(2, 2, 2);
                    player1_ships.SetActive(true);
                    player1_ships.name = "PLAYER1";
                    break;
                case 1:
                    player1_ships = Instantiate(Ship3, Player1_SpawnPoint.transform.position, Player1_SpawnPoint.transform.rotation);
                    player1_ships.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    player1_ships.SetActive(true);
                    player1_ships.name = "PLAYER1";
                    break;
                case 2:
                    player1_ships =  Instantiate(Ship2, Player1_SpawnPoint.transform.position, Player1_SpawnPoint.transform.rotation);
                    player1_ships.transform.localScale = new Vector3(20, 20, 20);
                    player1_ships.SetActive(true);
                    player1_ships.name = "PLAYER1";
                    break;
                case 3:
                player1_ships = Instantiate(Ship4, Player1_SpawnPoint.transform.position, Player1_SpawnPoint.transform.rotation);
                player1_ships.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                player1_ships.SetActive(true);
                player1_ships.name = "PLAYER1";
                break;
            }
        }
    


   void check_player2_ship()
    {

        // Code to instantiate player 2 ship type
        switch (player2_ship)
        {
            case 0:
                player2_ships = Instantiate(Ship1, Player2_SpawnPoint.transform.position, Player2_SpawnPoint.transform.rotation);
                player2_ships.transform.localScale = new Vector3(2, 2, 2);
                player2_ships.SetActive(true);
                player2_ships.name = "PLAYER2";
                break;
            case 1:
                player2_ships = Instantiate(Ship3, Player2_SpawnPoint.transform.position, Player2_SpawnPoint.transform.rotation);
                player2_ships.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                player2_ships.SetActive(true);
                player2_ships.name = "PLAYER2";
                break;
            case 2:
                player2_ships = Instantiate(Ship2, Player2_SpawnPoint.transform.position, Player2_SpawnPoint.transform.rotation);
                player2_ships.transform.localScale = new Vector3(20, 20, 20);
                player2_ships.SetActive(true);
                player2_ships.name = "PLAYER2";
                break;
            case 3:
                player2_ships = Instantiate(Ship4, Player2_SpawnPoint.transform.position, Player2_SpawnPoint.transform.rotation);
                player2_ships.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                player2_ships.SetActive(true);
                player2_ships.name = "PLAYER2";
                break;
        }
    }


    void check_player3_ship()
    {

        // Code to instantiate player 3 ship type
        switch (player3_ship)
        {
            case 0:
                player3_ships = Instantiate(Ship1, Player3_SpawnPoint.transform.position, Player3_SpawnPoint.transform.rotation);
                player3_ships.transform.localScale = new Vector3(2, 2, 2);
                player3_ships.SetActive(true);
                player3_ships.name = "PLAYER3";
                break;
            case 1:
                player3_ships = Instantiate(Ship3, Player3_SpawnPoint.transform.position, Player3_SpawnPoint.transform.rotation);
                player3_ships.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                player3_ships.SetActive(true);
                player3_ships.name = "PLAYER3";
                break;
            case 2:
                player3_ships = Instantiate(Ship2, Player3_SpawnPoint.transform.position, Player3_SpawnPoint.transform.rotation);
                player3_ships.transform.localScale = new Vector3(20, 20, 20);
                player3_ships.SetActive(true);
                player3_ships.name = "PLAYER3";
                break;
            case 3:
                player3_ships = Instantiate(Ship4, Player3_SpawnPoint.transform.position, Player3_SpawnPoint.transform.rotation);
                player3_ships.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                player3_ships.SetActive(true);
                player3_ships.name = "PLAYER3";
                break;
        }
    }

    void check_player4_ship()
    {

        // Code to instantiate player 4 ship type
        switch (player4_ship)
        {
            case 0:
                player4_ships = Instantiate(Ship1, Player4_SpawnPoint.transform.position, Player4_SpawnPoint.transform.rotation);
                player4_ships.transform.localScale = new Vector3(2, 2, 2);
                player4_ships.SetActive(true);
                player4_ships.name = "PLAYER4";
                break;
            case 1:
                player4_ships = Instantiate(Ship3, Player4_SpawnPoint.transform.position, Player4_SpawnPoint.transform.rotation);
                player4_ships.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                player4_ships.SetActive(true);
                player4_ships.name = "PLAYER4";
                break;
            case 2:
                player4_ships = Instantiate(Ship2, Player4_SpawnPoint.transform.position, Player4_SpawnPoint.transform.rotation);
                player4_ships.transform.localScale = new Vector3(20, 20, 20);
                player4_ships.SetActive(true);
                player4_ships.name = "PLAYER4";
                break;
            case 3:
                player4_ships = Instantiate(Ship4, Player4_SpawnPoint.transform.position, Player4_SpawnPoint.transform.rotation);
                player4_ships.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                player4_ships.SetActive(true);
                player4_ships.name = "PLAYER4";
                break;
        }
    }
}





