using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIIPController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    TMP_InputField _ip;
    void Start()
    {
#if UNITY_EDITOR
        _ip = GetComponent<TMP_InputField>();
        _ip.text = NetTool.GetLocalIPAddress();
        //disable the input field
        _ip.interactable = false;
#endif
    }
}
