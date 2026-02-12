using UnityEngine;
using System.Collections;

public class CNC_MachineController : MonoBehaviour
{
    [Header("Machine Components")]
    public Transform rotaryTable;   // Assign in Inspector
    public Transform spindleHead;   // Assign in Inspector
    public Transform tool;          // Assign in Inspector

    [Header("Motion Settings")]
    public float spindleSpeed = 360f;   // degrees per second
    public float rotationSpeed = 30f;   // table rotation speed

    private bool machineRunning = false;
    private Coroutine spinRoutine;

    public void StartMachine()
    {
        if (!machineRunning)
        {
            machineRunning = true;
            spinRoutine = StartCoroutine(RunMachine());
            Debug.Log("✅ Machine Started");
        }
    }

    public void StopMachine()
    {
        if (machineRunning)
        {
            machineRunning = false;
            if (spinRoutine != null) StopCoroutine(spinRoutine);
            Debug.Log("🛑 Machine Stopped");
        }
    }

    private IEnumerator RunMachine()
    {
        while (machineRunning)
        {
            // Simulate spindle spinning
            if (tool != null)
                tool.Rotate(Vector3.forward, spindleSpeed * Time.deltaTime, Space.Self);

            // Optional: rotate rotary table
            if (rotaryTable != null)
                rotaryTable.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

            yield return null;
        }
    }
}
