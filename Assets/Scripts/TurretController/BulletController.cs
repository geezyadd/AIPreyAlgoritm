using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private Rigidbody _rigidbody;
    private GameObject _target;
    private Rigidbody _targetRigidbody;

    public BulletController SetTarget(GameObject target)
    {
        _target = target;
        return this;
    }

    public void InitializeBullet()
    {
        _targetRigidbody = _target.GetComponent<Rigidbody>();
        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        WaitForFixedUpdate waitforFixedUpdate = new WaitForFixedUpdate();
        float timer = 0;
        while (timer < _timeToDestroy) 
        {   
            Vector3 bulletVelocity = _targetRigidbody.velocity; 
            Vector3 targetVelocity = _rigidbody.velocity;

            Vector3 relativeVelocity = bulletVelocity - targetVelocity;
            Vector3 relativePosition = _target.transform.position - transform.position;

            float interceptionTime = relativePosition.magnitude / relativeVelocity.magnitude;
            Vector3 targetPosition = _target.transform.position + (bulletVelocity * interceptionTime);

            Vector3 directionToTarget = targetPosition - transform.position;
            directionToTarget.Normalize();

            _rigidbody.velocity = directionToTarget * _speed;

            timer += Time.deltaTime;
            yield return waitforFixedUpdate;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
