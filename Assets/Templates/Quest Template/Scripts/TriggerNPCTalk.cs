using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNPCTalk : MonoBehaviour
{
    // Assuming you have a canvas for each dialogue
    public GameObject dialogueCanvasOne; // For initial dialogue
    public GameObject dialogueCanvasTwo; // For reminder dialogue
    public GameObject dialogueCanvasThree; // For quest completion dialogue

    // Track whether the player has spoken to the NPC and the quest status
    public static bool spokeToNPC = false;
    public static bool playerHasItem = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            if (!spokeToNPC)
            {
                // First time speaking to the NPC
                dialogueCanvasOne.SetActive(true);
                spokeToNPC = true; // Now the player has spoken to the NPC
            }
            else if (spokeToNPC && !playerHasItem)
            {
                // Player has spoken to the NPC before but doesn't have the item
                dialogueCanvasTwo.SetActive(true);
            }
            else if (spokeToNPC && playerHasItem)
            {
                // Player returns with the item
                dialogueCanvasThree.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Assuming you want to turn off all dialogue canvases when the player leaves the trigger
        dialogueCanvasOne.SetActive(false);
        dialogueCanvasTwo.SetActive(false);
        dialogueCanvasThree.SetActive(false);
    }

    // You'd call this method when the player picks up the quest item
    public void PlayerCollectedItem()
    {
        playerHasItem = true;
    }

    public void ResetScene()
    {
        playerHasItem = false;
        spokeToNPC = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
