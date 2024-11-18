using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDestroyer : MonoBehaviour
{
    public float Timer;
    void Start()
    {
        Destroy(gameObject,Timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
