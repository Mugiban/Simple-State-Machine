using UnityEngine;

namespace MG
{
    public class Unit : MonoBehaviour
    {
        [Header("Unit")]
        [Range(1f, 30f)] public float speed = 2f;
        [SerializeField] [Range(0f, 10f)] public float detectionRange = 2f;
        [Range(1f, 30f)] public float rotationSpeed = 10f;
        
        public Transform Target;
        private StateMachine<Unit> _stateMachine;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, detectionRange);
        }

        private void Start()
        {
            var patrolling = new PatrollingState();
            var chasing = new ChasingState();
            _stateMachine = new StateMachine<Unit>(this, patrolling);
            
            _stateMachine.AddState(chasing);
        }

        private void Update()
        {
            _stateMachine.Update(Time.deltaTime);
        }
    }
}
