using System;
using DroneAutopilot.DroneVisuals;
using DroneAutopilot.InputReader;
using UnityEngine;

namespace DroneAutopilot.DroneControls
{
    public class DroneController : MonoBehaviour
    {
        [SerializeField] private ScrewSpeedController[] _droneScrews;
        [SerializeField] private Rigidbody _rigidbody;

        private ISingleInputCalculator _upForceCalculator;
        private ISingleInputCalculator _downForceCalculator;
        private IVectorInputCalculator _directionCalculator;
        
        private void Start()
        {
            Init();
        }

        public void Init(ISingleInputCalculator upForceCalculator, ISingleInputCalculator downForceCalculator,
            IVectorInputCalculator directionCalculator)
        {
            _upForceCalculator = upForceCalculator;
            _downForceCalculator = downForceCalculator;
            _directionCalculator = directionCalculator;
        }

        public void Init()
        {
            _upForceCalculator = new UpForceCalculator();
            _downForceCalculator = new DownForceCalculator();
            _directionCalculator = new MovementDirectionCalculator();
        }

        private void FixedUpdate()
        {
            int upForceInput = _upForceCalculator.Calculate();
            int downForceInput = _downForceCalculator.Calculate();

            Vector2 direction = _directionCalculator.Calculate();

            if (upForceInput > downForceInput)
            {
                //push up
                // _rigidbody.AddForce();
            }
            else if (upForceInput < downForceInput)
            {
                //push down
            }
            
            
        }
    }
}
