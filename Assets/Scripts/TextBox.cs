using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private List<string> textToWrite;
    
    private int index;
    
    [SerializeField] private float typingSpeed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject finalButton;

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
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void CloseTextBoxButton()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void FinalTextPanel()
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
            finalButton.SetActive(true);
            Destroy(gameObject);
        }
    }
  
}
