using System.Collections;
using UnityEngine;

public class PianoBehaviour : MonoBehaviour, IRaycastInteractable
{
    [SerializeField] private AudioClip correctAudio;
    [SerializeField] private GameObject door;
    [SerializeField] private AudioClip doorOpeningSound;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float targetAngle = 90f;

    private bool shouldOpen;
    private float rotatedAmount;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private bool _isSolutionEnabled;

    private void Start()
    {
        if (!door) return;
        initialRotation = door.transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, targetAngle, 0);
    }


    public void OnRaycastHit()
    {
        if (_isSolutionEnabled)
        {
            AudioSource.PlayClipAtPoint(correctAudio, transform.position);
            StartCoroutine(OpenDoorAfterAudio(correctAudio.length));
        }
        else
        {
            Debug.Log("Piano is not in the correct state yet.");
        }
    }

    private IEnumerator OpenDoorAfterAudio(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (doorOpeningSound)
            AudioSource.PlayClipAtPoint(doorOpeningSound, transform.position);
        shouldOpen = true;
    }

    private void Update()
    {
        if (!shouldOpen) return;
        door.transform.rotation = Quaternion.RotateTowards(
            door.transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
        if (Quaternion.Angle(door.transform.rotation, targetRotation) < 0.1f)
        {
            shouldOpen = false;
        }
    }
    
    public void EnableSolution()
    {
        _isSolutionEnabled = true;
    }
}