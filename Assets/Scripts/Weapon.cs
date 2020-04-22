using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform barrelTip;

    [SerializeField]
    private GameObject rocket;

    public Quaternion shootingRotation;
    private Vector2 aimDirection;
    private float lookAngle;
    public float thrust;

    void Update()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);

        float angle = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        shootingRotation = Quaternion.Euler(0, 0, angle - 90);
        if (transform.position.magnitude > 1000.0f)
            Destroy(gameObject);

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 0);

        if (Input.GetMouseButtonDown(0))
        {
            FireRocket();
        }
    }

    private void FireRocket()
    {
        GameObject firedRocket = Instantiate(rocket, barrelTip.position, barrelTip.rotation);
        firedRocket.GetComponent<Rigidbody2D>().velocity = barrelTip.right * thrust;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Rocket controller = other.GetComponent<Rocket>();

        if (controller != null && (other.gameObject.tag == "Enemy"))
        {
            Destroy(other);
        }
    }
}
