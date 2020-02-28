namespace Experiments.EnforcedObjectState
{
    public interface IRunningState : IReactorState
    {
        void PerformEmergencyShutDown();
        void SetPowerLevel(int percentage);
    }
}