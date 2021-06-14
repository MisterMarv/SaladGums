using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Life variables
    public float bossMaxLife = 100;
    public float bossLife;

    //
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        bossLife = bossMaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossLife < 0)
        {
            DieBoss();
        }
    }
    private void DieBoss()
    {
        //Disable the srcipt and the collider
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 3);
        this.enabled = false;
    }

}
