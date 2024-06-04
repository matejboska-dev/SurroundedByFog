using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for scene management

public class Door : MonoBehaviour
{
    public GameObject[] collectibles;
    public Text messageText; // Reference to the UI Text element
    public string message = "Press 'E' to win!"; // Message to display

    private bool isOpen = false;
    private bool playerInTrigger = false; // Track if the player is in the trigger zone

    void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            playerInTrigger = true; // Player has entered the trigger zone
            if (CheckCollectibles())
            {
                ShowMessage(message); // Display the message
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false; // Player has exited the trigger zone
            ShowMessage(""); // Clear the message
        }
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (CheckCollectibles())
            {
                SwitchToWinScene(); // Switch to the WinScene
            }
        }
    }

    bool CheckCollectibles()
    {
        foreach (GameObject collectible in collectibles)
        {
            if (collectible != null)
            {
                return false; // At least one collectible is still present
            }
        }
        return true; // All collectibles have been collected
    }

    void OpenDoor()
    {
        Debug.Log("Door is open!");
        isOpen = true;
    }

    void ShowMessage(string text)
    {
        if (messageText != null)
        {
            messageText.text = text; // Update the text element with the message
        }
        else
        {
            Debug.LogWarning("Message Text is not assigned!");
        }
    }

    void SwitchToWinScene()
    {
        SceneManager.LoadScene("WinScene"); // Switch to the WinScene
    }
}
