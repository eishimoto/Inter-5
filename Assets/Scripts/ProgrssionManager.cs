using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgrssionManager : MonoBehaviour
{
    //Bools
    public static bool leleuFirstLevel;
    public static bool leleuSecondLevel;
    public static bool leleuThirdLevel;   
    public static bool lisbelaSecondLevel;
    public static bool lisbelaThirdLevel;

    //Arrays
    public List<GameObject> leleusButtons;
    public List<GameObject> lisbelasButtons;

    //photos
    [SerializeField] private Image imageMap;
    [SerializeField] private Image imageCredtis;
    [SerializeField] private Image imageExtras;
    [SerializeField] private Image imageExtras2;
    [SerializeField] List<Sprite> images;


    //Static Int
    public static int currentlevel = 1;
    
    //Static
    public static ProgrssionManager instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentlevel = PlayerPrefs.GetInt("currentlevel");
    }

    void Update()
    {
        ConditionToEnableLevels();
        ConditionToEnableLevels2();
        PlayerPrefsSave();
        DeletePlayerProgression();
    }

    private void ConditionToEnableLevels()
    {
        if(leleuFirstLevel)
        {
            leleusButtons[0].SetActive(true);
            currentlevel = 2;
        }

        if (leleuSecondLevel)
        {
            leleusButtons[1].SetActive(true);
            currentlevel = 4;
        }

        if(leleuThirdLevel && lisbelaThirdLevel)
        {
            leleusButtons[2].SetActive(true);
            currentlevel = 6;
        }

        if (lisbelaSecondLevel)
        {
            lisbelasButtons[0].SetActive(true);
            currentlevel = 3;
        }
        if (lisbelaThirdLevel)
        {
            lisbelasButtons[1].SetActive(true);
            currentlevel = 5;
        }
    }
    private void ConditionToEnableLevels2()
    {
        if (leleuFirstLevel)
        {
            currentlevel = 2;
        }

        if (leleuSecondLevel)
        {
            currentlevel = 4;
        }

        if (leleuThirdLevel && lisbelaThirdLevel)
        {
            currentlevel = 6;
        }

        if (lisbelaSecondLevel)
        {
            currentlevel = 3;
        }
        if (lisbelaThirdLevel)
        {
            currentlevel = 5;
        }
    }

    private void PlayerPrefsSave()
    {
        if (currentlevel == 2)
        {
            leleusButtons[0].SetActive(true);
        }
        if (currentlevel == 3)
        {
            leleusButtons[0].SetActive(true);
            lisbelasButtons[0].SetActive(true);
        }
        if (currentlevel == 4)
        {
            leleusButtons[0].SetActive(true);
            lisbelasButtons[0].SetActive(true);
            leleusButtons[1].SetActive(true);
        }
        if (currentlevel == 5)
        {
            leleusButtons[0].SetActive(true);
            lisbelasButtons[0].SetActive(true);
            leleusButtons[1].SetActive(true);
            lisbelasButtons[1].SetActive(true);
        }
        if (currentlevel == 6)
        {
            leleusButtons[0].SetActive(true);
            lisbelasButtons[0].SetActive(true);
            leleusButtons[1].SetActive(true);
            lisbelasButtons[1].SetActive(true);
            leleusButtons[2].SetActive(true);
        }
        if(currentlevel == 0)
        {
            leleusButtons[0].SetActive(false);
            lisbelasButtons[0].SetActive(false);
            leleusButtons[1].SetActive(false);
            lisbelasButtons[1].SetActive(false);
            leleusButtons[2].SetActive(false);
        }

        PlayerPrefs.SetInt("currentlevel", currentlevel);
    }

    private void DeletePlayerProgression()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            currentlevel = 0;
        }
    }
    
    private void OnDisable()
    {
        PlayerPrefs.SetInt("currentlevel", currentlevel);
    }
}
