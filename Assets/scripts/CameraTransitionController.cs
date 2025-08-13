using UnityEngine;
using System.Collections;

public class CameraTransitionController : MonoBehaviour
{
    public Transform playerCamera; 
    public Vector3 cameraLowerPosition = new Vector3(0, 1.0f, 0); 
    public Vector3 cameraUpperPosition = new Vector3(0, 2.0f, 0); 
    public float transitionSpeed = 2.0f; 

    private Coroutine cameraTransitionCoroutine;

    
    public void MoveCameraToUpper()
    {
        StartTransition(cameraUpperPosition);
    }

    
    public void MoveCameraToLower()
    {
        StartTransition(cameraLowerPosition);
    }

    private void StartTransition(Vector3 targetPosition)
    {
        if (cameraTransitionCoroutine != null)
            StopCoroutine(cameraTransitionCoroutine);
        cameraTransitionCoroutine = StartCoroutine(SmoothTransition(targetPosition));
    }

    private IEnumerator SmoothTransition(Vector3 targetPosition)
    {
        Vector3 startPosition = playerCamera.localPosition;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            playerCamera.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        playerCamera.localPosition = targetPosition;
    }
}