using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace CMF
{
    public class CameraBasicControls : CameraInput
    {

        private BasicControls m_Controls;
        private float horLook;
        private float verLook;

        public override float GetHorizontalCameraInput()
        {
            return horLook;
        }

        public override float GetVerticalCameraInput()
        {
            return verLook;
        }
        private void Awake()
        {
            m_Controls = new BasicControls();
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
            horLook =  look.x;
            verLook = -look.y;
        }
    }
}