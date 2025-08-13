using UnityEngine;

public class SeatbeltInteractable : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public GameObject seatbeltObject;     
    public GameObject unbuckledLabel;     
    public GameObject interactPrompt;     
    public string playerTag = "Player";  

    [Header("Settings")]
    public KeyCode interactKey = KeyCode.Return; 
    public bool autoDisableAfterBuckle = true;   

    bool playerInRange = false;
    bool isBuckled = false;

    void Start()
    {
        
        if (seatbeltObject != null) seatbeltObject.SetActive(false);
        if (unbuckledLabel != null) unbuckledLabel.SetActive(true);
        if (interactPrompt != null) interactPrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && !isBuckled)
        {
            if (Input.GetKeyDown(interactKey))
            {
                Buckle();
            }
        }
    }

    void Buckle()
    {
        isBuckled = true;

        if (seatbeltObject != null)
            seatbeltObject.SetActive(true);

        if (unbuckledLabel != null)
            unbuckledLabel.SetActive(false);

        if (interactPrompt != null)
            interactPrompt.SetActive(false);

        

        if (autoDisableAfterBuckle)
            enabled = false; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag) && !isBuckled)
        {
            playerInRange = true;
            if (interactPrompt != null)
                interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            playerInRange = false;
            if (interactPrompt != null)
                interactPrompt.SetActive(false);
        }
    }
}
