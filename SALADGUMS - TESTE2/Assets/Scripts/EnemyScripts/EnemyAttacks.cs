using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttacks : MonoBehaviour
{
    public Image damageScreen;

    public void Start()
    {
        damageScreen.enabled = false;
    }

    public IEnumerator Attack(int damageAmount)
    {
        damageScreen.enabled = true;
        PlayerManager.currentHealth -= damageAmount;
        yield return new WaitForSeconds(1.5f);
        damageScreen.enabled = false;
    }
}
