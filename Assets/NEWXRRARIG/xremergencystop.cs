using UnityEngine;

public class XR_EStopManager : MonoBehaviour
{
    public XR_CNCControlPanel cncControl;

    public void OnEStopPressed()
    {
        if (cncControl != null)
        {
            cncControl.SendMessage("StopMotion");
            Debug.Log("🚨 EMERGENCY STOP ACTIVATED!");
        }
    }
}
