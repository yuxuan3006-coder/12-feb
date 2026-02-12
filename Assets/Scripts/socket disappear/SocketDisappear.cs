using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketDisappear : MonoBehaviour
{
    public GameObject MikPlatInd; // Assign the object to disappear in Inspector

    public void HideObject(SelectEnterEventArgs args)
    {
        if (MikPlatInd != null)
        {
            MikPlatInd.SetActive(false); // Disables the object [1, 2]
        }
    }
    public GameObject MikToolInd; // Assign the object to disappear in Inspector

    public void HideObject2(SelectEnterEventArgs args)
    {
        if (MikToolInd != null)
        {
            MikToolInd.SetActive(false); // Disables the object [1, 2]
        }
    }
    public GameObject DMGPlatInd; // Assign the object to disappear in Inspector

    public void HideObject3(SelectEnterEventArgs args)
    {
        if (DMGPlatInd != null)
        {
            DMGPlatInd.SetActive(false); // Disables the object [1, 2]
        }
    }
    public GameObject DMGToolInd; // Assign the object to disappear in Inspector

    public void HideObject4(SelectEnterEventArgs args)
    {
        if (DMGToolInd != null)
        {
            DMGToolInd.SetActive(false); // Disables the object [1, 2]
        }
    }
}
