    using UnityEngine;

    public class Shooter : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bulletPrefab;
        public float bulletSpeed = 20f;


        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            Vector2 shootingDirection = (mousePosition - firePoint.position).normalized;

            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = shootingDirection * bulletSpeed;

            Destroy(bullet, 5f);  // 在此处添加代码以在5秒后销毁子弹   
            Debug.Log("Shooting direction: " + shootingDirection);  // 输出射击方向，帮助调试
        }
    }
