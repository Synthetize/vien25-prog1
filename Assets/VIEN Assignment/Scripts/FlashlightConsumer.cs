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
        EventBus.Publish(new DialogueEvent("A uv light flashlight. This might come in handy."));
        EventBus.Publish(new DialogueEvent("Probably I can use (F) it to reveal hidden messages."));
        flashlightHudIcon.enabled = true;
        flashlightText.enabled = true;
        Destroy(gameObject);
    }
}
