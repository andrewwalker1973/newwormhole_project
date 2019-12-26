using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShips : MonoBehaviour
{


    StateManger theStateManager;
    CameraController theCameraController;

    //added in for smooth move
    Vector3 targetPosition;
    Vector3 velocity;
    float smoothTime = 0.15f;
    float smoothTimeVertical = 0.1f;
    float smoothDistance = 0.01f;
    float smoothHeight = 35f;

    public Tile startingTile;
    Tile currentTile;

    public int PlayerId;



    // added into handle player moving off board
    bool scoreMe = false;

    // added in to keep record of tiles to move across
    Tile[] moveQueue;
    int moveQueueIndex;

    bool isAnimating = false;

    Player ThePlayers;



    // Start is called before the first frame update
    void Start()
    {
        theStateManager = GameObject.FindObjectOfType<StateManger>();

        targetPosition = this.transform.position;

        ThePlayers = GameObject.FindObjectOfType<Player>();
        theCameraController = GameObject.FindObjectOfType<CameraController>();

    }










    // Update is called once per frame
    void Update()
    {
        if (isAnimating == false)
        {
            // Nothiog for us to do
            return;
        }
        if (Vector3.Distance(
            new Vector3(this.transform.position.x, targetPosition.y, this.transform.position.z),
            targetPosition)
            < smoothDistance)
        {

            // reached the target how is the height
            if (moveQueue != null && moveQueueIndex == (moveQueue.Length) && this.transform.position.y > smoothDistance)
            {
                this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                new Vector3(this.transform.position.x, 0, this.transform.position.z),
                ref velocity,
                smoothTimeVertical);
            }
            else
            {
                //right position and rihht height, advance the queue
                AdvancedMoveQueue();
            }

        }
        // move the player up a bit before we move to new location
        else if (this.transform.position.y < (smoothHeight - smoothDistance))
        {
            this.transform.position = Vector3.SmoothDamp(
            this.transform.position,
            new Vector3(this.transform.position.x, smoothHeight, this.transform.position.z),
            ref velocity,
            smoothTimeVertical);

        }
        else
        {
            this.transform.position = Vector3.SmoothDamp(
            this.transform.position,
            new Vector3(targetPosition.x, smoothHeight, targetPosition.z),
            ref velocity,
            smoothTime);
        }
    }


    void AdvancedMoveQueue()
    {
        if (moveQueue != null && moveQueueIndex < moveQueue.Length)
        {
            Tile nextTile = moveQueue[moveQueueIndex];
            if (nextTile == null)
            {
                // we are being scored move player off board
                //TODO something for end game winner, maybe move to winner area ?
                SetNewTargetPosition(this.transform.position + Vector3.right * 100f);

            }
            else
            {
                SetNewTargetPosition(nextTile.transform.position);
                moveQueueIndex++;
            }
            
        }
        else
        {
            //the movement queue is empty, we are done moving
            Debug.Log("Done animating.");
            this.isAnimating = false;
            theStateManager.IsDoneAnimating = true;



        }
    }

    void SetNewTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
        velocity = Vector3.zero;
    }

    void OnMouseUp()
    {




        if (theStateManager.CurrentPlayerId != PlayerId)
        {
            return;  // its not my turn

        }

        // test to see if I can get the camera to move to different ships at player turn

  /*      if (this.PlayerId == 0)
        {
            // theCameraController.target = this.transform.name(Ship1};
            theCameraController.target = GameObject.FindGameObjectWithTag("Player1").transform;
        }
        if (this.PlayerId == 1)
        {
            // theCameraController.target = this.transform.name(Ship1};
            theCameraController.target = GameObject.FindGameObjectWithTag("Player2").transform;
        }

        if (this.PlayerId == 2)
        {
            // theCameraController.target = this.transform.name(Ship1};
            theCameraController.target = GameObject.FindGameObjectWithTag("Player3").transform;
        }
        if (this.PlayerId == 3)
        {
            // theCameraController.target = this.transform.name(Ship1};
            theCameraController.target = GameObject.FindGameObjectWithTag("Player4").transform;
        }
*/
        if (theStateManager.IsDoneRolling == false)
        {
            //we cant move yet

            // Have we rolled the dice ?

           

            //CHECK TO MAKE SURE THERE IS NO ui OBJECT IN THE WAY
            return;

        }
        if (theStateManager.IsDoneClicking == true)
        {
            // we have already done a move
            return;
        }


        int spacesToMove = theStateManager.DiceTotal;

        if (spacesToMove == 0)
        {
            return;
        }

        //Debug.Log("Spaces to move" + spacesToMove);
        // Andrew, this does not seem to be coming though correctly

        moveQueue = new Tile[spacesToMove];
    


        Tile finalTile = currentTile;

    

        for (int i = 0; i < spacesToMove; i++)
        {
            //  check if no tile? ie off board ?
            if (finalTile == null && scoreMe == false)
            {
                finalTile = startingTile;
            }
            else
            {

                if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
                {
                    // TODO  we have reached the end and score player
                      Debug.Log("Score!!!!!");
                  
                    scoreMe = true;
                    finalTile = null;
                }
                else if (finalTile.NextTiles.Length > 1)
                {
                    // branch based on player ID
                    finalTile = finalTile.NextTiles[ PlayerId ];
                }
                else
                {
                    finalTile = finalTile.NextTiles[0];
                }


            }
            moveQueue[i] = finalTile;
        }

// TODO - check to see if the destination is legal

        moveQueueIndex = 0;
        currentTile = finalTile;
        theStateManager.IsDoneClicking = true;
        this.isAnimating = true;




    }
}