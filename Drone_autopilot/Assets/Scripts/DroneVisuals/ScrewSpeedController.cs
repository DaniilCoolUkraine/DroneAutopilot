using System.Collections;
using UnityEngine;

namespace DroneAutopilot.DroneVisuals
{
    public class ScrewSpeedController : MonoBehaviour
    {
        private Coroutine _rotationCoroutine;
        
        public void RotateScrew(float speed)
        {
            if (_rotationCoroutine != null)
            {
                StopCoroutine(_rotationCoroutine);
                _rotationCoroutine = null;
            }
            
            _rotationCoroutine = StartCoroutine(RotationCoroutine(speed));
        }

        public void StopRotation()
        {
            StopCoroutine(_rotationCoroutine);
            _rotationCoroutine = null;
        }

        private IEnumerator RotationCoroutine(float speed)
        {
            while (true)
            {
                float angle = speed * Time.deltaTime;
                transform.Rotate(0, angle, 0);

                yield return null;
            }
        }
    }
}