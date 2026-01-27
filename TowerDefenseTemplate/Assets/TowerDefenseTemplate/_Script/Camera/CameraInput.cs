using Unity.Cinemachine;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    public CinemachineInputAxisController controller;

    private void Update()
    {
        controller.enabled = Input.GetMouseButton(0);
    }
}
