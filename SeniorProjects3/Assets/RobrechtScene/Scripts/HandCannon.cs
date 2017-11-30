﻿namespace VRTK.Examples
{
    using UnityEngine;

    public class HandCannon : VRTK_InteractableObject
    {
        public float bulletSpeed = 200f;
        public float bulletLife = 5f;

        private GameObject bullet;
        private VRTK_ControllerEvents controllerEvents;

        private float minTriggerRotation = -10f;
        private float maxTriggerRotation = 45f;

        private void ToggleCollision(Rigidbody objRB, Collider objCol, bool state)
        {
            objRB.isKinematic = state;
            objCol.isTrigger = state;
        }

       


        public override void Grabbed(VRTK_InteractGrab currentGrabbingObject)
        {
            base.Grabbed(currentGrabbingObject);

            controllerEvents = currentGrabbingObject.GetComponent<VRTK_ControllerEvents>();

            //Limit hands grabbing when picked up
            if (VRTK_DeviceFinder.GetControllerHand(currentGrabbingObject.controllerEvents.gameObject) == SDK_BaseController.ControllerHand.Left)
            {
                allowedTouchControllers = AllowedController.LeftOnly;
                allowedUseControllers = AllowedController.LeftOnly;
            }
            else if (VRTK_DeviceFinder.GetControllerHand(currentGrabbingObject.controllerEvents.gameObject) == SDK_BaseController.ControllerHand.Right)
            {
                allowedTouchControllers = AllowedController.RightOnly;
                allowedUseControllers = AllowedController.RightOnly;
            }
        }

        public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
        {
            base.Ungrabbed(previousGrabbingObject);

            //Unlimit hands
            allowedTouchControllers = AllowedController.Both;
            allowedUseControllers = AllowedController.Both;

            controllerEvents = null;
        }

        public override void StartUsing(VRTK_InteractUse currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
                FireBullet();
                VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject), 0.63f, 0.2f, 0.01f);
      
        }

        protected override void Awake()
        {
            base.Awake();
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
        }

        protected override void Update()
        {
            base.Update();
        }

        private void FireBullet()
        {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}