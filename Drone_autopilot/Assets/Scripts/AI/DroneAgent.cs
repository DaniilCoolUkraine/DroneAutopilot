using DroneAutopilot.AI.InputSubstitution;
using DroneAutopilot.General;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace DroneAutopilot.AI
{
    public class DroneAgent : Agent
    {
        private AiInputCalculator[] _singleInputCalculators = new AiInputCalculator[4];

        public void Init(AiInputCalculator topRightInputCalculator, AiInputCalculator bottomRightInputCalculator,
            AiInputCalculator topLeftInputCalculator, AiInputCalculator bottomLeftInputCalculator)
        {
            _singleInputCalculators[0] = topRightInputCalculator;
            _singleInputCalculators[1] = topLeftInputCalculator;
            _singleInputCalculators[2] = bottomLeftInputCalculator;
            _singleInputCalculators[3] = bottomRightInputCalculator;
        }
        
        public override void OnActionReceived(ActionBuffers actions)
        {
            Debug.Log("<color=green>===========</color>");
            
            var discreteActions = actions.DiscreteActions.Array;
            var isScrewActive = discreteActions.ToBool();
            
            discreteActions.Foreach(i => Debug.Log(i));
            isScrewActive.Foreach(b => Debug.Log(b));

            for (int i = 0; i < isScrewActive.Length; i++)
            {
                _singleInputCalculators[i].SimulatePress(isScrewActive[i]);
            }
        }
    }
}