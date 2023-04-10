using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    // Public events for feeding, hydrating, and playing with the pet
    public UnityEvent onFeed;
    public UnityEvent onHydrate;
    public UnityEvent onPlay;

    // Method for handling feed input
    public void FeedInput()
    {
        onFeed.Invoke();
    }

    // Method for handling hydrate input
    public void HydrateInput()
    {
        onHydrate.Invoke();
    }

    // Method for handling play input
    public void PlayInput()
    {
        onPlay.Invoke();
    }
}