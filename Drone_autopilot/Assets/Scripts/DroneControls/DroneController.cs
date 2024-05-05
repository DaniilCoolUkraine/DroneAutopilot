using DroneAutopilot.AI;
using DroneAutopilot.AI.InputSubstitution;
using DroneAutopilot.DroneVisuals;
using UnityEngine;

namespace DroneAutopilot.DroneControls
{
    public class DroneController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        [SerializeField] private ScrewSpeedController[] _droneScrews;
        [SerializeField] private DroneInputController _inputController;
        [SerializeField] private DroneForceController _forceController;

        [SerializeField] private DroneAgent _droneAgent;

        private void Awake()
        {
            if (_droneAgent is null)
            {
                _inputController.Init();
            }
            else
            {
                var topRightInputCalculator = new AiInputCalculator();
                var bottomRightInputCalculator = new AiInputCalculator();
                var topLeftInputCalculator = new AiInputCalculator();
                var bottomLeftInputCalculator = new AiInputCalculator();
                
                _inputController.Init(topRightInputCalculator, bottomRightInputCalculator, topLeftInputCalculator, bottomLeftInputCalculator);
                _droneAgent.Init(topRightInputCalculator, bottomRightInputCalculator, topLeftInputCalculator, bottomLeftInputCalculator);
            }
            
            _forceController.Init(_rigidbody);
        }

        private void Update()
        {
            _droneScrews[0].RotateScrew(_inputController.TopRightRps);
            _droneScrews[1].RotateScrew(_inputController.TopLeftRps);
            _droneScrews[2].RotateScrew(_inputController.BottomLeftRps);
            _droneScrews[3].RotateScrew(_inputController.BottomRightRps);
        }

        private void FixedUpdate()
        {
            _forceController.AddForceToScrew(_droneScrews[0].transform, _inputController.TopRightRps);
            _forceController.AddForceToScrew(_droneScrews[1].transform, _inputController.TopLeftRps);
            // _forceController.AddForceToScrew(_droneScrews[2].transform, _inputController.BottomRightRps);
            _forceController.AddForceToScrew(_droneScrews[2].transform, _inputController.BottomLeftRps);
            _forceController.AddForceToScrew(_droneScrews[3].transform, _inputController.BottomRightRps);
        }
    }
}
