using UnityEngine;
using UnityEngine.UI;

public class ButtonReveal : MonoBehaviour
{
    [Header("UI Elements")]
    public Button button1;    // The first button (to reveal the second button)
    public Button button2;    // The second button (initially hidden)

    void Start()
    {
        // Initially hide Button 2 by disabling it
        if (button2 != null)
        {
            button2.gameObject.SetActive(false);  // Hide the second button at the start
        }
        else
        {
            Debug.LogError("Button 2 reference is not assigned.");
        }

        // Add listener to Button 1's OnClick event
        if (button1 != null)
        {
            button1.onClick.AddListener(ShowButton2);  // Show Button 2 when Button 1 is clicked
        }
        else
        {
            Debug.LogError("Button 1 reference is not assigned.");
        }
    }

    // This method will be called when Button 1 is clicked
    public void ShowButton2()
    {
        if (button2 != null)
        {
            button2.gameObject.SetActive(true);  // Make Button 2 visible when Button 1 is clicked
        }
        else
        {
            Debug.LogError("Button 2 reference is not assigned.");
        }
    }
}







