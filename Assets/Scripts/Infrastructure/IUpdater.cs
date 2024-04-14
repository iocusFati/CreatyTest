namespace Infrastructure
{
    public interface IUpdater
    {
        public void AddTickable(IUpdatable updatable);
    }
}