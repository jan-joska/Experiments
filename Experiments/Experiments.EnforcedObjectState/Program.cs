using System;

namespace Experiments.EnforcedObjectState
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var reactor = new NuclearReactor();

            ((IPoweredDownState) reactor.State).PowerUp();
            ((IPoweringUpState) reactor.State).RigForNormalRunning();
            
            ((IRunningState) reactor.State).SetPowerLevel(10);
            ((IRunningState) reactor.State).SetPowerLevel(20);
            ((IRunningState) reactor.State).SetPowerLevel(30);
            
            // Only state-based features are available on object

            var reactor2 = new NuclearReactor();
            ((IPoweredDownState) reactor2.State).PowerUp();

            var method = reactor2.State.GetType().GetMethod("SetPowerLevel");
            if (method != null)
                method.Invoke(reactor2.State, new object[] {10});
            else
                Console.WriteLine("Method SetPowerLevel not found on object");

            Console.ReadLine();
        }
    }
}