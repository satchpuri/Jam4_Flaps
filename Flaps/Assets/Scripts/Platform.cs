using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag =="Player")
        {
            invoke("FallDown", 1f);
        }
    }
}
