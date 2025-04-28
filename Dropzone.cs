using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    public Color correctColor = Color.green; // The correct color when the right button is dropped
    public Color incorrectColor = Color.red; // The color when the wrong button is dropped

    private Image panelImage;

    void Start()
    {
        panelImage = GetComponent<Image>(); // Ensure the panel has an Image component
    }

    // This is called when a button is dropped on the panel
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped on panel!"); // Debugging line

        DragAndDropHandler droppedButton = eventData.pointerDrag.GetComponent<DragAndDropHandler>();
        
        if (droppedButton != null)
        {
            // If the dropped button is the correct one, make the panel green
            if (droppedButton.isCorrectButton)
            {
                panelImage.color = correctColor;
                Debug.Log("Correct Button Dropped"); // Debugging line
            }
            else
            {
                panelImage.color = incorrectColor;
                Debug.Log("Incorrect Button Dropped"); // Debugging line
            }
        }
    }
}














