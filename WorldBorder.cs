using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorderScript : MonoBehaviour
{
    // The tag of the object that will trigger the pause
    public string triggerObjectTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object exiting the border has the correct tag
        Debug.Log("Exited trigger with object: " + other.gameObject.name);
        if (other.CompareTag(triggerObjectTag))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        // Pause the game by setting time scale to 0
        Time.timeScale = 0;
        Debug.Log("Game Paused");
    }

    // Optional: Resume game function
    public void ResumeGame()
    {
        // Resume the game by setting time scale back to 1
        Time.timeScale = 1;
    }
}
