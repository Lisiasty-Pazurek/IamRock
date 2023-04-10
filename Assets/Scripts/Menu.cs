using UnityEngine;


public class Menu : MonoBehaviour
 {
    public GameObject food;
    public GameObject water;
    public GameObject toy;

    private GameObject draggingObject;

    public Transform spawnablesTransform;

    // Method for creating a new draggable object
    private GameObject CreateDraggable(GameObject prefab)
    {
        // Instantiate the prefab and add a drag component to it
        GameObject obj = Instantiate(prefab, spawnablesTransform);
        obj.AddComponent<Draggable>();

        return obj;
    }

    // Method for handling the food button click
    public void OnFoodButtonClick()
    {
        draggingObject = CreateDraggable(food);
    }

    // Method for handling the water button click
    public void OnWaterButtonClick()
    {
        draggingObject = CreateDraggable(water);
    }

    // Method for handling the toy button click
    public void OnToyButtonClick()
    {
        draggingObject = CreateDraggable(toy);
    }

}