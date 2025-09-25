using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightConsumer : MonoBehaviour
{
    private PlayerInventory _playerInventory;
    [SerializeField] private Image flashlightHudIcon;
    [SerializeField] private TextMeshProUGUI flashlightText;
    
    private void Awake()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInventory>();
        if (!_playerInventory)
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
            _playerInventory.OnItemAdded += HandleItemAdded;
    }
    
    private void OnDisable()
    {
            _playerInventory.OnItemAdded -= HandleItemAdded;
    }
    
    
    private void HandleItemAdded(string item)
    {
        if (item != "Flashlight") return;
        flashlightHudIcon.enabled = true;
        flashlightText.enabled = true;
        Destroy(gameObject);
    }
}
