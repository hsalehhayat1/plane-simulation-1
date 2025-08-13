using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator walkinganimation;
    
    void Start()
    {
        walkinganimation=gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }
}
