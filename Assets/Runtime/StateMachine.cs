using System;
using System.Collections.Generic;

namespace MG
{
    public class StateMachine<T>
    {
        private readonly T _context;
        public event Action OnStateChanged;

        private State<T> _currentState;
        public State<T> CurrentState => _currentState;

        private readonly Dictionary<Type, State<T>> _states = new Dictionary<Type, State<T>>();
        
        public StateMachine(T context)
        {
            _context = context;
        }

        public void SetInitialState(State<T> initialState)
        {
            AddState(initialState);
            _currentState = initialState;
            _currentState.Enter();
        }
        public void AddState(State<T> state)
        {
            state.Initialize(this, _context);
            _states[state.GetType()] = state;
        }
        public void Update(float deltaTime)
        {
            _currentState.TryChangeState();
            _currentState.UpdateState(deltaTime);
        }

        public State<T> ChangeState<S>() where S : State<T>
        {
            var newType = typeof(S);

            if (_currentState.GetType() == newType)
                return _currentState;

            _currentState?.Exit();
            
            _states.TryGetValue(newType, out _currentState);
            _currentState?.Enter();
            
            OnStateChanged?.Invoke();

            return _currentState;
        }
    }
}