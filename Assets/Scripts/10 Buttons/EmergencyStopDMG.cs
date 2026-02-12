using UnityEngine;

public class EmergencyStopDMG : MonoBehaviour

{
    public Animator toolAnimator;
    public GameObject machineLights;

    private bool emergencyActive = false;

    public void PressEmergencyStop()
    {
        if (emergencyActive) return;

        emergencyActive = true;

        // Stop all motion immediately
        toolAnimator.speed = 0f;

        // Cut machine power
        if (machineLights != null)
            machineLights.SetActive(false);

        Debug.Log("EMERGENCY STOP ACTIVATED");
    }

    public void ResetEmergencyStop()
    {
        if (!emergencyActive) return;

        emergencyActive = false;

        // Restore power
        if (machineLights != null)
            machineLights.SetActive(true);

        Debug.Log("Emergency Stop Reset. Machine still idle.");
    }

    public bool IsEmergencyActive()
    {
        return emergencyActive;
    }
}
