using UnityEngine;

public class RainEnabler : MonoBehaviour
{
    public GameObject targetObject; 
    public float raycastDistance = 100f; 

    void Start()
    {
        targetObject.SetActive(false);
    }

    private void Update()
    {
        Vector3 rayOrigin = transform.position + new Vector3(0, 0.1f, 0);

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, Vector3.up, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("House"))
            {
                if (targetObject.activeSelf)
                {
                    Debug.Log("Deactivating Rain");
                    targetObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Activating Rain");
                if (!targetObject.activeSelf)
                {
                    targetObject.SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Activating Rain");
            if (!targetObject.activeSelf)
            {
                targetObject.SetActive(true);
            }
        }
    }
}
