using UnityEngine;
using TMPro; 

public class SeatbeltTriggerScript : MonoBehaviour
{
    public GameObject seatbelt;       
    public AudioClip buckleSound;     

    [Header("Text Settings")]
    public TextMeshPro seatbeltText;  
    public Color buckledColor = Color.green;
    public string buckledText = "BUCKLED";

    private AudioSource audioSource; 
    private bool playerInside = false;
    private bool isBuckled = false;

    void Start()
    {
        
        if (seatbelt != null)
            seatbelt.SetActive(false);

       
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        
        if (playerInside && !isBuckled && Input.GetKeyDown(KeyCode.Return))
        {
            BuckleSeatbelt();
        }
    }

    void BuckleSeatbelt()
    {
        isBuckled = true;

       
        if (seatbelt != null)
            seatbelt.SetActive(true);

        
        if (seatbeltText != null)
        {
            seatbeltText.text = buckledText;
            seatbeltText.color = buckledColor;
        }

       
        if (buckleSound != null)
            audioSource.PlayOneShot(buckleSound);

        Debug.Log("Seatbelt buckled, text changed, and sound played.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered seatbelt zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Player left seatbelt zone.");
        }
    }
}
