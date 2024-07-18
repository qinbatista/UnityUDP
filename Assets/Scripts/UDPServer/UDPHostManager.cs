using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UDPHostManager : Singleton<UDPHostManager>
{
#if UNITY_EDITOR
    UdpClient _udpClient;
    Thread _receiveThread;
    string _ipAddressText;
    int _index = 0;

    public int Index { get => _index; set => _index = value; }

    void Start()
    {
        Debug.Log("IP:" + _ipAddressText != null ? "UDPHostManager is started, IP Address: " + NetTool.GetLocalIPAddress() : "No Text component assigned to display the IP address.");
        _udpClient = new UdpClient(NetTool.port);
        _receiveThread = new Thread(new ThreadStart(ReceiveData))
        {
            IsBackground = true
        };
        _receiveThread.Start();
    }

    void ReceiveData()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, NetTool.port);
        while (true)
        {
            try
            {
                byte[] data = _udpClient.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(data);
                Debug.Log("Message received: " + message);

                switch (message[0])
                {
                    case '0':
                        Index++;
                        break;
                    case '+':
                        // Index += int.Parse(message.Substring(1));
                        break;
                }
            }
            catch (Exception)
            {
                // Debug.LogError("Error receiving data: " + ex.Message);
            }
        }
    }
    void OnApplicationQuit()
    {
        if (_receiveThread != null)
        {
            Debug.Log("UDPHostManager is closing.");
            _receiveThread.Abort();
        }
    }
#endif
}
