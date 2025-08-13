using UnityEngine;
using TMPro; 

public class SeatbeltUI : MonoBehaviour
{
    public TextMeshProUGUI label; 

    public Color unbuckledColor = Color.red;
    public Color buckledColor = Color.green;

    public void SetUnbuckledImmediate()
    {
        if (label != null)
        {
            label.text = "UN-BUCKLED";
            label.color = unbuckledColor;
        }
    }

    public void SetBuckled()
    {
        if (label != null)
        {
            label.text = "BUCKLED";
            label.color = buckledColor;
        }
    }
}
