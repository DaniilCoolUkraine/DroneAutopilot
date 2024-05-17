using DroneAutopilot.AI.InputSubstitution;
using DroneAutopilot.General;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace DroneAutopilot.AI
{
    public class DroneAgent : Agent
    {
        [SerializeField] private Transform _target;

        [SerializeField] private Rigidbody _rigidbody;
        
        private AiInputCalculator[] _singleInputCalculators = new AiInputCalculator[4];

        private float _previousDistance = 0;
        private float _previousYposition = 0;
        
        public void Init(AiInputCalculator topRightInputCalculator, AiInputCalculator bottomRightInputCalculator,
            AiInputCalculator topLeftInputCalculator, AiInputCalculator bottomLeftInputCalculator)
        {
            _singleInputCalculators[0] = topRightInputCalculator;
            _singleInputCalculators[1] = topLeftInputCalculator;
            _singleInputCalculators[2] = bottomLeftInputCalculator;
            _singleInputCalculators[3] = bottomRightInputCalculator;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        
        public void AddRewardForTargetHit(int reward)
        {
            AddReward(reward);
            EndEpisode();
            
            Debug.Log("<color=green>Target hit</color>");
        }

        public void AddRewardForGettingCloserToTarget()
        {
            var distance = (transform.localPosition - _target.localPosition).magnitude;
            var normalizedDistance = (_previousDistance - distance) / _previousDistance;
            
            AddReward(normalizedDistance);
            _previousDistance = distance;
        }

        public void SubtractRewardForCollidingWithObstacle(float obstacleWeight)
        {
            AddReward(obstacleWeight);
        }
        
        public void AddRewardForGettingHigher()
        {
            if (_previousYposition < transform.localPosition.y)
            {
                AddReward(Constants.REWARD_FOR_GETTING_HIGHER);
                _previousYposition = transform.localPosition.y;
            }
        }

        public void AddRewardForStayingUp()
        {
            if (transform.up.VectorsApproximatelyEquals(Vector3.up, Constants.TOLERANCE))
            {
                AddReward(Constants.REWARD_FOR_STAYING_UP);
            }

            if (transform.up.VectorsApproximatelyEquals(Vector3.down, Constants.TOLERANCE))
            {
                AddReward(-5);
                EndEpisode();
            }
        }

        public override void OnEpisodeBegin()
        {
            _target.localPosition = new Vector3(Random.Range(-9, 9), Random.Range(0.5f, 5), Random.Range(-9, 9));

            _rigidbody.velocity = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = new Vector3(-_target.localPosition.x, 0.51f, -_target.localPosition.z);

            _previousDistance = (transform.localPosition - _target.position).magnitude;
            _previousYposition = transform.localPosition.y;
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.localPosition);
            sensor.AddObservation(transform.rotation);
            
            sensor.AddObservation(_target.localPosition);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            var discreteActions = actions.DiscreteActions.Array;
            var isScrewActive = discreteActions.ToBool();
            
            // discreteActions.Foreach(i => Debug.Log(i));
            // isScrewActive.Foreach(b => Debug.Log(b));

            for (int i = 0; i < isScrewActive.Length; i++)
            {
                _singleInputCalculators[i].SimulatePress(isScrewActive[i]);
            }
        }
    }
}