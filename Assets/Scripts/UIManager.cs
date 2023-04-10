using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Public variables for UI elements
    public Text healthText;
    public Text hungerText;
    public Text thirstText;
    public Text happinessText;

    // Method for updating the UI with the pet's state
    public void UpdateUI(int health, int hunger, int thirst, int happiness)
    {
        healthText.text = "Health: " + health;
        hungerText.text = "Hunger: " + hunger;
        thirstText.text = "Thirst: " + thirst;
        happinessText.text = "Happiness: " + happiness;
    }
}