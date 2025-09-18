using UnityEngine;

public class RaycastHighlighter : MonoBehaviour
{
    public float maxDistance = 10f;
    [SerializeField] float toTargetDistance;

    private GameObject lastHitGameObject;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitObject,
                maxDistance))
        {
             var hitGameObject = hitObject.collider.gameObject;
            if (lastHitGameObject == hitGameObject) return;
            DeselectLastObject();
            // Select the new object
            var colliderScript = hitGameObject.GetComponent<IRaycastHighlightable>();
            colliderScript?.OnRaycastHit();
            lastHitGameObject = hitGameObject;
        }
        else
        {
            //if nothing is hit, deselect the last object
            DeselectLastObject();
        }
    }
    
    private void DeselectLastObject()
    {
        if (!lastHitGameObject) return;
        var lastScript = lastHitGameObject.GetComponent<IRaycastHighlightable>();
        lastScript?.OnRaycastExit();
        lastHitGameObject = null;
    }
}