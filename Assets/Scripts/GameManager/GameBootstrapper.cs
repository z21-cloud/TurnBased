using TurnBased.PlayerInput;
using TurnBased.PlayerView;
using UnityEngine;

namespace TurnBased.GameBoot
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private MouseVisual _cursosVisual;

        private void Awake()
        {
            _cameraController.Initialize(_inputManager);
            _cursosVisual.Initialize(_cameraController);
        }
    }
}
