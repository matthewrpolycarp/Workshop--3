using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class checkEnemyInFOVRange : Node
    {
        private static int _enemyLayerMask = 1 << 6;
        private Transform _transform;
        private Collider col;

        public checkEnemyInFOVRange(Transform transform)
        {
            _transform = transform;
            col = _transform.GetChild(0).GetComponent<Collider>();
        }


        bool IsVisible()
        {
            //Check to see if the mutant is inside of the field of view of the camera
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
            return GeometryUtility.TestPlanesAABB(planes, col.bounds);
        }

        public override NodeState Tick()
        {
            object target = GetData("target");

            if(IsVisible())
            {
                return NodeState.FAILURE;
            }

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
