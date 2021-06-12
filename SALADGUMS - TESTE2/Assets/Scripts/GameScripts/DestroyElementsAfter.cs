using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyElementsAfter : MonoBehaviour
{
    //Variables

    public float lifeDuration;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeDuration);
    }
}
