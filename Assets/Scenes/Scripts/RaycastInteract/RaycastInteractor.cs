using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;



public class RaycastInteractor : MonoBehaviour
{

    private InputSystem_Actions controls;
    [SerializeField] private float distance;
    public float maxDistance = 2f;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance))
        {
            distance = hit.distance;
            if (controls.Player.Interact.triggered)
            {
                Debug.Log("Interacted with: " + hit.collider.name);
                var target = hit.collider.GetComponent<IRaycastInteractable>();
                target?.OnRaycastHit();
            }
        }

    }
}
