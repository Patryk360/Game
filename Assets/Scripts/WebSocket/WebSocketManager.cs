using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;

public class WebSocketManager
{
    private static WebSocket webSocket;

    public static void StartWebSocket()
    {
        webSocket = new WebSocket("ws://localhost:8080");
        webSocket.Connect();

        webSocket.OnError += (sender, e) =>
        {
            Debug.Log("WS: Error - " + e.Message);
        };

        webSocket.OnClose += (sender, e) =>
        {
            Debug.Log("WS: Close");
        };

        webSocket.OnMessage += (sender, e) =>
        {
            
            PlayerJoin.Join();
            Debug.Log("WS: " + e.Data);
        };
    }

    public static void SendWebSocketMessage(string message)
    {
        if (webSocket != null && webSocket.ReadyState == WebSocketState.Open)
        {
            webSocket.Send(message);
        }
    }
}