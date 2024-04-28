using System;
using UnityEngine;

namespace DroneAutopilot.Test
{
    public class AddForceAtPos : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform[] _screws;
        [SerializeField] private float _force;
        [SerializeField] private ForceMode _forceMode;

        [SerializeField] private float _forcesCoef;

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.E))
            {
                AddForce();
            }
        }

        private void AddForce()
        {
            _rigidbody.AddForceAtPosition(transform.up * _force, _screws[0].position, _forceMode);
            _rigidbody.AddForceAtPosition(transform.up * _force, _screws[1].position, _forceMode);

            _rigidbody.AddForceAtPosition(transform.up * _force * _forcesCoef, _screws[2].position, _forceMode);
            _rigidbody.AddForceAtPosition(transform.up * _force * _forcesCoef, _screws[3].position, _forceMode);
        }
    }
}