using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DialogueEntry
{
    public string characterName; // The name of the character speaking
    public string dialogueText; // The line of dialogue
    public Sprite playerSprite;  // The image representing Character A for this line of dialogue
    public Sprite nonPlayerSprite;  // The image representing Character B for this line of dialogue
}

public class DialogueManager : MonoBehaviour
{
   // public TriggerNPCTalk itemCollider;
    public string playerName;
    [SerializeField] private Image playerImage; // UI image for Character A
    [SerializeField] private Image nonPlayerImage; // UI image for Character B
    [SerializeField] private TextMeshProUGUI characterNameText; // UI text component for displaying character name
    [SerializeField] private TextMeshProUGUI dialogueText; // UI text component for displaying dialogue
    [SerializeField] private DialogueEntry[] dialogueEntries; // Array of dialogue entries



    private int currentEntryIndex = 0; // Tracks the current position in the dialogue array

    

    private void Start()
    {
        Time.timeScale = 0; // This freezes the game
                            // Disable any player inputs or other scripts that should not function during the dialogue
    

        // Display the first entry of dialogue when the scene starts, if any are available
        if (dialogueEntries.Length > 0)
        {
            DisplayDialogueEntry(currentEntryIndex);
        }
    }

    private void Update()
    {
        // Detect if the player has clicked to advance the dialogue
        if (Input.GetMouseButtonDown(0))
        {
            AdvanceDialogue();
        }
    }

    public void AdvanceDialogue()
    {
        currentEntryIndex++; // Move to the next dialogue entry

        // Check if there are more entries to display
        if (currentEntryIndex < dialogueEntries.Length)
        {
            DisplayDialogueEntry(currentEntryIndex);
        }
        else
        {
            EndDialogue(); // Call the end dialogue function if no more entries exist
        }
    }

    private void DisplayDialogueEntry(int index)
    {
        // Update the UI with the current dialogue entry's character name and text
        characterNameText.text = dialogueEntries[index].characterName;
        dialogueText.text = dialogueEntries[index].dialogueText;

        // Optionally adjust alignment based on the character speaking
        if (dialogueEntries[index].characterName == playerName)
        {
            characterNameText.alignment = TextAlignmentOptions.Left;
        }
        else
        {
            characterNameText.alignment = TextAlignmentOptions.Right;
        }

        // Update the character images for the current dialogue entry
        playerImage.sprite = dialogueEntries[index].playerSprite;
        nonPlayerImage.sprite = dialogueEntries[index].nonPlayerSprite;

        // Enable or disable image components based on whether sprites are assigned
        playerImage.enabled = dialogueEntries[index].playerSprite != null;
        nonPlayerImage.enabled = dialogueEntries[index].nonPlayerSprite != null;
    }

    private void EndDialogue()
    {
        // Perform any final actions when the dialogue sequence ends
        // For example, deactivate the dialogue UI, activate/deactivate game objects, etc.

        Time.timeScale = 1; // This resumes the game
                            // Re-enable any player inputs or other scripts that were disabled

        if (TriggerNPCTalk.playerHasItem == true)
        {
            //GameOver();
            //TriggerNPCTalk.ResetScene();
            TriggerNPCTalk.playerHasItem = false;
            TriggerNPCTalk.spokeToNPC = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        gameObject.SetActive(false); // Deactivate the dialogue UI canvas
    }
}
