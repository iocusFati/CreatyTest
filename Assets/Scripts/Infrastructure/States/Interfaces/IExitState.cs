namespace Infrastructure
{
    public interface IExitState
    {
        public void Exit();
    }

    public interface IState : IExitState
    {
        public void Enter();
    }
}