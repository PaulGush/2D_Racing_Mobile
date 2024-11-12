using System;
using Code.Input;
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
        
        private void OnEnable()
        {
            PlayerInputs.Instance.OnSwipeLeft += PlayerInputs_OnSwipeLeft;
            PlayerInputs.Instance.OnSwipeRight += PlayerInputs_OnSwipeRight;
        }

        private void FixedUpdate()
        {
            
        }

        private void OnDisable()
        {
            PlayerInputs.Instance.OnSwipeLeft -= PlayerInputs_OnSwipeLeft;
            PlayerInputs.Instance.OnSwipeRight -= PlayerInputs_OnSwipeRight;
        }

        private void PlayerInputs_OnSwipeLeft()
        {
            transform.Translate(Vector3.left * 1.5f);
        }

        private void PlayerInputs_OnSwipeRight()
        {
            transform.Translate(Vector3.right * 1.5f);
        }
    }
}
