using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Input
{
    public class PlayerInputs : MonoBehaviour
    {
        public event Action OnSwipeLeft;
        public event Action OnSwipeRight;
        
        public Vector2 MoveInput;
        public Vector2 LookInput;

        public PlayerControls controls;

        public static PlayerInputs Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
            controls = new PlayerControls();

            controls.Movement.Move.started += MoveStarted;
        }

        [Header("Settings"), SerializeField] private float m_selectInputCooldown = 0.25f;
        private float m_lastTimeSelectInputReceieved;


        #region Enabling/Disabling Action Maps
        private void Start()
        {
            controls.Enable();
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        private void OnDestroy()
        {
            controls.Disable();
        }
        #endregion

        void Update()
        {
            HandleInputs();
        }

        private void HandleInputs()
        {
            MoveInput = controls.Movement.Move.ReadValue<Vector2>();
            LookInput = controls.Movement.Look.ReadValue<Vector2>();
        }
        
        private void MoveStarted(InputAction.CallbackContext context)
        {
            if (m_lastTimeSelectInputReceieved + m_selectInputCooldown <= Time.time)
            {
                m_lastTimeSelectInputReceieved = Time.time;

                if (context.ReadValue<Vector2>().x <= -0.5f && context.ReadValue<Vector2>().y == 0)
                {
                    OnSwipeLeft?.Invoke();
                }

                if (context.ReadValue<Vector2>().x >= 0.5f && context.ReadValue<Vector2>().y == 0)
                {
                    OnSwipeRight?.Invoke();
                }
            }
        }
    }
}
