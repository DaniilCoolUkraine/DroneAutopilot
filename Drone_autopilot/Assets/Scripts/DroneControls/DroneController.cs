using System;
using DroneAutopilot.DroneVisuals;
using UnityEngine;

namespace DroneAutopilot.DroneControls
{
    public class DroneController : MonoBehaviour
    {
        [SerializeField] private ScrewSpeedController[] _droneScrews;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private DroneInputController _droneInputController;

        private void Awake()
        {
            _droneInputController.Init();
        }

        private void Update()
        {
            Debug.Log($"[{nameof(DroneController)}] TopRightRps: {_droneInputController.TopRightRps}");
            Debug.Log($"[{nameof(DroneController)}] TopLeftRps: {_droneInputController.TopLeftRps}");
            Debug.Log($"[{nameof(DroneController)}] BottomLeftRps: {_droneInputController.BottomLeftRps}");
            Debug.Log($"[{nameof(DroneController)}] BottomRightRps: {_droneInputController.BottomRightRps}");
            
            _droneScrews[0].RotateScrew(_droneInputController.TopRightRps);
            _droneScrews[1].RotateScrew(_droneInputController.TopLeftRps);
            _droneScrews[2].RotateScrew(_droneInputController.BottomLeftRps);
            _droneScrews[3].RotateScrew(_droneInputController.BottomRightRps);
        }

        private void FixedUpdate()
        {
            
        }
    }
}
