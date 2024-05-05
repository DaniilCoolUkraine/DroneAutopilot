namespace DroneAutopilot.Utils
{
    public interface IForceCalculator
    {
        public float RpsToForce(float rotation);
    }
}