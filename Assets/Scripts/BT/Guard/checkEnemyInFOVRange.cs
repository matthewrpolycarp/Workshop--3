using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class checkEnemyInFOVRange : Node
    {
        private static int _enemyLayerMask = 1 << 6;
        private Transform _transform;

        public checkEnemyInFOVRange(Transform transform)
        {
            _transform = transform;
        }

        public override NodeState Tick()
        {
            object target = GetData("target");
            if (target == null)
            {
                Collider[] colliders = Physics.OverlapSphere(_transform.position, guardBT.fovRange_, _enemyLayerMask);
                if (colliders.Length > 0)
                {
                    parent.parent.SetData("target", colliders[0].transform);
                    return NodeState.SUCCES;
                }
                return NodeState.FAILURE;
            }
            return NodeState.SUCCES;
        }


    }
}
