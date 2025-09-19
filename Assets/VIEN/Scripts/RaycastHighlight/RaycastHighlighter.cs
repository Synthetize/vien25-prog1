using UnityEngine;

public class RaycastHighlighter : MonoBehaviour
{
    public float maxDistance = 10f;
    [SerializeField] private float toTargetDistance;

    private GameObject lastHitGameObject;
    private IRaycastHighlightable lastHighlightable;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitObject, maxDistance))
        {
            if (!hitObject.collider.TryGetComponent<IRaycastHighlightable>(out var highlightable))
            {
                DeselectLastObject();
                return;
            }
            if (lastHitGameObject == hitObject.collider.gameObject) return;
            DeselectLastObject();
            lastHitGameObject = hitObject.collider.gameObject;
            lastHighlightable = highlightable;
            lastHighlightable.OnRaycastHit();
        }
        else
        {
            DeselectLastObject();
        }

    }
    
    private void DeselectLastObject()
    {
        if (!lastHitGameObject) return;

        lastHighlightable?.OnRaycastExit();

        lastHitGameObject = null;
        lastHighlightable = null;
    }
}