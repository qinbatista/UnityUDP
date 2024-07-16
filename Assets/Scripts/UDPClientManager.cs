using UnityEngine;

public class UDPClientManager : MonoBehaviour
{
#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
    private UdpClient udpClient;
    void Awake()
    {
        udpClient = new UdpClient(NetTool.port);
    }
    void SendData(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, "127.0.0.1", NetTool.port);
            Debug.Log("Message sent: " + message);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error sending data: " + ex.Message);
        }
    }
    void OnApplicationQuit()
    {
        if (udpClient != null) udpClient.Close();
    }
#endif
}
