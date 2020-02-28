namespace Experiments.EnforcedObjectState
{
    public class RunningState : IRunningState
    {
        private readonly NuclearReactorInnerWorkings _reactor;

        public RunningState(NuclearReactorInnerWorkings reactor)
        {
            _reactor = reactor;
        }

        public void PerformEmergencyShutDown()
        {
            _reactor.MoveControlRods(100);
            _reactor.stateMachine.Fire(NuclearReactorInnerWorkings.Operation.EmergencyShutdown);
        }

        public void SetPowerLevel(int percentage)
        {
            _reactor.MoveControlRods(100 - percentage);
        }
    }
}