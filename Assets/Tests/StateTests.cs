using MG;
using NUnit.Framework;

namespace Tests
{
    public class StateTests
    {
        private class FakeContext {}
        private class FakeState : State<FakeContext>
        {
            public override void UpdateState(float deltaTime) {}
        }

        private class AnotherFakeState : State<FakeContext>
        {
            public override void UpdateState(float deltaTime) {}
        }

        private StateMachine<FakeContext> _stateMachine;

        private FakeContext _fakeContext;
        private FakeState _fakeState;
        private AnotherFakeState _anotherFakeState;


        [SetUp]
        public void Init()
        {
            _fakeContext = new FakeContext();
            _fakeState = new FakeState();
        }
        [Test]
        public void SetCorrectInitialState()
        {
            //Act
            
            _stateMachine = new StateMachine<FakeContext>(_fakeContext);
            _stateMachine.SetInitialState(_fakeState);
            

            //Assert
            
            Assert.IsTrue(_stateMachine.CurrentState.Equals(_fakeState), "The initial state of the state machine is not the same as the set State.");
        }

        [Test]
        public void ChangeStateToCorrectState()
        {
            //Arrange
            _anotherFakeState = new AnotherFakeState();
            //Act
            
            _stateMachine = new StateMachine<FakeContext>(_fakeContext);
            _stateMachine.SetInitialState(_fakeState);
            _stateMachine.AddState(_anotherFakeState);

            //check for false positive
            Assert.IsTrue(!_stateMachine.CurrentState.Equals(_anotherFakeState));
            
            _stateMachine.ChangeState<AnotherFakeState>();
            
            Assert.IsTrue(_stateMachine.CurrentState.Equals(_anotherFakeState));
        }
    }
}
