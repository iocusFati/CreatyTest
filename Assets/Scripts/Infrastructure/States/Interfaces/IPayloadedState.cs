namespace Infrastructure
{
    public interface IPayloadedState<TPayload> : IExitState
    {
        public void Enter(TPayload sceneName);
    }
}