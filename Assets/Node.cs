using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE,
    }

    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        public Node()
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            foreach (Node child in children)
                _Attach(child);
        }

        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;

        private Dictionary<string, object> _dataContext =
            new Dictionary<string, object>();

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
            {
                value = _dataContext[key];
                return value;
            }
               

             Node node = parent;
         while (node != null)
           { 
                value = node.GetData(key);
               if (value != null)
               {
                    return value;
               }
                    
                node = node.parent;
            }
            
             
         
          return null;
       
        }
       
          
        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }
           

            Node node = parent;
            while(node != null)
            {
                bool cleared = node.ClearData(key);
                if (cleared)
                    return true;
                node = node.parent;
            }
            return false;
        }

        public class Sequence: Node
        {
            public Sequence(): base()
            {

            }

            public Sequence(List<Node> children): base(children)
            {

            }

            public override NodeState Evaluate()
            {
                bool anyChildIsRunning = false;
                foreach (Node node in children)
                {
                    switch (node.Evaluate())
                    {
                        case NodeState.FAILURE:

                            state = NodeState.FAILURE;
                            return state;

                        case NodeState.SUCCESS:
                            continue;

                        case NodeState.RUNNING:
                            anyChildIsRunning = true;
                            return state;
                    }

                   
                    
                }
                state = anyChildIsRunning ? NodeState.RUNNING :
                       NodeState.SUCCESS;
                return state;
            }
        }

        public class Selector: Node
        {
            public Selector() : base()
            {
               
            }

            public Selector(List<Node> children) : base(children)
            {

            }

            public override NodeState Evaluate()
            {
                foreach (Node node in children)
                {
                    switch (node.Evaluate())
                    {
                        case NodeState.FAILURE:

                            continue;

                        case NodeState.SUCCESS:
                            state = NodeState.SUCCESS;

                            return state;

                        case NodeState.RUNNING:
                            state = NodeState.RUNNING;

                            return state;

                        default:
                            continue;
                    }

                   
                }
                state = NodeState.FAILURE;

                return state;
            }
        }

    }
}
