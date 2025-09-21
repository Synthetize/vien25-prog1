using Seagull.Interior_01;
using UnityEngine;

public class WcInteraction : MonoBehaviour, IRaycastInteractable
{
    public AudioClip flushSound;
    public void OnRaycastHit()
    {
        AudioSource.PlayClipAtPoint(flushSound, Camera.main.transform.position);
    }
}

