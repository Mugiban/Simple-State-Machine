using System;
using UnityEngine;

namespace MG
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask ground;
        [Range(1f, 30f)] public float Speed = 2f;
        [Range(1f, 30f)] public float RotationSpeed = 10f;

        private Vector3 currentTarget;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentTarget = GetMouseGroundPosition();
            }

            if (currentTarget == Vector3.zero) 
                return;
            
            if (Vector3.Distance(transform.position, currentTarget) < 1f)
                return;

            currentTarget.y = 0;
            var direction = currentTarget - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 10f * Time.deltaTime);
            
            transform.position += direction.normalized * (Speed * Time.deltaTime);
            
        }

        private Vector3 GetMouseGroundPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, ground))
            {
                return hitInfo.point;
            }
            
            return Vector3.zero;
        }
    }
}
