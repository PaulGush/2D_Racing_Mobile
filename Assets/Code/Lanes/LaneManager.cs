using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Lanes
{
    public class LaneManager : MonoBehaviour
    {
        public static LaneManager Instance;
        
        public event Action OnLanesInitialized;
        
        [ShowInInspector] public Lane[] Lanes = new Lane[5];

        private void Awake()
        {
            #region Singleton

            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            #endregion
        }

        private void Start()
        {
            InitializeLanes();
        }

        public Lane GetLeftLane(Lane lane)
        {
            int currentLaneIndex = Array.IndexOf(Lanes, lane);
            
            if (currentLaneIndex - 1 < 0)
            {
                return lane;
            }
            else
            {
                return Lanes[currentLaneIndex - 1];
            }
        }

        public Lane GetRightLane(Lane lane)
        {
            int currentLaneIndex = Array.IndexOf(Lanes, lane);
            
            if (currentLaneIndex + 1 > Lanes.Length - 1)
            {
                return lane;
            }
            else
            {
                return Lanes[currentLaneIndex + 1];
            }
        }

        public Lane GetLaneFromWorldPosition(Vector3 position)
        {
            for (int i = 0; i < Lanes.Length; i++)
            {
                Vector3 newPosition = new Vector3(position.x, Lanes[i].transform.position.y, Lanes[i].transform.position.z); 
                
                if (Lanes[i].transform.position == newPosition)
                {
                    return Lanes[i];
                }
            }
            
            return null;
        }

        private void InitializeLanes()
        {
            Lanes = new Lane[5];
            
            for (int i = 0; i < transform.GetComponentsInChildren<Lane>().Length; i++)
            {
                Lanes[i] = transform.GetComponentsInChildren<Lane>()[i];
            }
            
            OnLanesInitialized?.Invoke();
        }
    }
}
