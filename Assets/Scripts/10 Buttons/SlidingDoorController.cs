using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    public Animator doorAnimator;

    public void OpenDoor()
    {
        Debug.Log("OPEN button pressed");
        doorAnimator.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        Debug.Log("CLOSE button pressed");
        doorAnimator.SetBool("isOpen", false);
    }

}
