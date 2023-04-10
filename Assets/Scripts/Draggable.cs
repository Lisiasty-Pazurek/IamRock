using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    
    private Vector2 startPosition;
    public bool isDragging = false;
    

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = rectTransform.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;        
        rectTransform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)   {    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        rectTransform.position = Input.mousePosition;
        Debug.Log("Dropping shit, is it a drop?"+ eventData.pointerDrag);
    }

    // public bool isDroppedOn(GameObject target)
    // {
    //     Debug.Log("Dropped on and checking");
    //     BoxCollider2D collider = GetComponent<BoxCollider2D>();
    //     BoxCollider2D targetCollider = target.GetComponent<BoxCollider2D>();
        
    //     if (collider == null || targetCollider == null)
    //     {
    //         return false;
    //     }
    //     else 
    //     Debug.Log(targetCollider.name);

    //     return collider.bounds.Intersects(targetCollider.bounds);

    // }
    
    void FixedUpdate()
    {
        if (isDragging)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log ("Draggable Collider collided " + other.gameObject.name);
        if (other.gameObject.GetComponent<Pet>() != null) 
        {
            if (this.gameObject.name.Contains("Food")) 
            {   other.gameObject.GetComponent<Pet>().Feed(); 
                Destroy(this.gameObject);
            }
            if (this.gameObject.name.Contains("Water")) 
            {
                other.gameObject.GetComponent<Pet>().Hydrate(); 
                Destroy(this.gameObject);
            }
            if (this.gameObject.name.Contains("Toy")) 
            {
                other.gameObject.GetComponent<Pet>().Play(); 
                Destroy(this.gameObject);
            }
        }

    }
    
}
