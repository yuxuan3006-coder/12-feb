using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class MikronTutorialReset : MonoBehaviour
{
    [Header("Objects to Reset")]
    public GameObject metalBlockB;
    public GameObject twoPartMainTool;
    public GameObject finalWorkpiece;
    
    [Header("Arrow Indicators")]
    public GameObject blockArrows;
    public GameObject toolArrows;
    
    [Header("Socket Pointers/Indicators")]
    public GameObject mikronIndicators;  // ADD THIS - drag your socket pointers here
    
    [Header("Tool Holder Socket")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor toolHolderSocket;  // ADD THIS - the socket that holds the tool
    
    [Header("Optional: Other objects")]
    public ToolBodyController toolBodyController;
    
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
        if (metalBlockB != null)
        {
            metalBlockInitialPos = metalBlockB.transform.position;
            metalBlockInitialRot = metalBlockB.transform.rotation;
            metalBlockInitialParent = metalBlockB.transform.parent;
        }
        
        if (twoPartMainTool != null)
        {
            toolInitialPos = twoPartMainTool.transform.position;
            toolInitialRot = twoPartMainTool.transform.rotation;
            toolInitialParent = twoPartMainTool.transform.parent;
        }
        
        if (finalWorkpiece != null)
        {
            workpieceInitialPos = finalWorkpiece.transform.position;
            workpieceInitialRot = finalWorkpiece.transform.rotation;
            workpieceInitialParent = finalWorkpiece.transform.parent;
        }
    }
    
    public void ResetMikronTutorial()
    {
        Debug.Log("Resetting Mikron Tutorial...");
        
        // FORCE RELEASE TOOL FROM SOCKET FIRST
        if (toolHolderSocket != null && toolHolderSocket.hasSelection)
        {
            toolHolderSocket.interactionManager.SelectExit(toolHolderSocket, toolHolderSocket.interactablesSelected[0]);
        }
        
        // Reset Metal Block B
        if (metalBlockB != null)
        {
            var grabInteractable = metalBlockB.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.SelectExit(grabInteractable.interactorsSelecting[0], grabInteractable);
            }
            
            metalBlockB.SetActive(true);
            metalBlockB.transform.SetParent(metalBlockInitialParent);
            metalBlockB.transform.position = metalBlockInitialPos;
            metalBlockB.transform.rotation = metalBlockInitialRot;
            
            var rb = metalBlockB.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
        // Reset Tool
        if (twoPartMainTool != null)
        {
            var grabInteractable = twoPartMainTool.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.SelectExit(grabInteractable.interactorsSelecting[0], grabInteractable);
            }
            
            twoPartMainTool.SetActive(true);
            twoPartMainTool.transform.SetParent(toolInitialParent);
            twoPartMainTool.transform.position = toolInitialPos;
            twoPartMainTool.transform.rotation = toolInitialRot;
            
            var rb = twoPartMainTool.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        
        // Reset Final Workpiece
        if (finalWorkpiece != null)
        {
            var grabInteractable = finalWorkpiece.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.SelectExit(grabInteractable.interactorsSelecting[0], grabInteractable);
            }
            
            finalWorkpiece.SetActive(false);
            finalWorkpiece.transform.SetParent(workpieceInitialParent);
            finalWorkpiece.transform.position = workpieceInitialPos;
            finalWorkpiece.transform.rotation = workpieceInitialRot;
        }
        
        // Reset arrows - start hidden
        if (blockArrows != null) blockArrows.SetActive(false);
        if (toolArrows != null) toolArrows.SetActive(false);
        
        // Reset Mikron socket indicators - make them visible again
        if (mikronIndicators != null) mikronIndicators.SetActive(true);
        
        // Reset the cutting animation controller
        if (toolBodyController != null)
        {
            toolBodyController.ResetTool();
        }
    }
}