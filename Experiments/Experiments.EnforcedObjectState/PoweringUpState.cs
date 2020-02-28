using System;

namespace Experiments.EnforcedObjectState
{
    public class PoweringUpState : IPoweringUpState
    {
        private readonly NuclearReactorInnerWorkings _reactor;

        public PoweringUpState(NuclearReactorInnerWorkings reactor)
        {
            _reactor = reactor;
        }

        public void RigForNormalRunning()
        {
            _reactor.stateMachine.Fire(NuclearReactorInnerWorkings.Operation.RigForNormalRunning);
        }

        public void PerformEmergencyShutDown()
        {
            Console.WriteLine("Emergency shutdown initiated");
            _reactor.MoveControlRods(100);
            _reactor.stateMachine.Fire(NuclearReactorInnerWorkings.Operation.EmergencyShutdown);
        }
    }
}