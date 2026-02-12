using UnityEngine;

public class XR_ToolAnimator : MonoBehaviour
{
    public Transform spindle;
    public float spindleSpeed = 200f;
    public ParticleSystem cuttingParticles;

    private bool spinning = false;

    void Update()
    {
        if (spindle != null && spinning)
        {
            spindle.Rotate(Vector3.forward * spindleSpeed * Time.deltaTime);
        }
    }

    public void StartSpindle(bool state)
    {
        spinning = state;
        if (cuttingParticles != null)
        {
            if (state && !cuttingParticles.isPlaying) cuttingParticles.Play();
            else if (!state && cuttingParticles.isPlaying) cuttingParticles.Stop();
        }
    }
}
