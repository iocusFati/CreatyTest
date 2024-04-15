namespace Infrastructure.Update
{
    public interface IUpdater
    {
        public void AddUpdatable(IUpdatable updatable);
    }
}