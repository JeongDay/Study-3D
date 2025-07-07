using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    public GameObject ps;
    public LayerMask layerMask;
    public float bombTimer = 4f;
    public float bombRange = 10f;

    void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }
    
    IEnumerator Start()
    {
        ps.SetActive(true);
        yield return new WaitForSeconds(bombTimer);
        
        BombForce();
    }

    public void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);
        foreach (var collider in colliders)
        {
            var rb = collider.GetComponent<Rigidbody>();
            
            // AddExplosionForce(폭발 파워, 폭발 위치, 폭발 범위, 폭발 높이)
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}