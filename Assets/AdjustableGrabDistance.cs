using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class AdjustableGrabDistance : MonoBehaviour
{
    public InputActionProperty adjustDistanceAction;
    public float distanceSpeed = 0.3f;
    public float minDistance = 0.2f;
    public float maxDistance = 1.5f;

    private XRGrabInteractable grabInteractable;
    private Transform attachTransform;
    private float currentDistance;

    
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        attachTransform = grabInteractable.attachTransform;
    }

   
    void OnEnable()
    {
        adjustDistanceAction.action.Enable();
    }

    void OnDisable()
    {
        adjustDistanceAction.action.Disable();
    }

    void Update()
    {
        if (!grabInteractable.isSelected) 
            return;

        float input = adjustDistanceAction.action.ReadValue<float>();
        if (Mathf.Abs(input) < 0.1f) 
            return;

        currentDistance += input * distanceSpeed * Time.deltaTime;
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        attachTransform.localPosition = Vector3.forward * currentDistance;
    }

}
