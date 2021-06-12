using UnityEngine.UI;
using UnityEngine;

public class LevelsUnlock : MonoBehaviour
{
    //Variables

    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button reachedCheck in levelButtons)
        {
            reachedCheck.interactable = false;

            int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

            for(int buttonCheck = 0; buttonCheck < reachedLevel; buttonCheck++)
            {
                levelButtons[buttonCheck].interactable = true;
            }
        }
    }

            
}
