using TMPro;
using UnityEngine;

public class UIPortController : MonoBehaviour
{
    TextMeshProUGUI _port;
    void Awake()
    {
        _port = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        _port.text = NetTool.port.ToString();
    }
}
