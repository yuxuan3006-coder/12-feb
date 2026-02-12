using UnityEngine;

/// <summary>
/// Plays a sound while two colliders are touching.
/// Drag your audio clip in the Inspector.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class CollisionAudioPlayer : MonoBehaviour
{
    [Header("Audio Settings")]
    [Tooltip("Drag your metal-grinding / CNC sound here")]
    [SerializeField] private AudioClip collisionClip;

    [Tooltip("Volume (0-1)")]
    [Range(0f, 1f)]
    [SerializeField] private float volume = 1f;

    [Tooltip("Play one-shot or loop while colliding?")]
    [SerializeField] private bool loopWhileColliding = true;

    // Internal
    private AudioSource audioSource;
    private bool isColliding = false;

    void Awake()
    {
        // Get or add AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = collisionClip;
        audioSource.volume = volume;
        audioSource.loop = false; // We control looping manually
        audioSource.spatialBlend = 1f; // 3D sound (adjust as needed)
    }

    // Called when a collider enters this trigger/collider
    private void OnCollisionEnter(Collision collision)
    {
        TryPlaySound();
    }

    // Called every physics frame while colliders touch
    private void OnCollisionStay(Collision collision)
    {
        TryPlaySound();
    }

    // Called when contact ends
    private void OnCollisionExit(Collision collision)
    {
        TryStopSound();
    }

    // Optional: Also support Trigger colliders
    private void OnTriggerEnter(Collider other) => TryPlaySound();
    private void OnTriggerStay(Collider other) => TryPlaySound();
    private void OnTriggerExit(Collider other) => TryStopSound();

    private void TryPlaySound()
    {
        if (isColliding) return; // Already playing

        if (collisionClip == null)
        {
            Debug.LogWarning("No audio clip assigned!", this);
            return;
        }

        isColliding = true;

        if (loopWhileColliding)
        {
            audioSource.clip = collisionClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            audioSource.PlayOneShot(collisionClip, volume);
        }
    }

    private void TryStopSound()
    {
        if (!isColliding) return;

        isColliding = false;
        audioSource.Stop();
        audioSource.loop = false;
    }

    // Optional: Reset in case of scene reload
    private void OnDestroy()
    {
        TryStopSound();
    }
}