using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{
    public class TaskAttack : Node
    {
        private float previousDeltaTime;
        public TaskAttack(Transform transform)
        {

        }

        public override NodeState Tick()
        {
            Transform target = (Transform)GetData("Target");

            if ((Time.deltaTime - previousDeltaTime) >  guardBT.attackRange_)
            {
                //Debug.Log("pew");
                //shoot cubes
            }
            return NodeState.RUNNING;
        }

    }
}