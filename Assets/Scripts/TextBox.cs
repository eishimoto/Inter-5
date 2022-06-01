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
    private void OnEnable()
    {
        index = 0;
        StartCoroutine(Type());
        Cursor.lockState = CursorLockMode.None;
    }
    private void Start()
    {
        textBox.text = "";
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
        gameObject.SetActive(false);
    }
    
    public void NextSentenceIntro()
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
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void CloseTextBoxButton()
    {
        Destroy(gameObject);
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void FinalTextPanel()
    {
        continueButton.SetActive(true);

        if (index < textToWrite.Count - 1)
        {
            index++;
            textBox.text = null;
            StartCoroutine(Type());
        }
        else
        {
            finalButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if(isLastBox)
        {
            UI.SetActive(true);
        }
        nextTextBox.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
