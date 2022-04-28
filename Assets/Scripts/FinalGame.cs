using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGame : MonoBehaviour
{
    [SerializeField] private GameObject finalpanel;
    [SerializeField] private int index;

    public bool LisbelaLevelOne;
    public bool LisbelaLevelTwo;
    public bool LisbelaLevelThree;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(index);
            
            if (LisbelaLevelOne)
            {
                ProgrssionManager.leleuFirstLevel = true;
            }
            if (LisbelaLevelTwo)
            {
                ProgrssionManager.leleuSecondLevel = true;
            }
            if (LisbelaLevelThree)
            {
                ProgrssionManager.leleuThirdLevel = true;
            }

        }
    }

    private void FinalGamePanel()
    {
        Time.timeScale = 0;
        finalpanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
