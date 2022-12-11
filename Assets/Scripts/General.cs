using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public SceneNode root;
    public float HP;
    public float ATK;
    public float DEF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Matrix4x4 i = Matrix4x4.identity;
        root.CompositeXform(ref i);
    }

    public void PhysicalAttack()
    {
        // do scenenode transformation
        StartCoroutine(attackRoutine());
    }

    public void PhysicalDefend()
    {
        // do scenenode transformation
        StartCoroutine(defendRoutine());
    }

    IEnumerator attackRoutine()
    {
        Transform body = transform.Find("Body");
        Transform rightarm = body.Find("RightArm");
        Vector3 nRightarm = rightarm.up;
        Quaternion q = Quaternion.AngleAxis(-90f, nRightarm);
        float distance = rightarm.Find("Geom").Find("Arm").localScale.y;
        Vector3 pivot = rightarm.localPosition + nRightarm * distance / 2;
        rightarm.localPosition = q * (rightarm.localPosition - pivot) + pivot;
        rightarm.localRotation = q * rightarm.localRotation;
        // turn right small arm
        Transform rightsmallarm = rightarm.Find("Arm");
        Vector3 nRighrsmallarm = rightsmallarm.forward;
        q = Quaternion.AngleAxis(90f, nRighrsmallarm);
        distance = rightsmallarm.Find("Geom").Find("Arm").localScale.y;
        pivot = rightsmallarm.localPosition + rightsmallarm.forward * distance / 2;
        rightsmallarm.localPosition = q * (rightsmallarm.localPosition - pivot) + pivot;
        rightsmallarm.localRotation = q * rightsmallarm.localRotation;
        yield return new WaitForSeconds(1);
        root.Reset();
    }

    IEnumerator defendRoutine()
    {
        Transform body = transform.Find("Body");
        Transform rightarm = body.Find("LeftArm");
        Vector3 nRightarm = rightarm.up;
        Quaternion q = Quaternion.AngleAxis(-90f, nRightarm);
        float distance = rightarm.Find("Geom").Find("Arm").localScale.y;
        Vector3 pivot = rightarm.localPosition + nRightarm * distance / 2;
        rightarm.localPosition = q * (rightarm.localPosition - pivot) + pivot;
        rightarm.localRotation = q * rightarm.localRotation;
        // turn right small arm
        Transform rightsmallarm = rightarm.Find("Arm");
        Vector3 nRighrsmallarm = rightsmallarm.forward;
        q = Quaternion.AngleAxis(90f, nRighrsmallarm);
        distance = rightsmallarm.Find("Geom").Find("Arm").localScale.y;
        pivot = rightsmallarm.localPosition + rightsmallarm.forward * distance / 2;
        rightsmallarm.localPosition = q * (rightsmallarm.localPosition - pivot) + pivot;
        rightsmallarm.localRotation = q * rightsmallarm.localRotation;
        yield return new WaitForSeconds(1);
        root.Reset();
    }

    public void MagicAttack()
    {
        // do scenenode transformation
    }

    public void MagicDefense()
    {
        // do scenenode transformation
    }

    public void ReceiveDamage(float damage)
    {
        HP -= damage;
        // need to check death
    }
}
