using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public void TakeDamage(int damagePlayer)
    {
        Boss.currentLifeBoss -= damagePlayer;
    }
}
