using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    //Variable initialization
    //Values will be assigned in the AudioManager object.
    public AudioSource soundEffect1;
    public AudioSource soundEffect2;
    public GameObject soundSource1;
    public GameObject soundSource2;
    public bool doesSound1Stop = false;
    public bool doesSound2Stop = false;
    public bool doesSound1Exist = true;
    public bool doesSound2Exist = true;
    public bool doesSound1PlayOnAwake = true;
    public bool doesSound2PlayOnAwake = true;
    //Time to wait for the sound effects are assigned below.
    public float waitTime1;
    public float waitTime2;
    public float stopDelay;

	// Use this for initialization
	void Start () {
        if (doesSound1Exist == true)
        {
            Debug.Log("Sound 1 Exists.");
            if (doesSound1PlayOnAwake == true)
            {
                Debug.Log("Sound 1 Playing On Awake");
                StartCoroutine(waitPlease(waitTime1, soundEffect1, doesSound1Stop));
            }
        }
        if (doesSound2Exist == true)
        {
            Debug.Log("Sound 2 Exists.");
            if (doesSound2PlayOnAwake == true)
            {
                Debug.Log("Sound 2 Playing on Awake");
                StartCoroutine(waitPlease(waitTime2, soundEffect2, doesSound2Stop));
            }
        }
        
	}

    public void playSound1()
    {
        Debug.Log("Playing Sound 1");
        StartCoroutine(playThis(waitTime1, soundEffect1, doesSound1Stop));
    }

    public void playSound2()
    {
        Debug.Log("Playing Sound 2");
        StartCoroutine(playThis(waitTime2, soundEffect2, doesSound2Stop));
    }

    IEnumerator waitPlease(float timeToWait, AudioSource playThis, bool doIStop)
    {
        Debug.Log("In coroutine waitPlease");
        yield return new WaitForSeconds(timeToWait);
        playThis.Play();
        if (doIStop == true)
        {
            yield return new WaitForSeconds(stopDelay);
            playThis.Stop();
        }
        else
        {
            yield break;
        }
    }

    IEnumerator playThis(float timeToWait, AudioSource playTHIS, bool doIStop)
    {
        Debug.Log("In coroutine playThis");
        yield return new WaitForSeconds(timeToWait);
        playTHIS.Play();
        if (doIStop == true)
        {
            yield return new WaitForSeconds(stopDelay);
            playTHIS.Stop();
        }
        else
        {
            yield break;
        }
    }
   }
