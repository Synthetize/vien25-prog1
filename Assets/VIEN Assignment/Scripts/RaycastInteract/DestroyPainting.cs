using UnityEngine;

public class DestroyPainting : MonoBehaviour, IRaycastInteractable
{
    public void OnRaycastHit()
    {
  
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
