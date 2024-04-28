using UnityEngine;

namespace DroneAutopilot.Test
{
    public class StayAtPlace : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;
        [SerializeField] private ForceMode _forceMode;
        
        private void FixedUpdate()
        {
            AddForce();
        }

        private void AddForce()
        {
            _rigidbody.AddForce(Vector3.up * _force, _forceMode); 
        }
    }
}