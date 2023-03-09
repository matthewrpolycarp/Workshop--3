using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence() : base() {}
        public Sequence(List<Node> children) : base(children) {}
        public override NodeState Tick()
        {
            bool childRunning = false;
            foreach (Node node in Children)
            {
                switch(node.Tick())
                {
                    case NodeState.FAILURE:
                        return NodeState.FAILURE;
                    case NodeState.RUNNING:
                        childRunning = true;
                        continue;
                    case NodeState.SUCCES:
                        continue;
                    default:
                        return NodeState.SUCCES;
                        
                } 
            }
            return childRunning ? NodeState.RUNNING : NodeState.SUCCES;
        }
    }
}
