using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    //Variables

    public float speedRotate = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, moveHorizontal * speedRotate, 0);
    }
}
