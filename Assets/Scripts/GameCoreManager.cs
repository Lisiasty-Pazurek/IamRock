using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameCoreManager : MonoBehaviour
{
    // Public variables for the pet and UI managers
    public Pet pet;
    public UIManager uiManager;   
    public bool gameRunning = false;
    
    // Public events for game state changes

    
    // Public variables for the pet's initial state
    public int initialHealth = 100;
    public int initialHunger = 50;
    public int initialThirst = 50;
    public int initialHappiness = 50;

    // Public variables for the pet's state change rates
    public float hungerRate = 1f;
    public float thirstRate = 1f;
    public float happinessRate = 2f;

    // Method for starting the game
    public void StartGame()
    {
        Debug.Log("Starting Game");
        gameRunning = true;
        StartCoroutine(GameLoop());
        
    }
    
    // Method for ending the game
    public void EndGame()
    {
        gameRunning = false;

    }
    
    // Coroutine for the game loop
    private IEnumerator GameLoop()
    {
        Debug.Log("Starting Game Coroutine");
        InitializePetState();
        uiManager.UpdateUI(pet.health, pet.hunger, pet.thirst, pet.happiness);

        while (gameRunning)
        {
            Debug.Log("Tick");
            yield return new WaitForSeconds(1f);
            UpdatePetState();
        }
    }
    
    // Method for initializing the pet's state
    private void InitializePetState()
    {
        pet.health = initialHealth;
        pet.hunger = initialHunger;
        pet.thirst = initialThirst;
        pet.happiness = initialHappiness;
    }
    
    // Method for updating the pet's state
    private void UpdatePetState()
    {
        // Update the hunger state
        pet.hunger += Mathf.RoundToInt(hungerRate);
        if (pet.hunger < 0)
        {
            pet.hunger = 0;
        }

        // Update the thirst state
        pet.thirst += Mathf.RoundToInt(thirstRate);
        if (pet.thirst < 0)
        {
            pet.thirst = 0;
        }

        // Update the happiness state
        pet.happiness -= Mathf.RoundToInt(happinessRate);
        if (pet.happiness < 0)
        {
            pet.happiness = 0;
        }

        pet.UpdateSprite();

        // Update the UI with the pet's current state
        uiManager.UpdateUI(pet.health, pet.hunger, pet.thirst, pet.happiness);

        // Check if the pet has fainted
        if (pet.hunger >= 100 || pet.thirst >= 100 || pet.happiness <= 0)
        {
            EndGame();
        }
    }
}