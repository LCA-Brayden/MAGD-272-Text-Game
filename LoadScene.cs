using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    public string firstSceneName;
    public string secondSceneName;
    public string thirdSceneName;
    public float timeToWait;
    TextManager scenenumb;

    // Use this for initialization
    void Start () {
        scenenumb = GetComponent<TextManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //Loads Scene based on the scenenumb from TextManager. Allows for more flexibility and usability.
    public void loadScene()
    {
        Debug.Log("Scene Number: " + scenenumb.getScene());
        StartCoroutine(waitPlease(scenenumb.getScene()));
    }

    //Alternative to the above functions; for simpler transitions without the need of any other Coroutines.
    //Transitions to location firstSceneName
    public void loadFirstScene()
    {
        StartCoroutine(waitPlease(1)); 
    }
    //Transitions to location secondSceneName
    public void loadSecondScene()
    {
        StartCoroutine(waitPlease(2));
    }
    //Transitions to location thirdSceneName
    public void loadThirdScene()
    {
        StartCoroutine(waitPlease(3));
    }
    //Waits a set amount of time before loading the scene, to give time for the fade
    IEnumerator waitPlease(int opnumb)
    {
        yield return new WaitForSeconds(timeToWait);
        switch (opnumb)
        {
            case 1:
                SceneManager.LoadScene(firstSceneName, LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene(secondSceneName, LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene(thirdSceneName, LoadSceneMode.Single);
                break;
        }



        }
}
