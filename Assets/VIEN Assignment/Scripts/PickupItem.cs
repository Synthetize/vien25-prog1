using UnityEngine;

namespace VIEN_Assignment.Scripts
{
    public class PickupItem: MonoBehaviour, IRaycastInteractable
    {
        
        private PlayerInventory _playerInventory;
        
        private void Awake()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInventory>();
            if (!_playerInventory)
            {
                Debug.LogError("PlayerInventory component not found");
            }
        }
        
        public void OnRaycastHit()
        {
            _playerInventory.AddItem(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}