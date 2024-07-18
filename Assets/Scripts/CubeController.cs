using UnityEngine;

public class CubeController : Singleton<CubeController>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
        Debug.Log("TouchMove _touchDeltaVector=" + UDPHostManager.Instance.TouchDeltaVector);
        transform.Rotate(new Vector3(UDPHostManager.Instance.TouchDeltaVector.y, -UDPHostManager.Instance.TouchDeltaVector.x, 0), Space.World);
    }
}
