using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotionCollectionCount : MonoBehaviour
{
    public int count;

    public bool leleuLevelOne;
    public bool leleuLevelTwo;
    public bool leleuLevelThree;
    
    void Start()
    {
       count = 0;
    }
    void Update()
    {
        if(count == 3 && leleuLevelOne)
        {
            ProgrssionManager.lisbelaSecondLevel = true;
        }
        if(count == 3 && leleuLevelTwo)
        {
            ProgrssionManager.lisbelaThirdLevel = true;
        }
        
        Debug.Log(count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Potion")
        {
            count++;
        }
    }
}
