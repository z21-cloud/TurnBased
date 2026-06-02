using TurnBased.PlayerInput;
using TurnBased.PlayerView;
using UnityEngine;

namespace TurnBased.GameBoot
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private InputManager inputManager;

        private void Awake()
        {
            cameraController.Initialize(inputManager);
        }
    }
}
