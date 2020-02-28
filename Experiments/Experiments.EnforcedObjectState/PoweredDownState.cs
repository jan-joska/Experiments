using System;

namespace Experiments.EnforcedObjectState
{
    public class PoweredDownState : IPoweredDownState
    {
        private readonly NuclearReactorInnerWorkings _reactor;

        public PoweredDownState(NuclearReactorInnerWorkings reactor)
        {
            _reactor = reactor;
        }

        public void PowerUp()
        {
            _reactor.CloseHatch();
            _reactor.stateMachine.Fire(NuclearReactorInnerWorkings.Operation.PowerUp);
        }

        public bool PerformPreStartCheck()
        {
            Console.WriteLine("Starting pre start check");
            _reactor.OpenHatch();
            return _reactor.CoreTemperature == 0;
        }
    }
}