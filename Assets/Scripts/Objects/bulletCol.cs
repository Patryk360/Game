using UnityEngine;

public class bulletCol : MonoBehaviour
{
    public GameObject holePrefab;
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        
        GameObject hole = Instantiate(holePrefab, contact.point, Quaternion.LookRotation(contact.normal));
        MeshRenderer mesh = hole.GetComponent<MeshRenderer>();
        Light lightSet = hole.GetComponent<Light>();
        mesh.enabled = true;
        lightSet.enabled = true;

        Destroy(hole, 1);
        
        Destroy(gameObject);
    }
}
