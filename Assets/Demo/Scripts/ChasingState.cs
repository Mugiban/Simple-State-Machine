using UnityEngine;

namespace MG
{
    public class ChasingState : State<Unit>
    {
        public override void TryChangeState()
        {
            
            if(Vector3.Distance(_context.Target.position, _context.transform.
                position) > _context.detectionRange)
            {
                _stateMachine.ChangeState<PatrollingState>();
            }
        }

        private Color storedColor;
        public override void Enter()
        {
            base.Enter();
            var mesh = _context.GetComponent<MeshRenderer>();
            storedColor = mesh.material.color;
            mesh.material.color = Color.red;
        }

        public override void Exit()
        {
            base.Exit();
            
            var mesh = _context.GetComponent<MeshRenderer>();
            mesh.material.color = storedColor;
        }

        public override void UpdateState(float deltaTime)
        {
            if (Vector3.Distance(_context.Target.position, _context.transform.position) < 2f)
            {
                return;
            }
            var direction = _context.Target.position - _context.transform.position;
            _context.transform.rotation = Quaternion.Lerp(_context.transform.rotation, Quaternion.LookRotation(direction), _context.rotationSpeed * deltaTime);
            _context.transform.position += direction.normalized * (_context.speed * deltaTime);
        }
    }
}