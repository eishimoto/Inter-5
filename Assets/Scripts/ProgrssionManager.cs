using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update()
    {
        ConditionToEnableLevels();
        ResetBooleans();
    }

    private void ConditionToEnableLevels()
    {
        if(leleuFirstLevel)
        {
            leleusButtons[0].SetActive(true);
        }

        if (leleuSecondLevel)
        {
            leleusButtons[1].SetActive(true);
        }

        if(leleuThirdLevel && lisbelaThirdLevel)
        {
            leleusButtons[2].SetActive(true);
        }

        if (lisbelaSecondLevel)
        {
            lisbelasButtons[0].SetActive(true);
        }
        if (lisbelaThirdLevel)
        {
            lisbelasButtons[1].SetActive(true);
        }
    }

    private void ResetBooleans()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            leleuFirstLevel = false;
            leleuSecondLevel = false;
            leleuThirdLevel = false;
            lisbelaSecondLevel = false;
            lisbelaThirdLevel = false;
        }
    }
}
