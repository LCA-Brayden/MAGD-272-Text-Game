using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    public bool button1enable = true;
    public bool button2enable = true;
    public bool button3enable = true;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        button1.SetActive(button1enable);
        button2.SetActive(button2enable);
        button3.SetActive(button3enable);
    }
}
