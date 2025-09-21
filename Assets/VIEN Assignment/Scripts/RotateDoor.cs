using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public bool isOpen = false;
    public float openAngle = 90f;
    public float speed = 2f;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }

    public void OpenDoor()
    {
        Debug.Log("Door opened");
        if(!isOpen)
            isOpen = true;
        else
            isOpen = false;

    }

    void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * speed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * speed);
        }
    }
}