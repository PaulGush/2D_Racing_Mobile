using Code.Input;
using UnityEngine;

namespace Code.Player
{
    public class PlayerVisual : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerLocomotion m_playerLocomotion;
        
        private void OnEnable()
        {
            PlayerInputs.Instance.OnSwipeLeft += PlayerInputs_OnSwipeLeft;
            PlayerInputs.Instance.OnSwipeRight += PlayerInputs_OnSwipeRight;
            m_playerLocomotion.OnChangedLane += PlayerLocomotion_OnChangedLane;
        }

        private void OnDisable()
        {
            PlayerInputs.Instance.OnSwipeLeft -= PlayerInputs_OnSwipeLeft;
            PlayerInputs.Instance.OnSwipeRight -= PlayerInputs_OnSwipeRight;
            m_playerLocomotion.OnChangedLane -= PlayerLocomotion_OnChangedLane;
        }

        private void PlayerInputs_OnSwipeLeft()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 15);
        }

        private void PlayerInputs_OnSwipeRight()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -15);
        }

        private void PlayerLocomotion_OnChangedLane()
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
    }
}
