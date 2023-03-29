using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class MoveCommand: Command
    {
        private Rigidbody _rigidbody;
        private Vector3 _movement;
        public MoveCommand(Rigidbody rigidbody, Vector3 movement)
        {
            _rigidbody = rigidbody;
            _movement = Vector3.zero;
        }
        public void Excecute()
        {
            _rigidbody.AddForce(_movement,ForceMode.Impulse);
        }

        
    }

    
   



