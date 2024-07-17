using TMPro;
using UnityEngine;

public class UIAddressInfo : MonoBehaviour
{
    TextMeshProUGUI _addressInfo;
    void Start()
    {
        _addressInfo = GetComponent<TextMeshProUGUI>();
#if UNITY_EDITOR
        _addressInfo.text = "This is Server:[" + NetTool.GetLocalIPAddress() + ":" + NetTool.port.ToString() + "]";
#elif UNITY_ANDROID || UNITY_IOS
        _addressInfo.text = "This is Client, target server:[" + NetTool.serverIp + ":" + NetTool.port.ToString()+"]";
#endif
    }
}
