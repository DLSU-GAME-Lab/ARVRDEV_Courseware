using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    [SerializeField] private GameObject tankRoot;
    [SerializeField] private Rigidbody tankRB;
    [SerializeField] private GameObject tankHead;
    [SerializeField] private GameObject bulletSpawnLocation;
    [SerializeField] private GameObject bulletPrefab;

    [Tooltip("Set to object's position on Start()")]
    [SerializeField] private Vector3 respawnPoint;
    [Space(10)]

    [Header("Vehicle stats")]
    [SerializeField] private float turnRate = 20.0f;
    [SerializeField] private float headTurnRate = 20.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float maxSpeed = 100.0f;

    private Vector3 tankAcceleration = Vector3.zero;
    private float tankRotation = 0.0f;
    private float turretRotation = 0.0f;

    private void Start()
    {
        respawnPoint = tankRoot.transform.position;
    }

    private void Update()
    {
        tankRB.AddForce(tankAcceleration);
        transform.Rotate(Vector3.up * tankRotation);
        tankHead.transform.Rotate(Vector3.up * turretRotation);
    }

    // turns the entire tank
    public void Turn(float direction)
    {
        tankRotation = direction * turnRate * Time.deltaTime;
    }

    // moves the entire tank
    public void Accelerate(float direction)
    {
        if (tankRB.velocity.magnitude > maxSpeed)
        {
            return;
        }

        if (direction == 0)
        {
            tankRB.velocity = Vector3.zero;
        }

        tankAcceleration = direction * moveSpeed * tankRoot.transform.right;
    }

    // turns the turret
    public void RotateTurret(float direction)
    {
        turretRotation = direction * headTurnRate * Time.deltaTime;
    }

    public void Fire()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnLocation.transform.position, bulletSpawnLocation.transform.rotation, tankRoot.transform);
        newBullet.transform.rotation = tankHead.transform.rotation;

        newBullet.GetComponent<Rigidbody>().velocity = Vector3.forward * 1000.0f;
    }

    public void Respawn()
    {
        tankRB.velocity = Vector3.zero;
        tankRoot.transform.SetLocalPositionAndRotation(respawnPoint, Quaternion.identity);

        foreach (Transform childTransform in tankRoot.GetComponentsInChildren<Transform>())
        {
            childTransform.rotation = Quaternion.identity;
        }
    }
}
