using System;
using Stateless;

namespace Experiments.EnforcedObjectState
{
    public class NuclearReactorInnerWorkings
    {
        public enum Operation
        {
            PowerUp,
            RigForNormalRunning,
            EmergencyShutdown
        }

        public enum ReactorState
        {
            ShutDown,
            PoweringUp,
            Running
        }

        private static readonly Random Rnd = new Random();

        private int _controlRodsInsertationPercentage;

        public StateMachine<ReactorState, Operation> stateMachine;

        public NuclearReactorInnerWorkings()
        {
            var poweredDownState = new PoweredDownState(this);
            var poweringUpState = new PoweringUpState(this);
            var runningState = new RunningState(this);

            State = poweredDownState;

            var sm = new StateMachine<ReactorState, Operation>(ReactorState.ShutDown);

            sm.Configure(ReactorState.ShutDown)
                .OnEntry(() => State = poweredDownState).Permit(Operation.PowerUp, ReactorState.PoweringUp);

            sm.Configure(ReactorState.PoweringUp)
                .OnEntry(() => State = poweringUpState)
                .Permit(Operation.EmergencyShutdown, ReactorState.ShutDown)
                .Permit(Operation.RigForNormalRunning, ReactorState.Running);

            sm.Configure(ReactorState.Running)
                .OnEntry(() => State = runningState);

            sm.OnTransitioned(transition =>
                Console.WriteLine(
                    $"Reactor state machine changes state from {transition.Source} to {transition.Destination} by trigger {transition.Trigger}"));

            stateMachine = sm;
        }

        public int CoreTemperature
        {
            get
            {
                if (stateMachine.IsInState(ReactorState.Running)) return 350 - _controlRodsInsertationPercentage;
                if (stateMachine.IsInState(ReactorState.PoweringUp)) return Rnd.Next(50, 60);
                return 0;
            }
        }

        // All state-dependent features are exposed here
        public IReactorState State { get; private set; }

        public void OpenHatch()
        {
            Console.WriteLine("Opening reactor hatch");
        }

        public void CloseHatch()
        {
            Console.WriteLine("Closing reactor hatch");
        }

        public void MoveControlRods(int percentage)
        {
            Console.WriteLine($"Inserting control rods to {percentage} %");
            _controlRodsInsertationPercentage = percentage;
        }
    }
}