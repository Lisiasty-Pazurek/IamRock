using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pet : MonoBehaviour //, IDropHandler 
{
    // Public variables for the pet's sprites and animation
    public Sprite happySprite;
    public Sprite sadSprite;
    public Animator animator;

    // Private variables for the pet's state
    public int health = 100;
    public int hunger = 0;
    public int thirst = 0;
    public int happiness = 100;


    // Method for updating the pet's sprite based on its happiness
    public void UpdateSprite()
    {
        if (happiness >= 50)
        {
            GetComponent<Image>().sprite = happySprite;
            animator.SetBool("isSad", false);
        }
        else
        {
            GetComponent<Image>().sprite = sadSprite;
            animator.SetBool("isSad", true);
        }
    }

    // Method for feeding the pet
    public void Feed()
    {
        if (hunger >= 25)
        {
            hunger -= 25;
            happiness += 10;
            UpdateSprite();
        }
    }

    // Method for hydrating the pet
    public void Hydrate()
    {
        if (thirst >= 25)
        {
            thirst -= 25;
            happiness += 10;
            UpdateSprite();
        }
    }

    // Method for playing with the pet
    public void Play()
    {
        if (happiness >= 25)
        {
            happiness += 25;
            UpdateSprite();
        }
    }

    // Method for updating the pet's state
    public void UpdateState(int newHealth, int newHunger, int newThirst, int newHappiness)
    {
        health = newHealth;
        hunger = newHunger;
        thirst = newThirst;
        happiness = newHappiness;
        UpdateSprite();
    }

    // public void OnDrop(PointerEventData eventData)
    // {
    //     Debug.Log ("Dropped object was: "  + eventData.pointerDrag);
    //     if (eventData.pointerDrag != null)
    //     {
    //         Debug.Log ("Dropped object was: "  + eventData.pointerDrag);
    //     }

    //     Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
    //     if (draggable != null)
    //     {
    //         if (draggable.isDroppedOn(this.gameObject))
    //         {
    //             if (draggable.gameObject.name.Contains("Food")) {Feed();}
    //             if (draggable.gameObject.name.Contains("Water")) {Hydrate();}
    //             if (draggable.gameObject.name.Contains("Toy")) {Play();}
    //         }
    //     }
    // }


}