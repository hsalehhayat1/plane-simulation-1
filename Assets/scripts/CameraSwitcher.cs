using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject windowCam;
    public GameObject fpsCam;
    public float transitionDuration = 2f;

    private bool isBlending = false;
    private float blendTimer = 0f;
    private Transform windowTransform;
    private Transform fpsTransform;

    void Start()
    {
        windowCam.SetActive(true);
        fpsCam.SetActive(false);

        windowTransform = windowCam.transform;
        fpsTransform = fpsCam.transform;

        StartCoroutine(SmoothTransitionToFPS());
    }

    System.Collections.IEnumerator SmoothTransitionToFPS()
    {
        yield return new WaitForSeconds(1f); 

        isBlending = true;

        Vector3 startPosition = windowTransform.position;
        Quaternion startRotation = windowTransform.rotation;

        Vector3 endPosition = fpsTransform.position;
        Quaternion endRotation = fpsTransform.rotation;

        while (blendTimer < transitionDuration)
        {
            blendTimer += Time.deltaTime;
            float t = blendTimer / transitionDuration;

            
            windowTransform.position = Vector3.Lerp(startPosition, endPosition, t);
            windowTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            yield return null;
        }

        
        windowCam.SetActive(false);
        fpsCam.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
