using System.Collections;
using Code.Input;
using Code.Lanes;
using UnityEngine;

namespace Code.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerLocomotion : MonoBehaviour
    {
        [Header("Values")] 
        [SerializeField] private float m_moveSpeed = 100f;
        
        [Header("References")]
        [SerializeField] private Rigidbody2D m_rigidbody;
        [SerializeField] private Collider2D m_collider;
        
        [SerializeField] private Lane m_currentLane;
        
        private void OnEnable()
        {
            PlayerInputs.Instance.OnSwipeLeft += PlayerInputs_OnSwipeLeft;
            PlayerInputs.Instance.OnSwipeRight += PlayerInputs_OnSwipeRight;
            LaneManager.Instance.OnLanesInitialized += LaneManager_OnLanesInitialized;
        }

        private void OnDisable()
        {
            PlayerInputs.Instance.OnSwipeLeft -= PlayerInputs_OnSwipeLeft;
            PlayerInputs.Instance.OnSwipeRight -= PlayerInputs_OnSwipeRight;
            LaneManager.Instance.OnLanesInitialized -= LaneManager_OnLanesInitialized;
        }

        private void PlayerInputs_OnSwipeLeft()
        {
            m_currentLane = LaneManager.Instance.GetLeftLane(m_currentLane);
            StartCoroutine(MoveToPosition(m_currentLane.transform.position));
        }

        private void PlayerInputs_OnSwipeRight()
        {
            m_currentLane = LaneManager.Instance.GetRightLane(m_currentLane);
            StartCoroutine(MoveToPosition(m_currentLane.transform.position));
        }

        private IEnumerator MoveToPosition(Vector3 position)
        {
            while (transform.position != position)
            {
                transform.position = Vector3.Slerp(transform.position, position, m_moveSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            
            transform.position = position;
        }

        private void LaneManager_OnLanesInitialized()
        {
            m_currentLane = LaneManager.Instance.GetLaneFromWorldPosition(transform.position);
        }
    }
}
