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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (LisbelaLevelOne)
            {
                ProgrssionManager.leleuFirstLevel = true;
                ProgrssionManager.lisbelaFirstlevel = true;
            }
            if (LisbelaLevelTwo)
            {
                ProgrssionManager.leleuSecondLevel = true;
            }          
            SceneManager.LoadScene(index);
        }
    }
    private void FinalGamePanel()
    {
        Time.timeScale = 0;
        finalpanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
