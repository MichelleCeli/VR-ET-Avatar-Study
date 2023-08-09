using UnityEngine;
using UnityEngine.SceneManagement;
using WebSocketSharp;
using System.IO;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;


public class WebSocketManager : MonoBehaviour
{
    WebSocket ws;
    private static bool _connected;
    
    public VideostreamManager VM;
    public GameManager GM;

    public static WebSocketManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        VM = GameObject.Find("Stream Camera").GetComponent<VideostreamManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        //instance = this;

       if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        } 
    }
    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        
        ws.OnOpen += (sender, e) =>
        {
            _connected = true;
            Debug.Log("connected: " + _connected);
            
            VM.StartStreaming();
            
            /*Debug.Log(ws.ReadyState);
            Debug.Log(WebSocketState.Closed);*/
        };
        ws.OnMessage += (sender, e) =>
        {
            //Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            Message msg = JsonUtility.FromJson<Message>(e.Data);
           // Debug.Log("Message Type: " + msg.type);
            
            if (msg.type.Equals("Session Information", StringComparison.Ordinal))
            {
                GM.SetUpScene(msg);
            }
            
            if (msg.type.Equals("Trigger Audio", StringComparison.Ordinal))
            {             
                GM.SetAudio(msg);
            }

            if (msg.type.Equals("Switch To Exposure", StringComparison.Ordinal))
            {
                GM.SwitchToExposureScenario();
            }

            if (msg.type.Equals("Start Exposure", StringComparison.Ordinal))
            {
                GM.StartExposure();
            }





            //Debug.Log(msg.type);
            //GM.SetUpScene(msg);

            /*String test = JsonUtility.ToJson(msg);
            Debug.Log("String: " + test);
            print(JsonUtility.ToJson(msg));
            Debug.Log(msg);*/

        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WS connection lost");
        };

        ws.Connect();

    }

    private void Update()
    {
        if (ws == null)
        {
            return;
        }

      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("Hello");
        } */
    }

    public void SwitchToExposureWS()
    {
        Debug.Log(SceneManager.GetActiveScene());
        if(SceneManager.GetActiveScene().name.Equals("Exposure Scene", StringComparison.Ordinal))
        {
            VM = GameObject.Find("Stream Camera").GetComponent<VideostreamManager>();
            VM.StartStreaming();
            Debug.Log("switch worked successfully");
        }
    }

    public bool IsConnected()
    {
        return _connected;
    }
    public void SendMessageWeb(string msg)
    {
        if(ws.ReadyState == WebSocketState.Open)
        {
            ws.Send(msg);
           // Debug.Log("Message Send");
        }
    }
    
    public WebSocketState GetStatus()
    {
        return ws != null ? ws.ReadyState : WebSocketState.Closed;
    }
    
    public void AddHandlerMessage(EventHandler<MessageEventArgs> handler)
    {
        if(ws != null)
        {
            print("Aggiungo Handler");
            ws.OnMessage += handler;
        }
    }
    
    public class Message
    {
        public string type;
        public string therapist;
        public string scenarioTitle;
        public string audio;
    }
    
}