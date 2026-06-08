using UnityEngine;

namespace TurnBased.Units
{
    public class UnitVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _selectionVisual;

        private void Awake()
        {
            _selectionVisual.SetActive(false);
        }

        public void ShowSelection()
        {
            _selectionVisual.SetActive(true);
        }

        public void HideSelection()
        {
            _selectionVisual.SetActive(false);
        }
    }
}
