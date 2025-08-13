using System.Collections;
using UnityEngine;
using TMPro; 

public class EnableAnimatorAfterDelay : MonoBehaviour
{
    public Animator animator;       
    public float delay = 27f;       
    public bool useRealtime = false; 

    [Header("Audio Settings")]
    public AudioSource audioSource; 
    public AudioClip animationSound; 

    [Header("Text Settings")]
    public TextMeshPro assureText; 

    private bool animationPlaying = false;
    private bool playerInsideTrigger = false;

    IEnumerator Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("[EnableAnimatorAfterDelay] No Animator found.");
            yield break;
        }

        
        animator.enabled = false;
        if (assureText != null) assureText.gameObject.SetActive(false);

        
        if (useRealtime) yield return new WaitForSecondsRealtime(delay);
        else yield return new WaitForSeconds(delay);

       
        animator.enabled = true;
        animationPlaying = true;

        
        if (assureText != null) assureText.gameObject.SetActive(true);

        
        if (audioSource != null && animationSound != null)
        {
            audioSource.loop = true;
            audioSource.clip = animationSound;
            audioSource.Play();
        }

        Debug.Log($"Animator + Sound started after {delay} seconds.");
    }

    void Update()
    {
        if (animationPlaying && playerInsideTrigger && Input.GetKeyDown(KeyCode.Return))
        {
            StopEverything();
        }
    }

    void StopEverything()
    {
        
        animator.enabled = false;

       
        if (audioSource != null) audioSource.Stop();

        
        if (assureText != null) assureText.gameObject.SetActive(false);

        animationPlaying = false;
        playerInsideTrigger = false;

        Debug.Log("Animation, sound, and text stopped.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            Debug.Log("Player entered trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            Debug.Log("Player exited trigger zone.");
        }
    }
}
