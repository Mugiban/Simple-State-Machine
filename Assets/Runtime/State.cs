namespace MG
{
    public abstract class State<T>
    {
        protected T _context;

        protected StateMachine<T> _stateMachine;
        public void Initialize(StateMachine<T> stateMachine, T context)
        {
            _stateMachine = stateMachine;
            _context = context;
        }
        public virtual void  TryChangeState() { }
        
        public virtual void Enter() { }
        
        public abstract void UpdateState(float deltaTime);

        public virtual void Exit() { }
    }
}