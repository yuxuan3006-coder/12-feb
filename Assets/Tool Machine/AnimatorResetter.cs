using UnityEngine;

public class AnimatorResetter : MonoBehaviour
{
    public Animator animator;

    // 1. Reset & disable animator
    public void ResetAndDisable()
    {
        animator.Rebind();     // Reset to default state
        animator.Update(0f);   // Apply reset
        animator.speed = 0f;   // Freeze
        animator.enabled = false;
    }

    // 2. Re-enable and auto-play default animation
    public void EnableAndPlay()
    {
        animator.enabled = true;  // turn animator back on
        animator.speed = 1f;      // allow it to play
        animator.Play(0, 0, 0f);  // play default state from the beginning
    }
}
