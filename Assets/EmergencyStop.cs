using System;
using UnityEngine;

public class EmergencyStop : MonoBehaviour
{
    public static bool IsEmergencyStopped = false;

    [Header("Machine References")]
    public GameObject[] machineMotionObjects; // axes, spindle, animations
    public MonoBehaviour[] controlScripts;     // scripts that move machine or accept input

    public void PressEmergencyStop()
    {
        if (IsEmergencyStopped)
            return;

        IsEmergencyStopped = true;

        // Stop motion
        foreach (GameObject obj in machineMotionObjects)
        {
            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }

        // Disable control scripts
        foreach (MonoBehaviour script in controlScripts)
        {
            script.enabled = false;
        }

        Debug.Log("EMERGENCY STOP ACTIVATED");
    }

    internal bool IsEmergencyActive()
    {
        throw new NotImplementedException();
    }

}
