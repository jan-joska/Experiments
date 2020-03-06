namespace Experiments.EnforcedObjectState
{
    public class NuclearReactor
    {
        private readonly NuclearReactorInnerWorkings _innerWorkings;

        public NuclearReactor()
        {
            _innerWorkings = new NuclearReactorInnerWorkings();
        }

        public int CoreTemperature => _innerWorkings.CoreTemperature;

        public dynamic State => _innerWorkings.State;
    }
}