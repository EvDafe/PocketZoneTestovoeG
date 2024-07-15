namespace Assets.Scripts.Infrastructure.States
{
    public interface IState : IExitableState
    {
        public void Enter();
    }

    public interface IExitableState
    {
        public void Exit();
    }

    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        public void Enter(TPayLoad payLoad);
    }

    public interface IDoublePayLoadedState<PPayLoad, HPayLoad> : IExitableState
    {
        public void Enter(PPayLoad payLoad, HPayLoad payload1);
    }

    public interface ITriplePayloadedState<HPayLoad, UPayLoad, IPayLoad> : IExitableState
    {
        public void Enter(HPayLoad payLoad, UPayLoad payLoad1, IPayLoad payLoad2);
    }

    public interface IPlayerState : IState { }
}