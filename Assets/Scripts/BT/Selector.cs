using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Node
    {
        public Selector() : base() {}
        public Selector(List<Node> children) : base(children) {}
        public override NodeState Tick()
        {
            foreach (Node node in Children)
            {
                switch(node.Tick())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.RUNNING:
                        return NodeState.RUNNING;
                    case NodeState.SUCCES:
                        return NodeState.SUCCES;
                    default:
                        continue;
                        
                } 
            }
            return NodeState.FAILURE;
        }
    }
}
