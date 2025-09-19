using UnityEngine;

public class BooksInteraction : MonoBehaviour, IRaycastInteractable
{

    public void OnRaycastHit()
    {
        Debug.Log("Interacted with book: " + gameObject.name);
        // Add your interaction logic here, e.g., open a book UI, display information, etc.
    }
}
