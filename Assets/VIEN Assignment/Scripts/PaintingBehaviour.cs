using UnityEngine;

public class PaintingBehaviour : MonoBehaviour, IRaycastInteractable
{
    private Canvas _canvas;
    [SerializeField] private AudioClip cutSound;
    
    private void Start()
    {
        _canvas = GetComponentInChildren<Canvas>();
        if (!_canvas)
        {
            Debug.LogError("No Canvas for painting assigned in the inspector.");
        }
        if (!cutSound)
        {
            Debug.LogError("No cut sound assigned in the inspector.");
        }
    }
    
    public void OnRaycastHit()
    {
        Destroy(_canvas.gameObject);
        AudioSource.PlayClipAtPoint(cutSound, transform.position, 0.1f);
    }
}
