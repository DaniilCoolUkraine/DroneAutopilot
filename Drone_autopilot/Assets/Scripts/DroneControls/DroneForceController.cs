using DroneAutopilot.Utils;
using UnityEngine;

namespace DroneAutopilot.DroneControls
{
    public class DroneForceController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private IForceCalculator _forceCalculator;

        public void Init(Rigidbody rb, IForceCalculator forceCalculator = null)
        {
            _forceCalculator = forceCalculator ?? new ForceCalculator();
            _rigidbody = rb;
        }
        
        public void AddForceToScrew(Transform screw, float rps)
        {
            _rigidbody.AddForceAtPosition(transform.up * _forceCalculator.RpsToForce(rps), screw.position, ForceMode.Force);
        }
    }
}