using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehavior : MonoBehaviour
{
    private Animator _anim;
    private int _scenario;
    private int _behavior;

    private bool _exposureStarted;

    public GameManager GM;

    private void Awake()
    {
          GM = GameObject.Find("GameManager").GetComponent<GameManager>();
          _scenario = GM.GetScenario();
          _behavior = GetDog(); 


          SetDog(_scenario, _behavior);  
            

       
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _exposureStarted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (_scenario == 1)
        {
             Invoke("stopSleeping", 10.0f);
        }

        if (_scenario == 2 || _scenario == 4)
        {
            Invoke("stopSitting", 10.0f);
        }

        if (_scenario == 3)
        {
            Invoke("stopLaying", 10.0f);
        }

        Invoke("endScenario", 60.0f);

        
    }

    public void StartBehavior()
    {
        _exposureStarted = true;
    }

    private void SetDog(int _scenarioNumber, int _behavior)
    {
        if (_scenarioNumber != _behavior)
            gameObject.SetActive(false);

    }
    

    private int GetDog()
    {
        switch (gameObject.name)
        {
            case "Dog 01":
            {
                return 1;
            }
            case "Dog 02":
            {
                return 2;
            }
            case "Dog 03":
            {
                return 3;
            }
            case "Dog 04":
            {
                return 4;
            }
        }
        
        return 0;
    } 

    private void stopSleeping()
    {
        _anim.SetTrigger("stopSleeping");
    }

    private void endScenario()
    {
        Debug.Log("Scenario End");
        Application.Quit();
    }
    
    private void stopSitting()
    {
        _anim.SetTrigger("stopSitting");
    }

    private void stopLaying()
    {
        _anim.SetTrigger("stopLaying");
    }

}