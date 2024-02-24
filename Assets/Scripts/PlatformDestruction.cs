using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour {
    private readonly float radius = 100f;
    private readonly float explosionForce = 1300f;
    private readonly float destroyDelay = 1f;

    [SerializeField] private Transform[] platformCylinderTransforms;
    public void DestroyPlatform() {

        Vector3 explosionPosition = transform.position;

        for (int i = 0; i < platformCylinderTransforms.Length; i++) {
            Transform platformTransform = platformCylinderTransforms[i];

            Rigidbody rb = platformTransform.gameObject.GetComponent<Rigidbody>();
            
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddExplosionForce(explosionForce, explosionPosition, radius);

            MeshCollider boxCollider = platformTransform.gameObject.GetComponent<MeshCollider>();
            boxCollider.enabled = false;
        }

        StartCoroutine(DestroyAfterDelay(gameObject, destroyDelay));
    }

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }

}

