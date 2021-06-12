using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LootBox : MonoBehaviour
{
    public static int numberReference;
    public float timeNext = 0;
    public GameObject[] items;
    public GameObject openBox;

    public void OpenBox()
    {
        int sortNumber = Random.Range(1, 101);
        if (sortNumber > 66)
        {
            openBox.SetActive(false);
            items[0].SetActive(items[0]);
            numberReference = 1;
            StartCoroutine(WaitForSceneLoad());
            IEnumerator WaitForSceneLoad()
            {
                yield return new WaitForSeconds(3);
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextLevel);
            }
        }
        else if (sortNumber <= 66 & sortNumber > 33)
        {
            openBox.SetActive(false);
            items[1].SetActive(items[1]);
            numberReference = 2;
            StartCoroutine(WaitForSceneLoad());
            IEnumerator WaitForSceneLoad()
            {
                yield return new WaitForSeconds(3);
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextLevel);
            }
        }
        else
        {
            openBox.SetActive(false);
            items[2].SetActive(items[2]);
            numberReference = 3;
            StartCoroutine(WaitForSceneLoad());
            IEnumerator WaitForSceneLoad()
            {
                yield return new WaitForSeconds(3);
                int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
