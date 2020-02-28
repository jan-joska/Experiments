namespace Experiments.EnforcedObjectState
{
    public interface IPoweredDownState : IReactorState
    {
        void PowerUp();
    }
}