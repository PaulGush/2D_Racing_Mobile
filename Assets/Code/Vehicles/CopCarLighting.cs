using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Code.Vehicles
{
    public class CopCarLighting : MonoBehaviour
    {
        [SerializeField] private Light2D m_blue;
        [SerializeField] private Light2D m_red;

        [SerializeField] private float m_interval = 1f;
        private void OnEnable()
        {
            StartCoroutine(AlternateLights());
        }

        private IEnumerator AlternateLights()
        {
            m_blue.enabled = true;
            
            while(true)
            {
                yield return new WaitForSeconds( m_interval);

                if (m_blue.enabled)
                {
                    m_blue.enabled = false;
                    m_red.enabled = true;
                }
                else
                {
                    m_blue.enabled = true;
                    m_red.enabled = false;
                }
            }
        }
    }
}
