using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightConsumer : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private Image flashlightHudIcon;
    [SerializeField] private TextMeshProUGUI flashlightText;
    
    private void Awake()
    {
        if (!playerInventory)
        {
            Debug.LogError("PlayerInventory component not found");
        }
        if (!flashlightHudIcon)
        {
            Debug.LogError("Flashlight HUD Icon not assigned in the inspector.");
        }
        flashlightHudIcon.enabled = false;
        if (!flashlightText)
        {
            Debug.LogError("Flashlight Text not assigned in the inspector.");
        }
        flashlightText.enabled = false;
    }


    private void OnEnable()
    {
            playerInventory.OnItemAdded += HandleItemAdded;
    }
    
    private void OnDisable()
    {
            playerInventory.OnItemAdded -= HandleItemAdded;
    }
    
    
    private void HandleItemAdded(string item)
    {
        if (item != "Flashlight") return;
        EventBus.Publish(new DialogueEvent("An uv flashlight. This might come in handy."));
        EventBus.Publish(new DialogueEvent("I can probably use it to reveal hidden messages."));
        EventBus.Publish(new DialogueEvent("The hint mentioned something about a painting in the first floor."));
        EventBus.Publish(new DialogueEvent("I should find a way to remove the canvas before using the flashlight."));
        flashlightHudIcon.enabled = true;
        flashlightText.enabled = true;
        Destroy(gameObject);
    }
}
