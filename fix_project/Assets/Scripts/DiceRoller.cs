using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    StateManger theStateManager;
   





    // Start is called before the first frame update
    void Start()
    {
        DiceValues = new int[1];        // only using one dice
        DiceFaceImage = GetComponent<Image>();
        theStateManager = GameObject.FindObjectOfType<StateManger>();

        //AW find a way to set dice image to blank
        //   anim = GetComponent<Animator>();

    }

    public int[] DiceValues;        // int of all dice values


    //set images for the dice image
    public Sprite[] DiceImageOne;
    public Sprite[] DiceImageTwo;
    public Sprite[] DiceImageThree;
    public Sprite[] DiceImageFour;
    public Sprite[] DiceImageFive;
    public Sprite[] DiceImageSix;
    public Sprite[] DiceBlank;

    


    // Set Dice Image
    Image DiceFaceImage;






    // Update is called once per frame
    void Update()
    {

    }


 

    public void RollTheDice()
    {
        if (theStateManager.IsDoneRolling == true)
        {
            // we ahve already rolled this turn
            return;
        }

        theStateManager.DiceTotal = 0;
        
   

    
        DiceFaceImage = GetComponent<Image>();
        
        //AW add in amim or something to make it show the dice is ready to roll
    
        // anim.SetTrigger("DiceRollAnim");
        for (int i = 0; i < DiceValues.Length; i++)
        {
            
                DiceValues[i] = Random.Range(1, 7);
            theStateManager.DiceTotal += DiceValues[i];

            

            
            switch (DiceValues[i])
            {
                case 1:
                    
                    this.transform.GetChild(i).GetComponent<Image>().sprite =
                    DiceImageOne[Random.Range(0, DiceImageOne.Length)];
                    break;
                case 2:
                    
                    this.transform.GetChild(i).GetComponent<Image>().sprite =
                   DiceImageTwo[Random.Range(0, DiceImageTwo.Length)];
                    break;
                case 3:
                    
                    this.transform.GetChild(i).GetComponent<Image>().sprite =
                   DiceImageThree[Random.Range(0, DiceImageThree.Length)];
                    break;
                case 4:
                    
                    this.transform.GetChild(i).GetComponent<Image>().sprite =
                   DiceImageFour[Random.Range(0, DiceImageFour.Length)];
                    break;
                case 5:
                 
                    this.transform.GetChild(i).GetComponent<Image>().sprite =
                   DiceImageFive[Random.Range(0, DiceImageFive.Length)];
                    break;
                case 6:
                   
                    this.transform.GetChild(i).GetComponent<Image>().sprite =
                   DiceImageSix[Random.Range(0, DiceImageSix.Length)];
                    break;
            }
        }
        
        
        theStateManager.IsDoneRolling = true;
    }
    
}

