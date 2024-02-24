using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour {
    [SerializeField] private Transform[] platformCylinderTransforms;
    private readonly float radius = 100f;

    public void DestroyPlatform(float explosionForce = 700f, float destroyDelay = 0.75f) {

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

    public void SetPlatformMaterial(Material material) {
        for (int i = 0; i < platformCylinderTransforms.Length; i++) {
            Transform platformTransform = platformCylinderTransforms[i];
            Renderer renderer = platformTransform.gameObject.GetComponent<Renderer>();
            renderer.material = material;
        }
    }

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
    }

}

