using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class TaskGoToTarget : Node
    {
        private Transform _transform;

        public TaskGoToTarget(Transform transform)
        {
            _transform = transform;
        }

        public override NodeState Tick()
        {
            Transform target = (Transform)GetData("target");
            if (Vector3.Distance(_transform.position, target.position) > 1f)
            {
                // Calculate the distance and direction to the target along the XZ plane
                Vector3 currentPos = new Vector3(_transform.position.x, 0, _transform.position.z);
                Vector3 targetPos = new Vector3(target.position.x, 0, target.position.z);
                Vector3 targetDirection = (targetPos - currentPos).normalized;

                // Move towards the target along the XZ plane, but keep the Y position unchanged
                Vector3 newPosition = _transform.position + targetDirection * guardBT.speed_ * Time.deltaTime;
                newPosition.y = _transform.position.y;
                _transform.position = newPosition;

                // Rotate towards the target along the XZ plane
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * guardBT.rotationSpeed_);
            }
            return NodeState.RUNNING;
        }
    }
}
