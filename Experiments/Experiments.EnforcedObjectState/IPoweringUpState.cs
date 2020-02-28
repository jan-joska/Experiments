namespace Experiments.EnforcedObjectState
{
    public interface IPoweringUpState : IReactorState
    {
        void RigForNormalRunning();
        void PerformEmergencyShutDown();
    }
}