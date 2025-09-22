using UnityEngine;
using UnityEngine.InputSystem;

public class UvFlashlight : MonoBehaviour
{
    [SerializeField] private InputActionReference toggleFlashlightInput;
    private bool _isOn;
    [SerializeField] private AudioClip audioClip;

    private Light _light;
    private PlayerInventory _playerInventory;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _light.enabled = false;
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInventory>();
    }
    
    private void OnEnable()
    {
        toggleFlashlightInput.action.performed += ToggleFlashlight;
    }
    
    private void OnDisable()
    {
        toggleFlashlightInput.action.performed -= ToggleFlashlight;
    }

    private void ToggleFlashlight(InputAction.CallbackContext obj)
    {
        if(!_playerInventory.HasItem("Flashlight")) return; 
        _isOn = !_isOn;
        _light.enabled = _isOn;
        AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.1f);
    }
}
