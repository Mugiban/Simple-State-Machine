# Simple State Machine

A simple implementation of the State Machine pattern in Unity3D. It has an example to demonstrate the functionality.


## **Simple Example**

```
private StateMachine<Unit> _stateMachine;

private void Start()
{
    var patrolling = new PatrollingState();
    var chasing = new ChasingState();
    _stateMachine = new StateMachine<Unit>(this);

    _stateMachine.SetInitialState(patrolling);
    _stateMachine.AddState(chasing);
}

private void Update()
{
    _stateMachine.Update(Time.deltaTime);
}
```



To change the state use the type of the new state.

## **Change State**

```
stateMachine.ChangeState<NewState>();
```
