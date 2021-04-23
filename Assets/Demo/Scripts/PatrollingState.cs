using UnityEngine;

namespace MG
{
    public class PatrollingState : State<Unit>
    {
        private Vector3 currentTarget;
        public override void TryChangeState()
        {
            if(Vector3.Distance(_context.Target.position, _context.transform.
                position) < _context.detectionRange)
            {
                _stateMachine.ChangeState<ChasingState>();
            }
        }
        public override void UpdateState(float deltaTime)
        {
            if (Vector3.Distance(currentTarget, _context.transform.position) < 1f)
            {
                currentTarget = RandomPointInSquare(Vector3.zero, new Vector3(40, 0, 40));
            }
            var direction = currentTarget - _context.transform.position;
            _context.transform.rotation = Quaternion.Lerp(_context.transform.rotation, Quaternion.LookRotation(direction), _context.rotationSpeed * deltaTime);
            _context.transform.position += direction.normalized * (_context.speed * deltaTime);
        }
        
        
        
        private static Vector3 RandomPointInSquare(Vector3 center, Vector3 size) {
 
            return center + new Vector3(
                (Random.value - 0.5f) * size.x,
                (Random.value - 0.5f) * size.y,
                (Random.value - 0.5f) * size.z
            );
        }

    }
}