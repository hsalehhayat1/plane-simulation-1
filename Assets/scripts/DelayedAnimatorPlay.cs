using System.Collections;
using UnityEngine;

public class DelayedAnimatorPlay : MonoBehaviour
{
    public Animator animator;           
    public string triggerName = "PlaySit";
    public float delay = 30f;            
    public bool useRealtime = false;     

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("[DelayedAnimatorPlay] No Animator found on " + gameObject.name);
            return;
        }

        
        if (!animator.enabled) animator.enabled = true;

        StartCoroutine(PlayAfterDelay());
    }

    IEnumerator PlayAfterDelay()
    {
        if (useRealtime)
            yield return new WaitForSecondsRealtime(delay);
        else
            yield return new WaitForSeconds(delay);

        
        animator.SetTrigger(triggerName);
        Debug.Log($"[{name}] Triggered animation '{triggerName}' after {delay} seconds.");
    }
}
