using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPHostManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    UdpClient udpClient;
    Thread receiveThread;
    const int listenPort = 8888;
    public string ipAddressText;
    void Awake()
    {
        Debug.Log("UDPHostManager is running, IP:" + ipAddressText != null ? "IP Address: " + NetTool.GetLocalIPAddress() : "No Text component assigned to display the IP address.");
        udpClient = new UdpClient(listenPort);
        receiveThread = new Thread(new ThreadStart(ReceiveData))
        {
            IsBackground = true
        };
        receiveThread.Start();
    }

    void ReceiveData()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
        while (true)
        {
            try
            {
                byte[] data = udpClient.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(data);
                Debug.Log("Message received: " + message);
            }
            catch (Exception ex)
            {
                Debug.LogError("Error receiving data: " + ex.Message);
            }
        }
    }
    void OnApplicationQuit()
    {
        if (receiveThread != null)
            receiveThread.Abort();
    }
}
