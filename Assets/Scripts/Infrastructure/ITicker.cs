namespace Infrastructure
{
    public interface ITicker
    {
        public void AddTickable(ITickable tickable);
    }
}