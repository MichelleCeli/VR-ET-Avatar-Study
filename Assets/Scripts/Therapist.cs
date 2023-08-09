using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Therapist : MonoBehaviour
{

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

    public AudioClip D2_T1;
    public AudioClip D2_T1A;
    public AudioClip D2_T1B;
    public AudioClip D2_T2;
    public AudioClip D2_T2A;
    public AudioClip D2_T2B;
    public AudioClip D2_T3;
    public AudioClip D2_T3A;
    public AudioClip D2_T3B;
    public AudioClip D2_T3B2;

    public AudioClip D3_T1;
    public AudioClip D3_T1A;
    public AudioClip D3_T1B;
    public AudioClip D3_T2;
    public AudioClip D3_T2A;
    public AudioClip D3_T2B;
    public AudioClip D3_T3;
    public AudioClip D3_T3A;
    public AudioClip D3_T3B;
    public AudioClip D3_T4;
    public AudioClip D3_T4A;
    public AudioClip D3_T4B;
    public AudioClip D3_T5A;
    public AudioClip D3_T5B;
    public AudioClip D3_T5B2;

    public AudioClip D4_T1;
    public AudioClip D4_T1A;
    public AudioClip D4_T1B;
    public AudioClip D4_T2;
    public AudioClip D4_T2A;
    public AudioClip D4_T2B;
    public AudioClip D4_T3;
    public AudioClip D4_T4;
    public AudioClip D4_T4A;
    public AudioClip D4_T4B;
    public AudioClip D4_T4B2;


    private AudioSource src;


    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void Speak(string audioFile, int scenario)
    {
        if (scenario == 1)
        {
            if (audioFile.Equals("T1", StringComparison.Ordinal))
                src.clip = T1;
            else if (audioFile.Equals("T2", StringComparison.Ordinal))
                src.clip = T2;
            else if (audioFile.Equals("T2A", StringComparison.Ordinal))
                src.clip = T2A;
            else if (audioFile.Equals("T2B", StringComparison.Ordinal))
                src.clip = T2B;
            else if (audioFile.Equals("T3", StringComparison.Ordinal))
                src.clip = T3;
            else if (audioFile.Equals("T3A", StringComparison.Ordinal))
                src.clip = T3A;
            else if (audioFile.Equals("T3B", StringComparison.Ordinal))
                src.clip = T3B;
            else if (audioFile.Equals("T4", StringComparison.Ordinal))
                src.clip = T4;
            else if (audioFile.Equals("T4A", StringComparison.Ordinal))
                src.clip = T4A;
            else if (audioFile.Equals("T4B", StringComparison.Ordinal))
                src.clip = T4B;
            else if (audioFile.Equals("T4B2", StringComparison.Ordinal))
                src.clip = T4B2;
        } 
        else if (scenario == 2)
        {
            if (audioFile.Equals("T1", StringComparison.Ordinal))
                src.clip = D2_T1;
            else if (audioFile.Equals("T1A", StringComparison.Ordinal))
                src.clip = D2_T1A;
            else if (audioFile.Equals("T1B", StringComparison.Ordinal))
                src.clip = D2_T1B;
            else if (audioFile.Equals("T2", StringComparison.Ordinal))
                src.clip = D2_T2;
            else if (audioFile.Equals("T2A", StringComparison.Ordinal))
                src.clip = D2_T2A;
            else if (audioFile.Equals("T2B", StringComparison.Ordinal))
                src.clip = D2_T2B;
            else if (audioFile.Equals("T3", StringComparison.Ordinal))
                src.clip = D2_T3;
            else if (audioFile.Equals("T3A", StringComparison.Ordinal))
                src.clip = D2_T3A;
            else if (audioFile.Equals("T3B", StringComparison.Ordinal))
                src.clip = D2_T3B;
            else if (audioFile.Equals("T3B2", StringComparison.Ordinal))
                src.clip = D2_T3B2;
        }
        else if (scenario == 3)
        {
            if (audioFile.Equals("T1", StringComparison.Ordinal))
                src.clip = D3_T1;
            else if (audioFile.Equals("T1A", StringComparison.Ordinal))
                src.clip = D3_T1A;
            else if (audioFile.Equals("T1B", StringComparison.Ordinal))
                src.clip = D3_T1B;
            else if (audioFile.Equals("T2", StringComparison.Ordinal))
                src.clip = D3_T2;
            else if (audioFile.Equals("T2A", StringComparison.Ordinal))
                src.clip = D3_T2A;
            else if (audioFile.Equals("T2B", StringComparison.Ordinal))
                src.clip = D3_T2B;
            else if (audioFile.Equals("T3", StringComparison.Ordinal))
                src.clip = D3_T3;
            else if (audioFile.Equals("T3A", StringComparison.Ordinal))
                src.clip = D3_T3A;
            else if (audioFile.Equals("T3B", StringComparison.Ordinal))
                src.clip = D3_T3B;
            else if (audioFile.Equals("T4", StringComparison.Ordinal))
                src.clip = D3_T4;
            else if (audioFile.Equals("T4A", StringComparison.Ordinal))
                src.clip = D3_T4A;
            else if (audioFile.Equals("T4B", StringComparison.Ordinal))
                src.clip = D3_T4B;
            else if (audioFile.Equals("T5A", StringComparison.Ordinal))
                src.clip = D3_T5A;
            else if (audioFile.Equals("T5B", StringComparison.Ordinal))
                src.clip = D3_T5B;
            else if (audioFile.Equals("T5B2", StringComparison.Ordinal))
                src.clip = D3_T5B2;
        }
        else if (scenario == 4)
        {
            if (audioFile.Equals("T1", StringComparison.Ordinal))
                src.clip = D4_T1;
            else if (audioFile.Equals("T1A", StringComparison.Ordinal))
                src.clip = D4_T1A;
            else if (audioFile.Equals("T1B", StringComparison.Ordinal))
                src.clip = D4_T1B;
            else if (audioFile.Equals("T2", StringComparison.Ordinal))
                src.clip = D4_T2;
            else if (audioFile.Equals("T2A", StringComparison.Ordinal))
                src.clip = D4_T2A;
            else if (audioFile.Equals("T2B", StringComparison.Ordinal))
                src.clip = D4_T2B;
            else if (audioFile.Equals("T3", StringComparison.Ordinal))
                src.clip = D4_T3;
            else if (audioFile.Equals("T4", StringComparison.Ordinal))
                src.clip = D4_T4;
            else if (audioFile.Equals("T4A", StringComparison.Ordinal))
                src.clip = D4_T4A;
            else if (audioFile.Equals("T4B", StringComparison.Ordinal))
                src.clip = D4_T4B;
            else if (audioFile.Equals("T4B2", StringComparison.Ordinal))
                src.clip = D4_T4B2;
        }


        Debug.Log("Speak");
        
        src.Play();

        

    }
}
