using System;
using UnityEngine;

namespace Code.Vehicles
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class VehicleLocomotion : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D m_rigidbody2D;

        [SerializeField] private LayerMask m_bounds;
        
        [Header("Values")]
        [SerializeField] private float m_moveSpeed = 20f;
        [SerializeField] private bool m_isMovingUpwards = false;
        
        private void OnEnable()
        {
            if (m_isMovingUpwards)
            {
                m_rigidbody2D.AddForceY(m_moveSpeed, ForceMode2D.Impulse);
            }
            else
            {
                m_rigidbody2D.AddForceY(-m_moveSpeed, ForceMode2D.Impulse);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((m_bounds.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
