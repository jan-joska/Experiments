namespace DomainModel
{
    public interface ISnapshotable<THost, TSnapshot> where TSnapshot : class, new()
    {
        TSnapshot CreateSnapshot();
        THost RehydrateFromSnapshot(TSnapshot snapshot);
    }
}