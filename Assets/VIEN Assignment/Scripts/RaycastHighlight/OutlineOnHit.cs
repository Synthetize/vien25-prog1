using UnityEngine;

public class ObjectHitReg : MonoBehaviour, IRaycastHighlightable
{

    [SerializeField] private Color outlineColor = Color.red;
    [SerializeField] private float outlineWidth = 10f;
    private Outline _outline;
    
    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();
        _outline.enabled = false;
        _outline.OutlineColor = outlineColor;
        _outline.OutlineWidth = outlineWidth;
    }


    public void OnRaycastHit()
    {
        if (!_outline.enabled) _outline.enabled = true;
    }

    public void OnRaycastExit()
    {
        if (_outline.enabled) _outline.enabled = false;
    }

}
