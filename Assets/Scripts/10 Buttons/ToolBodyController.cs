using UnityEngine;

public class ToolBodyController : MonoBehaviour
{
    public EmergencyStop emergencyStop;
    public Animator animator;
    
    public GameObject metalBlock;
    public GameObject finalWorkpiece;
    public GameObject blockArrows;
    public GameObject toolArrows;
    
    private bool hasSwapped = false;
    private bool arrowsShouldStayHidden = false;  // NEW FLAG

    public void StartOrResume()
    {
        animator.enabled = true;
        animator.SetBool("IsRunning", true);
        animator.speed = 1f;
        
        hasSwapped = false;
        arrowsShouldStayHidden = true;  // Keep arrows hidden during cutting
    }

    public void PauseOrStop()
    {
        animator.speed = 0f;
    }

    public void ResetTool()
    {
        animator.speed = 1f;
        animator.SetBool("IsRunning", false);
        animator.SetTrigger("ResetTrigger");
        
        metalBlock.SetActive(true);
        finalWorkpiece.SetActive(false);
        hasSwapped = false;
        arrowsShouldStayHidden = false;  // Allow arrows to appear again when resetting
    }
    
    void Update()
    {
        // Keep forcing arrows off if they should stay hidden
        if (arrowsShouldStayHidden)
        {
            if (blockArrows != null && blockArrows.activeSelf) 
                blockArrows.SetActive(false);
            if (toolArrows != null && toolArrows.activeSelf) 
                toolArrows.SetActive(false);
        }
        
        if (animator.GetBool("IsRunning") && !hasSwapped)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            
            if (stateInfo.IsName("MikronStart") && stateInfo.normalizedTime >= 0.99f && !animator.IsInTransition(0))
            {
                SwapToFinalWorkpiece();
            }
        }
    }
    
    void SwapToFinalWorkpiece()
    {
        Debug.Log("Swapping to final workpiece!");
        metalBlock.SetActive(false);
        finalWorkpiece.SetActive(true);
        
        if (blockArrows != null) blockArrows.SetActive(false);
        if (toolArrows != null) toolArrows.SetActive(false);
        
        hasSwapped = true;
    }
}