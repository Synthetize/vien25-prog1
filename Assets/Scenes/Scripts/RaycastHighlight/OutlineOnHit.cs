using UnityEngine;

public class ObjectHitReg : MonoBehaviour, IRaycastHighlightable
{

    [SerializeField] private Color outlineColor = Color.red;
    [SerializeField] private float outlineWidth = 10f;

    public void OnRaycastHit()
    {
        var outline = GetComponent<Outline>();
        if (outline != null) return; // Already has an outline

        outline = gameObject.AddComponent<Outline>();
        outline.OutlineColor = outlineColor;
        outline.OutlineWidth = outlineWidth;
    }

    public void OnRaycastExit()
    {
        var outline = GetComponent<Outline>();
        if (outline != null)
            Destroy(outline);
    }

}
