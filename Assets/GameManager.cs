using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using WebSocketSharp;
using System.Linq;
using System;
using System.Data;

public class GameManager : MonoBehaviour
{
  
    //public int sessionNumber;

    public string therapist;
    public GameObject activeTherapist;
    public int scenario;

    public string audioTherapist;

    private bool _sceneSetUp;
    private bool _sceneInformationReceived;
    private bool _audioTriggered;
    private bool _switchToExposure;

    public GameObject realHuman;
    public GameObject cartoonHuman;
    public GameObject cat;
    public GameObject robot;

    public static GameManager instance;

    private void Awake()
    {
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

    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.Find("Robot Therapist");
        
        robot.SetActive(false);
        
        cat = GameObject.Find("Cat Therapist");
        cat.SetActive(false);
        realHuman = GameObject.Find("Realistic Therapist");
        realHuman.SetActive(false);
        cartoonHuman = GameObject.Find("Cartoon Therapist");
        cartoonHuman.SetActive(false);

        _sceneSetUp = false;
        _sceneInformationReceived = false;
        _audioTriggered = false;
        _switchToExposure = false;

    }

    void Update()
    {
        if (_sceneInformationReceived && !_sceneSetUp)
        {
            ActivateTherapist(therapist);
            _sceneSetUp = true;
            Debug.Log("Active Therapist: ");
            Debug.Log(activeTherapist);
            Debug.Log("test end");
        }

        if (_audioTriggered)
        {
            ActivateAudio(audioTherapist, activeTherapist);
            _audioTriggered = false;
        }

        if (_switchToExposure)
        {
            _switchToExposure = false;
            SceneManager.LoadScene("Exposure Scene");
        }

        
    }

   public void StartExposure()
    {
        Debug.Log("Start Exposure, scenario: " + scenario);
        if(scenario == 1)
        {
            GameObject.Find("Dog 01").GetComponent<DogBehavior>().StartBehavior();
        }
        if (scenario == 2)
        {
            GameObject.Find("Dog 02").GetComponent<DogBehavior>().StartBehavior();
        }
        if (scenario == 3)
        {
            GameObject.Find("Dog 03").GetComponent<DogBehavior>().StartBehavior();
        }
        if (scenario == 4)
        {
            GameObject.Find("Dog 04").GetComponent<DogBehavior>().StartBehavior();
        }
    }

    public int GetScenario()
    {
        return scenario;
    }

    public void SwitchToExposureScenario()
    {
        _switchToExposure = true;
    }

    public void ActivateAudio(String audioFile, GameObject therapist)
    {
        therapist.GetComponent<Therapist>().Speak(audioFile, scenario);
    }

    public void SetAudio(WebSocketManager.Message msg)
    {
        audioTherapist = msg.audio;
        _audioTriggered = true;
    }

    public void SetUpScene(WebSocketManager.Message msg)
    {
        Debug.Log("SetUpScene!");
        therapist = msg.therapist;
        _sceneInformationReceived = true;
        SetScenario(msg.scenarioTitle);
    }
    

      public void ActivateTherapist(String therapistName)
    {
 
        if (therapistName.Equals("Robot", StringComparison.Ordinal))
        {
            robot.SetActive(true);
            activeTherapist = robot;
        }
        else if (therapistName.Equals("Cat", StringComparison.Ordinal))
        {
            cat.SetActive(true);
            activeTherapist = cat;
        }
        else if (therapistName.Equals("Realistic Human", StringComparison.Ordinal))
        {
            realHuman.SetActive(true);
            activeTherapist = realHuman;
        }
        else if (therapistName.Equals("Cartoon Human", StringComparison.Ordinal))
        {
            cartoonHuman.SetActive(true);
            activeTherapist = cartoonHuman;
        }

        
    }

      public void SetScenario(String scenarioTitle)
      {
          if (scenarioTitle.Equals("Dog Sleeping", StringComparison.Ordinal))
          {
              scenario = 1;
          }
          else if (scenarioTitle.Equals("Dog Sniffing", StringComparison.Ordinal))
          {
              scenario = 2;
          }
          else if (scenarioTitle.Equals("Dog Stretching", StringComparison.Ordinal))
          {
              scenario = 3;
          }
          else if (scenarioTitle.Equals("Dog Active", StringComparison.Ordinal))
          {
              scenario = 4;
          }
          Debug.Log(scenario);
      }

     
    
    /*public class Message
    {
        public string type;
        public string commandType;
        public string message;
        public string id;
    }*/
}
