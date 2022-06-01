using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private List<string> textToWrite;
    [SerializeField] private GameObject nextTextBox;
    [SerializeField] private GameObject UI;

    private int index;
    
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject finalButton;


    public bool isLastBox;
    public static bool canFollow;
    private void OnEnable()
    {
        index = 0;
        StartCoroutine(Type());
        Cursor.lockState = CursorLockMode.None;
    }
    private void Start()
    {
        textBox.text = "";
        canFollow = false;
    }
       
    void Update()
    {
        if (textBox.text == textToWrite[index])
        {
            continueButton.SetActive(true);
        }
        if (gameObject.activeSelf.Equals(true))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in textToWrite[index].ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        
        if (index < textToWrite.Count - 1)
        {
            index++;
            textBox.text = null;
            StartCoroutine(Type());
        }
        else
        {
            textBox.text = null;
            StartCoroutine(CloseTextBox());
        }
    }

    IEnumerator CloseTextBox()
    {
        yield return new WaitForSeconds(0.02f);
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
    
    public void CloseTextBoxButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        if(isLastBox)
        {
            UI.SetActive(true);
            canFollow = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        nextTextBox.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
