using UnityEngine;

public class SeatBeltActivator : MonoBehaviour
{
    public GameObject seatbelt;  
    private bool playerInside = false;

    void Start()
    {
        seatbelt.SetActive(false); 
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.Return))
        {
            seatbelt.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
