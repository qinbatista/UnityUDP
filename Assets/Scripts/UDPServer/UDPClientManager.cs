using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPClientManager : MonoBehaviour
{
    private UdpClient udpClient;
    void Awake()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxEditor)
        {
            Destroy(this);
        }
        udpClient = new UdpClient(NetTool.port);
    }
    void SendData(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, NetTool.serverIp, NetTool.port);
            Debug.Log("Message sent: " + message);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error sending data: " + ex.Message);
        }
    }
    void OnApplicationQuit()
    {
        if (udpClient != null)
        {

            Debug.Log("UDPHostManager is closing.");
            udpClient.Close();
        }

    }
    public void SendIndex()
    {
        SendData("+1");
    }
}
