using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleportPad : MonoBehaviour
{
    // the current teleport pad
    public int currentTeleportPad;

    // the teleport pad that we want to go to from the current teleport pad
    public int nextTeleportPad;
    public bool teleportEntered = false;

    float disableTimer = 0;

    GameObject player = null;

    public List<TeleportPad> teleportPads;
    Rigidbody2D characterControl = null;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        if (player == null)
        {
            Debug.LogError("Unable to find GameObject with 'Player' tag. Please assign the Player GameObject with the 'Player' tag");
        }

        // make sure that this teleport pad is not equal to the one we want to teleport to
        if (nextTeleportPad == currentTeleportPad)
        {
            Debug.LogError("nextTeleportPad (" + nextTeleportPad + ") and currentTeleportPad (" + currentTeleportPad + ") have the same value. Please Change.");
        }

        // make sure that nextTeleportPad and currentTeleportPad is greater than 0
        if ((nextTeleportPad < 1) || (currentTeleportPad < 1))
        {
            Debug.LogError("Either nextTeleportPad (" + nextTeleportPad + ") and/or currentTeleportPad (" + currentTeleportPad + ") has an invalid value. Please Change.");
        }

        // create a list of all the teleport pads
        teleportPads = new List<TeleportPad>(FindObjectsOfType<TeleportPad>());

        // they need to be sorted correctly
        teleportPads.Sort((x, y) => x.currentTeleportPad.CompareTo(y.currentTeleportPad) != 0 ? x.currentTeleportPad.CompareTo(y.currentTeleportPad) : x.currentTeleportPad.CompareTo(y.currentTeleportPad));

        characterControl = player.GetComponent<Rigidbody2D>();
        if (characterControl == null)
        {
            Debug.LogError("Unable to find component CharacterControl attached to the Player GameObject. Pleas attach one.");
        }
    }

    void Update()
    {
        // change KeyCode to desired KeyCode
        // you may also want to move conditional statement below to FixedUpdate()
        if ((Input.GetKeyUp(KeyCode.Return)) && (teleportEntered))
        {
            teleportEntered = false;
            TeleportPlayer();
        }

        if (disableTimer > 0)
            disableTimer -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if ((!teleportEntered) && (collider.gameObject == player))
        {
            teleportEntered = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        // you may need to modify this to meet your logic
        if (collider.gameObject == player)
        {
            disableTimer = 2;
            teleportEntered = false;
        }
    }

    void TeleportPlayer()
    {
        // teleportPads list is 0 based so subtract one from nextTeleportPad
        int nextPadNum = nextTeleportPad - 1;

        // get the next teleport pad to teleport to
        TeleportPad pad = teleportPads[nextPadNum];

        float padYOffset = (player.transform.position.y - gameObject.transform.position.y);

        // calculate where to position the player on the next teleport pad
        Vector3 newPlayerPosition = new Vector3(pad.transform.position.x, pad.transform.position.y + padYOffset, pad.transform.position.z);

        player.transform.position = newPlayerPosition;
        teleportEntered = false;
        teleportPads[nextPadNum].teleportEntered = true;
        teleportPads[nextPadNum].disableTimer = 2;

        // clear key buffer so key is not triggered again
        Input.ResetInputAxes();

        //characterControl.rot = 200;
    }
}