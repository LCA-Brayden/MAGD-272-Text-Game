using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReplyCanvas : MonoBehaviour {
    public GameObject continueButton;
    public GameObject thisCanvas;
    public Fader fading;
    public TextManager reply;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setActive()
    {
        thisCanvas.SetActive(true);
        onActive();
    }

    private void onActive()
    {
        fading = GetComponent<Fader>();
        fading.FadeIn();
        
    }
}
