using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ColorChangePower : MonoBehaviour
{
    [SerializeField] PostProcessVolume volume;
    [SerializeField] private GameObject[] colorObjs;
    [SerializeField] private Image powerBar;

    private bool usedPower = false;
    private bool CanUSePower = true;
    private bool CanfillPower = false;
    void Start()
    {
        volume.weight = 1;
        usedPower = false;
        CanUSePower = true;
        CanfillPower = false;
    }

    void Update()
    {
        ChangeColor();
        PostProcessingWight();
        FillPowerBar();
    }
    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanUSePower && !usedPower)
        {
            usedPower = true;
            CanUSePower = false;
            CanfillPower = false;
        }
    }
    private void PostProcessingWight()
    {
        if (volume.weight > 0 && usedPower)
        {
            volume.weight -= 0.7f * Time.deltaTime;
            powerBar.fillAmount -= 0.7f * Time.deltaTime;

            if (volume.weight <= 0)
            {
                volume.weight = 0;
                
                for (int i = 0; i < colorObjs.Length; i++)
                {
                    colorObjs[i].SetActive(!colorObjs[i].activeSelf);
                }
                StartCoroutine(PostProcessingWeight2());
            }     
        }
    }
    
    IEnumerator PostProcessingWeight2()
    {
        yield return new WaitForSeconds(5f);
        volume.weight = 1;
        for (int i = 0; i < colorObjs.Length; i++)
        {
            colorObjs[i].SetActive(!colorObjs[i].activeSelf);
        }
        if (volume.weight == 1)
        {
            usedPower = false;
            CanfillPower = true;
        }
    }
    private void FillPowerBar()
    {
        if(CanfillPower)
        {
            powerBar.fillAmount += 0.25f * Time.deltaTime;

            if (powerBar.fillAmount == 1)
            {
                CanUSePower = true;
                CanfillPower = false;
            }
        }
    }
}
