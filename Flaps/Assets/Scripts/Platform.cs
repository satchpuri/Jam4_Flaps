using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag =="Player")
        {
            Invoke("MoveTile", 0.5f);
        }
    }
    private void MoveTile()
    {
        this.GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(this.transform.parent.gameObject, 2f);
    }
}
