using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPClientManager : MonoBehaviour
{
    private UdpClient udpClient;
    const int listenPort = 8888;
    void Awake()
    {
        udpClient = new UdpClient(listenPort);
    }
    void SendData(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, "127.0.0.1", listenPort);
            Debug.Log("Message sent: " + message);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error sending data: " + ex.Message);
        }
    }

}
