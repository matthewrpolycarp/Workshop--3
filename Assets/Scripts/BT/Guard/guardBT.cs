using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class guardBT : Tree
    {
        public UnityEngine.Transform[] waypoints_;
        [SerializeField] 
        public Enemy_AI_vars Enemy;


        public static float speed_;
        public static float fovRange_;
        public static float attackRange_;
        public static float attackinterval_;
        public static float rotationSpeed_;

        private void init()
        {
        speed_ = Enemy.speed;
        fovRange_ = Enemy.fovRange;
        attackRange_ = Enemy.attackRange;
        attackinterval_ = Enemy.attackinterval;
        rotationSpeed_ = Enemy.rotationSpeed;

        }
        protected override Node SetupTree()
        {
            init();
            Node root = new Selector
            (
                new List<Node>
                {
                new Sequence(
                    new List<Node>
                    {
                        new checkEnemyAttackRange(transform),
                        new TaskAttack(transform),
                    }
                ),
                new Sequence(
                    new List<Node>
                    {
                        new checkEnemyInFOVRange(transform),
                        new TaskGoToTarget(transform),
                    }
                ),
                new TaskPatrol(transform, waypoints_),
                }
            );
            return root;
        }
    }
}
