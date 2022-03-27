using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;

namespace CMF
{
    public class HandlerBasicControl : CharacterInput
    {
        public UnityEvent FireEvent; 
        private BasicControls m_Controls;
        private float horMove;
        private float verMove;

        private bool isJumpPressed = false;

        public override float GetHorizontalMovementInput()
        {
            return horMove;
        }

        public override float GetVerticalMovementInput()
        {
            return verMove;
        }

        public override bool IsJumpKeyPressed()
        {
            return isJumpPressed;
        }

        private void Awake()
        {
            m_Controls = new BasicControls();
            m_Controls.Basic.jump.performed += ctx => {isJumpPressed = true;};
            m_Controls.Basic.jump.canceled += ctx => {isJumpPressed = false;};
            m_Controls.Basic.fire.performed += ctx => {FireEvent.Invoke();};
        }

        public void OnEnable()
        {
            m_Controls.Enable();
        }

        public void OnDisable()
        {
            m_Controls.Disable();
        }

        public void Update()
        {
            var look = m_Controls.Basic.look.ReadValue<Vector2>();
            var move = m_Controls.Basic.move.ReadValue<Vector2>();
            horMove = move.x;
            verMove = move.y;
        }
    }
}