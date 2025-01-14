﻿using UnityEngine;

// Change the size of sprite based on velocity
namespace Visuals.DeformOnMovement
{
    public class ScaleByVelocity : MonoBehaviour
    {
        public enum Axis
        {
            X,
            Y
        }

        public Axis axis = Axis.Y;

        public float bias = 1f;

        public new Rigidbody2D rigidbody;

        private Vector2 startScale;
        public float strength = 1f;

        private void Start()
        {
            startScale = transform.localScale;
        }

        private void Update()
        {
            var velocity = rigidbody.velocity.magnitude;

            if (Mathf.Approximately(velocity, 0f))
                return;

            var amount = velocity * strength + bias;
            var inverseAmount = 1f / amount * startScale.magnitude;

            switch (axis)
            {
                case Axis.X:
                    transform.localScale = new Vector3(amount, inverseAmount, 1f);
                    return;
                case Axis.Y:
                    transform.localScale = new Vector3(inverseAmount, amount, 1f);
                    return;
            }
        }
    }
}