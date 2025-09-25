using UnityEngine;

namespace VIEN_Assignment.Scripts
{
    public class PickupItem: MonoBehaviour, IRaycastInteractable
    {
        
        [SerializeField] private PlayerInventory playerInventory;
        
        private void Awake()
        {
            //playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
            if (!playerInventory)
            {
                Debug.LogError("PlayerInventory component not found");
            }
        }
        
        public void OnRaycastHit()
        {
            playerInventory.AddItem(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}