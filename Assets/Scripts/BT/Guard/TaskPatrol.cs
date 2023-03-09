using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{


    public class TaskPatrol : Node
    {
        private Transform _transform;
        private Transform[] _waypoints;
        private int _currentWaypointIndex = 0;
        public float waitTime_;
        private float _previousDeltaTime = 0;
        private bool _waiting = false;

        public TaskPatrol(Transform transform, Transform[] waypoints)
        {
            _transform = transform;
            _waypoints = waypoints;
        }

        public override NodeState Tick()
        {
            if (_waiting)
            {
                if (_previousDeltaTime - Time.deltaTime > waitTime_)
                {
                    _waiting = false;
                }
            }
            else
            {
                Transform goal = _waypoints[_currentWaypointIndex];
                if (Vector3.Distance(_transform.position, goal.position) < 0.1f)
                {
                    _transform.position = goal.position;
                    _previousDeltaTime = Time.deltaTime;
                    _waiting = true;
                    _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Length;
                }
                else
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, goal.position, guardBT.speed_ * Time.deltaTime);
                    _transform.LookAt(goal.position);
                }
            }
            return NodeState.RUNNING;
        }
    }
}
