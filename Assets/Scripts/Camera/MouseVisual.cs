using TurnBased.PlayerView;
using UnityEngine;

public class MouseVisual : MonoBehaviour
{
    private CameraController _cameraController;
    public void Initialize(CameraController cameraController)
    {
        _cameraController = cameraController;
    }

    void Update()
    {
        if(_cameraController == null)
        {
            Debug.LogError("[MouseVisaul] Camera Controller didn't set up! Visual error!");
            return;
        }    

        if(_cameraController.HasHit) transform.position = _cameraController.CurrentHit.point;
    }
}
