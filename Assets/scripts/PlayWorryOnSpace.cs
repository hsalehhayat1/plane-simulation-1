using UnityEngine;

public class PlayWorryOnSpace : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("StartWorry");
        }
    }
}
