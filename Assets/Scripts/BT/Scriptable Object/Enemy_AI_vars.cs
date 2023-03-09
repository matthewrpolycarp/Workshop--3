using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy", menuName ="Enemy/AI_vars")]
public class Enemy_AI_vars : ScriptableObject
{
    [Header("Movement")]
        //public UnityEngine.Transform[] waypoints_;
        public float speed;
        
        public float rotationSpeed;
        [Header("Agression")]
        public float fovRange;

        public float attackRange;
        public float attackinterval;
    // Start is called before the first frame update
}
