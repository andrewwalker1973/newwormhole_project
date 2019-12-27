using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceTotalDisplay : MonoBehaviour
{

  StateManger theStateManager;
  

    // Start is called before the first frame update
    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<StateManger>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theStateManager.IsDoneRolling == false)
        {
            GetComponent<TMP_Text>().text = "Dice Total =  ?";            
        }
        else
        {
            GetComponent<TMP_Text>().text = "Dice Total =  " + theStateManager.DiceTotal;
        }
    }
}
