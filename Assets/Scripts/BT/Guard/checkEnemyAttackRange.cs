using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class checkEnemyAttackRange : Node
    {
        //private static int _enemyLayerMask = 1 << 6;
        private Transform _transform;
        
        public checkEnemyAttackRange(Transform transform)
        {
            _transform = transform;

        }

        public override NodeState Tick()
        {
            object enemy = GetData("target");
            if(enemy == null)
            {
                return NodeState.FAILURE;
            }

            Transform target = (Transform)enemy;
            if(Vector3.Distance(_transform.position, target.position) <= guardBT.attackRange_)
            {
                return NodeState.SUCCES;
            }
        return NodeState.FAILURE;
        }
    }
}
