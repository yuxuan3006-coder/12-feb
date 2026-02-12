using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DMGTutorialReset : MonoBehaviour
{
    [Header("Objects to Reset")]
    public GameObject metalBlockTen;
    public GameObject threadTool;
    public GameObject finalWorkpiece;

    [Header("Socket Pointers/Indicators")]
    public GameObject dmgIndicators;  // ADD THIS - drag your socket pointers here}
    
    [Header("Arrow Indicators")]
    public GameObject blockArrows;
    public GameObject toolArrows;
    
    [Header("Optional: Other objects")]
    public TurretController turretController;  // Or whatever controls DMG's cutting animation
    
    // Store initial states
    private Vector3 metalBlockInitialPos;
    private Quaternion metalBlockInitialRot;
    private Transform metalBlockInitialParent;
    
    private Vector3 toolInitialPos;
    private Quaternion toolInitialRot;
    private Transform toolInitialParent;
    
    private Vector3 workpieceInitialPos;
    private Quaternion workpieceInitialRot;
    private Transform workpieceInitialParent;
    
    void Start()
    {
        SaveInitialState();
    }
    
    void SaveInitialState()
    {
        if (metalBlockTen != null)
        {
            metalBlockInitialPos = metalBlockTen.transform.position;
            metalBlockInitialRot = metalBlockTen.transform.rotation;
            metalBlockInitialParent = metalBlockTen.transform.parent;
        }
        
        if (threadTool != null)
        {
            toolInitialPos = threadTool.transform.position;
            toolInitialRot = threadTool.transform.rotation;
            toolInitialParent = threadTool.transform.parent;
        }
        
        if (finalWorkpiece != null)
        {
            workpieceInitialPos = finalWorkpiece.transform.position;
            workpieceInitialRot = finalWorkpiece.transform.rotation;
            workpieceInitialParent = finalWorkpiece.transform.parent;
        }
    }
    
    public void ResetDMGTutorial()
    {
        Debug.Log("Resetting DMG Tutorial...");
        
        // Reset Metal Block B
        if (metalBlockTen != null)
        {
            // Force release if being held
            var grabInteractable = metalBlockTen.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)grabInteractable);
            }
            
            metalBlockTen.SetActive(true);
            metalBlockTen.transform.SetParent(metalBlockInitialParent);
            metalBlockTen.transform.position = metalBlockInitialPos;
            metalBlockTen.transform.rotation = metalBlockInitialRot;
            
            // Reset rigidbody if it has one
            var rb = metalBlockTen.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
        // Reset Tool - FORCE detach from tool holder
        if (threadTool != null)
        {
            // Force release if being held
            var grabInteractable = threadTool.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)grabInteractable);
            }
            
            threadTool.SetActive(true);
            threadTool.transform.SetParent(toolInitialParent);
            threadTool.transform.position = toolInitialPos;
            threadTool.transform.rotation = toolInitialRot;
            
            // Reset rigidbody
            var rb = threadTool.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
        // Reset Final Workpiece
        if (finalWorkpiece != null)
        {
            // Force release if being held
            var grabInteractable = finalWorkpiece.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)grabInteractable);
            }
            
            finalWorkpiece.SetActive(false);
            finalWorkpiece.transform.SetParent(workpieceInitialParent);
            finalWorkpiece.transform.position = workpieceInitialPos;
            finalWorkpiece.transform.rotation = workpieceInitialRot;
        }
        
        // Reset arrows - START HIDDEN
        if (blockArrows != null) blockArrows.SetActive(false);
        if (toolArrows != null) toolArrows.SetActive(false);

        if (dmgIndicators != null) dmgIndicators.SetActive(true);  // SHOW the socket pointers again
        
        // Reset the cutting animation controller
        if (turretController != null)
        {
            turretController.ResetTool();
        }
    }
}