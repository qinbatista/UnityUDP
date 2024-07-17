using TMPro;
using UnityEngine;

public class UIIndexInfo : Singleton<UIIndexInfo>
{
    public TextMeshProUGUI _uiIndexInfo;

    public TextMeshProUGUI UiIndexInfo { get => _uiIndexInfo; set => _uiIndexInfo = value; }

    void Start()
    {
        UiIndexInfo = GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        UiIndexInfo.text = "[" + System.DateTime.Now.ToString("HH:mm:ss") + "]:" + UDPHostManager.Instance.Index.ToString();
    }
}
