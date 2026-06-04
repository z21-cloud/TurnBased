using TurnBased.PlayerView;
using UnityEngine;

namespace TurnBased.PlayerView
{
    public class MouseVisual : MonoBehaviour
    {
        private IMouseWorldPosition _mouseWorldPosition;
        public void Initialize(IMouseWorldPosition mouseWorldPosition)
        {
            _mouseWorldPosition = mouseWorldPosition;
        }

        void Update()
        {
            if (_mouseWorldPosition == null)
            {
                Debug.LogError("[MouseVisaul] Camera Controller didn't set up! Visual error!");
                return;
            }

            if (_mouseWorldPosition.HasPosition) transform.position = _mouseWorldPosition.MouseWorldPosition;
        }
    }
}

