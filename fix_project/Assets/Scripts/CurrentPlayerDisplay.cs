using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrentPlayerDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        playerText = GetComponent<TMP_Text>();
        theStateManager = GameObject.FindObjectOfType<StateManger>();
    }

    TMP_Text playerText;
    StateManger theStateManager;

    string[] numberWords = { "One", "Two", "Three", "Four" };

    // Update is called once per frame
    void Update()
    {
        playerText.text = "Current Player: " + numberWords[theStateManager.CurrentPlayerId];
    }
}
