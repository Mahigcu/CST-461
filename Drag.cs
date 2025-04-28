using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool isCorrectButton = false; // Set this to true for the correct button, false for others

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // This is called when you drag the button
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        canvasGroup.alpha = 0.6f; // Make the button semi-transparent when dragging
        canvasGroup.blocksRaycasts = false; // Allow for dropping
    }

    // This is called when you stop dragging the button
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Make the button fully visible again
        canvasGroup.blocksRaycasts = true; // Re-enable interaction after drag
        Debug.Log("Drag Ended"); // Debugging line
    }
}
















