using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class ColorChangePower : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] private GameObject[] hiddenObjs;
    [SerializeField] private Image powerBar;
    [SerializeField] private float powerCooldown = 0;
    [SerializeField] AudioSource audioSourcePower;

    private ColorAdjustments colorAdjustments;

    private bool usedPower = false;
    private bool CanUSePower = true;
    private bool CanfillPower = false;
    void Start()
    {
        usedPower = false;
        CanUSePower = true;
        CanfillPower = false;
        volume.profile.TryGet<ColorAdjustments> (out colorAdjustments);
        colorAdjustments.saturation.value = -100f;
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
            audioSourcePower.Play();
        }
    }
    private void PostProcessingWight()
    {
        if (colorAdjustments.saturation.value < 0 && usedPower)
        {
            colorAdjustments.saturation.value += 70f * Time.deltaTime;
            powerBar.fillAmount -= 0.7f * Time.deltaTime;

            if (colorAdjustments.saturation.value >= 0)
            {
                colorAdjustments.saturation.value = 0;
                
                for (int i = 0; i < hiddenObjs.Length; i++)
                {
                    hiddenObjs[i].SetActive(!hiddenObjs[i].activeSelf);
                }
                StartCoroutine(PostProcessingWeight2());
            }     
        }
    }
    
    IEnumerator PostProcessingWeight2()
    {
        yield return new WaitForSeconds(powerCooldown);
        colorAdjustments.saturation.value = -100f;
        for (int i = 0; i < hiddenObjs.Length; i++)
        {
            hiddenObjs[i].SetActive(!hiddenObjs[i].activeSelf);
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
