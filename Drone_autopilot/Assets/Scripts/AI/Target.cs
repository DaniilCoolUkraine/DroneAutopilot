using UnityEngine;

namespace DroneAutopilot.AI
{
    public class Target : MonoBehaviour
    {
        [Range(1, 5)]
        [SerializeField] private int _reward;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DroneAgent>(out var agent))
            {
                agent.AddRewardForTargetHit(_reward);
            }
        }
    }
}