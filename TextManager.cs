using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager: MonoBehaviour {
    //Public Variables for In-Editor Access
    //Prompt and Response Fields
    public string promptText;
    public string responseText;
    public string rebuttalText;

    private string replyText;
    private string extraReplyText;
    //Text within Buttons 1, 2, and 3.
    public string button1Text;
    public string button2Text;
    public string button3Text;
    public string continueButtonText = "Continue...";
    //Destinations for promptText and responseText
    public Text targetTypeText;
    public Text targetTypeText2;
    public Text targetTypeText3;
    public Text targetTypeText4;
    public Text targetTypeText5;
    //Destinations for buttonText 1, 2, and 3
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;
    //Full Responses go here: 
    public string option1Full;
    public string option2Full;
    public string option3Full;
    public string extraReply1;
    public string extraReply2;
    public string extraReply3;

    //Reply Buttons: 
    public Text continueText;
    //Audio Source for 'chirping'
    public AudioSource chirper;
    //The delay between each letter and sound.
    public float interLetterTime;
    //The delay between the canvas fades
    public float timeToWait;
    //Private Variables for Subscript Computations
    private double delayGet;
    private float delaySet;
    private float textFin;
    private float rebuttalDelay;
    private float continueDelay;
    public float extraDelay = 0;
    //Allows for easier control of extra delay between the prompt and response.
    public float interDelay = 6;
    //Scene number 1,2, or 3 
    public int sceneNumb;

    //Some scenes may not have a rebuttal/extra reply text in them, so: 
    public bool isThereRebuttal = false;
    public bool isThereExtraReply = false;
    
    // Use this for initialization
    void Start () {
        //Debug Log to check and record the length and content of the Prompt and Response.
        Debug.Log("promptText: " + promptText);
        Debug.Log("responseText: " + responseText);
        Debug.Log("promptText Length: " + promptText.Length);
        Debug.Log("responseText Length: " + responseText.Length);

        //Gets the Length of the first prompt, and adds a delay based on this length to the second script. 
        //Also converts from double to float.
        delayGet = (promptText.Length * interLetterTime +interDelay);
        delaySet = (float)delayGet;
        rebuttalDelay = (float)(delaySet + responseText.Length *interLetterTime);

        if (isThereRebuttal == true) {
            textFin = (float)(delayGet + rebuttalText.Length * interLetterTime);    }
        else{
            textFin = (float)(delayGet + responseText.Length * interLetterTime);    }

        continueDelay = (float)(continueButtonText.Length * interLetterTime)+timeToWait+extraDelay;
        //Calls the Coroutines to print out the Prompt and Response Texts.
        StartCoroutine(addText(promptText));
        StartCoroutine(addText2(responseText));
        if (isThereRebuttal == true)
        {
            StartCoroutine(addText3(rebuttalText));
        }
        StartCoroutine(waitForButton(button1Text, 1));
        StartCoroutine(waitForButton(button2Text, 2));
        StartCoroutine(waitForButton(button3Text, 3));
	}
	
    //Management for editing and adding text after the buttons are selected:
    public void itsbutton1()
    {
        StopAllCoroutines();
        chirper.Stop();
        replyText = option1Full;
        extraReplyText = extraReply1;
        sceneNumb = 1;
        Debug.Log("Scenenumb: " + sceneNumb);
    }

    public void itsbutton2()
    {
        StopAllCoroutines();
        chirper.Stop();
        replyText = option2Full;
        extraReplyText = extraReply2;
        sceneNumb = 2;
        Debug.Log("Scenenumb: " + sceneNumb);
    }

    public void itsbutton3()
    {
        StopAllCoroutines();
        chirper.Stop();
        replyText = option3Full;
        extraReplyText = extraReply3;
        sceneNumb = 3;
        Debug.Log("Scenenumb: " + sceneNumb);
    }
    

    public void reply()
    {
        StartCoroutine(waitforContinue(continueButtonText));
        StartCoroutine(addReply(replyText));
        Debug.Log("isThereExtraReply =" + isThereExtraReply);
        if (isThereExtraReply == true)
        {
            StartCoroutine(addExtraReply(extraReplyText));
        }
    }

    public int getScene()
    {
        return sceneNumb;
    }

    IEnumerator addText(string text)
    {
        int textLength = text.Length;
        for(int i = 0; i<textLength+1; i++)
        {
            targetTypeText.text = text.Substring(0, i);
            chirper.Play();
            yield return new WaitForSeconds(interLetterTime);
            chirper.Stop();
        }
    }

    IEnumerator addText2(string text2)
    {
        yield return new WaitForSeconds(delaySet);
        int textLength = text2.Length;
        for (int i=0; i<textLength+1; i++)
        {
            targetTypeText2.text = text2.Substring(0, i);
            chirper.Play();
            yield return new WaitForSeconds(interLetterTime);
            chirper.Stop();
        }


    }
    IEnumerator addText3(string text)
    {
        yield return new WaitForSeconds(rebuttalDelay);
        int textLength = text.Length;
        for (int i = 0; i < textLength + 1; i++)
        {
            targetTypeText3.text = text.Substring(0, i);
            chirper.Play();
            yield return new WaitForSeconds(interLetterTime);
            chirper.Stop();
        }
    }
    IEnumerator addReply(string text)
    {
        yield return new WaitForSeconds(timeToWait);
        Debug.Log("In addReply");
        int textLength = text.Length;
        for (int i = 0; i < textLength + 1; i++)
        {
            targetTypeText4.text = text.Substring(0, i);
        }
    }
    IEnumerator addExtraReply(string text)
    {
        yield return new WaitForSeconds(continueDelay);
        Debug.Log("In addExtraReply");
        int textLength = text.Length;
        for (int i = 0; i < textLength + 1; i++)
        {
            targetTypeText5.text = text.Substring(0, i);
        }
    }
    IEnumerator waitForButton(string button, int opnumb)
    {
        int textLength = button.Length;
        yield return new WaitForSeconds(textFin);
        for (int i = 0; i < textLength + 1; i++)
        {
            switch (opnumb)
            {
                case 1:
                    option1Text.text = button.Substring(0, i);
                    yield return new WaitForSeconds(interLetterTime);
                    break;
                case 2:
                    option2Text.text = button.Substring(0, i);
                    yield return new WaitForSeconds(interLetterTime);
                    break;
                case 3:
                    option3Text.text = button.Substring(0, i);
                    yield return new WaitForSeconds(interLetterTime);
                    break;
            }
        }
    }
    IEnumerator waitforContinue(string button)
    {
        Debug.Log("in waitforContinue");
        Debug.Log("This is the wait: " + continueDelay);
        int textLength = button.Length;
        yield return new WaitForSeconds(continueDelay);
        for (int i = 0; i< textLength +1; i++)
        {
            continueText.text = button.Substring(0, i);
            yield return new WaitForSeconds(interLetterTime);
        }
    }
}
