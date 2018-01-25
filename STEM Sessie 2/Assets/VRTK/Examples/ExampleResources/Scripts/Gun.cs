namespace VRTK.Examples
{
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        public GameObject bullet;
        private GameObject bulletSpawn;
        private float bulletSpeed = 1000f;
        private float bulletLife = 5f;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            FireBullet();
        }

        protected void Start()
        {
            bulletSpawn = transform.Find("BulletSpawn").gameObject;
            //bullet.SetActive(false);
        }

        private void FireBullet()
        {
            GameObject bulletClone = Instantiate(bullet, bulletSpawn.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}