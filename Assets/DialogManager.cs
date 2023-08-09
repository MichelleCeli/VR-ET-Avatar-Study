using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    
    public GameObject therapist;
    public String test;

    public AudioClip T1;
    public AudioClip T2;
    public AudioClip T2A;
    public AudioClip T2B;
    public AudioClip T3;
    public AudioClip T3A;
    public AudioClip T3B;
    public AudioClip T4;
    public AudioClip T4A;
    public AudioClip T4B;
    public AudioClip T4B2;

    private AudioSource audioSource;

    void Awake()
    {
        //Instance = this;
        test = "startText";
        therapist = GameObject.Find("Realistic Therapist");
        Debug.Log("Awake: " + therapist);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void SetTherapist(String therapistName)
    {
        if (therapistName.Equals("Robot", StringComparison.Ordinal))
        {
            therapist = GameObject.Find("Robot Therapist");
        }
        else if (therapistName.Equals("Cat", StringComparison.Ordinal))
        {
            therapist = GameObject.Find("Cat Therapist");
        }
        else if (therapistName.Equals("Realistic Human", StringComparison.Ordinal))
        {
            therapist = GameObject.Find("Realistic Therapist");
        }
        else if (therapistName.Equals("Cartoon Human", StringComparison.Ordinal))
        {
            therapist = GameObject.Find("Cartoon Therapist");
        }
        
        Debug.Log("Therapist set in DM");
        Debug.Log(therapist);
       // audio = therapist.GetComponent<AudioSource>();
        //audio.Play();

        test = "setTherapist ext overwritten";
    }

    private GameObject GetTherapist()
    {
        Debug.Log("getTherapist");
        Debug.Log(this.therapist);
        return therapist;
    }

    public void TriggerAudio(String audioName)
    {
        Debug.Log("Trigger Audio Begin");
        therapist = GameObject.Find("Realistic Therapist");
        Debug.Log(therapist);

        audioSource = therapist.GetComponent<AudioSource>();

        if (audioName.Equals("T1", StringComparison.Ordinal))
        {
            Debug.Log("audioName is equal to T1");
            Debug.Log(audioSource);
            audioSource.clip = T1;
            Debug.Log("avhk");
        }

        audioSource.Play();
        Debug.Log("Trigger Audio End");
    }
}
