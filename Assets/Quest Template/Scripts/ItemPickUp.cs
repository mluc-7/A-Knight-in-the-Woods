using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public GameObject itemCollectedImage;
    public GameObject  dialogue2;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
                itemCollectedImage.SetActive(true);
                TriggerNPCTalk.playerHasItem = true; // Notify the NPC that the player has the item
                dialogue2.SetActive(true);
                
            
        }
    }

}
