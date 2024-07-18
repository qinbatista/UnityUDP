using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    Vector2 _touchDeltaVector;
    Vector2 _touchPositionVector;
    RaycastHit _clickRayHit;
    StringBuilder _stringBuilder = new StringBuilder();
    public void TouchPosition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _touchPositionVector = context.ReadValue<Vector2>();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(_touchPositionVector), out _clickRayHit))
            {
                Debug.Log("hit.collider.tag=" + _clickRayHit.collider.tag);
                switch (_clickRayHit.collider.tag)
                {
                    case "Player":
#if UNITY_EDITOR
                        UDPHostManager.Instance.Index++;
#elif UNITY_ANDROID || UNITY_IOS
                        Debug.Log("UDPClientManager.Instance.SendData(0);");
                        UDPClientManager.Instance.SendData("0");
#endif
                        //change the color of the player
                        break;
                    default: break;
                }
            }
        }
    }
    public void TouchDelta(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _touchDeltaVector = context.ReadValue<Vector2>();
            Debug.Log("TouchMove _touchDeltaVector=" + _touchDeltaVector);
#if UNITY_EDITOR
            UDPHostManager.Instance.TouchDeltaVector = _touchDeltaVector;
#elif UNITY_ANDROID || UNITY_IOS
            _stringBuilder.Clear();
            _stringBuilder.Append("1");
            _stringBuilder.Append(_touchDeltaVector.x + "," + _touchDeltaVector.y);
            UDPClientManager.Instance.SendData(_stringBuilder.ToString());
            UDPHostManager.Instance.TouchDeltaVector=_touchDeltaVector;
#endif
        }
    }
}
