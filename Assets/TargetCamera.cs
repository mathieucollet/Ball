using UnityEngine;
using System.Collections;

public class TargetCamera: MonoBehaviour {
    public GameObject Target;
    void LateUpdate (){
        Vector3 SetZ(Vector3 vector, float z)
        {
            vector.z = z;
            return vector;
        } 
        this.transform.position = Target.transform.position;
        this.transform.position = SetZ(this.transform.position, -10);

    }
}