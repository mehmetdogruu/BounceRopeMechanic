using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeController : MonoBehaviour
{
    [SerializeField] Transform _node1;
    [SerializeField] Transform _node2;

    [SerializeField] private BoxCollider _collider;

    [SerializeField] Material _longRopeMat;
    [SerializeField] Material _ropeMat;
    private MeshRenderer _meshRendererRope;
    private Rigidbody _rb;

    private ObiSolver _obiSolver;

    private void Start()
    {
        _meshRendererRope = GetComponent<MeshRenderer>();
        _obiSolver = GetComponentInParent<ObiSolver>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        SetSizeOfCollider(_collider);
        SetNodeRotation(_node1,_node2);
        CheckRopeLenght();
    }

    private float GetDistanceBetweenNodes(Transform node1,Transform node2)
    {
        var _distanceBetweenNodes = Vector3.Distance(node1.transform.localPosition, node2.transform.localPosition);
        return _distanceBetweenNodes;
    }
    private void SetNodeRotation(Transform node1,Transform node2) //This method set rotation to collider which we use for bounce the objects. Collider is child object on _node1. 
    {
        node1.transform.LookAt(node2, Vector3.forward);
    }
    private void SetSizeOfCollider(BoxCollider collider)
    {
        collider.size = new Vector3(GetDistanceBetweenNodes(_node1, _node2) * 2 + 0.8f, collider.size.y, collider.size.z);
    }

    private void CheckRopeLenght()
    {
        if (GetDistanceBetweenNodes(_node1,_node2)>2.3f)
        {
            _collider.gameObject.SetActive(false);
            _meshRendererRope.material = _longRopeMat;
            _rb.detectCollisions = false;

            //transform.parent.gameObject.layer = LayerMask.NameToLayer("LongRope");
        }
        else
        {
            _collider.gameObject.SetActive(true);
            _meshRendererRope.material = _ropeMat;
            _rb.detectCollisions = true;

            //transform.parent.gameObject.layer= LayerMask.NameToLayer("Rope");
        }
    }


    //private Vector3 GetMidPointOfNodes(Transform A,Transform B)
    //{
    //    Vector3 midpointAtoB = new Vector3((A.localPosition.x + B.localPosition.x) / 2.0f, (A.localPosition.y + B.localPosition.y) / 2.0f, -0.8f);

    //    return  midpointAtoB;       
    //}









    //    [SerializeField] Transform _node1;
    //    [SerializeField] Transform _node2;
    //    [SerializeField] ObiSolver _solver;

    //    private Camera mainCamLocal;

    //    private void Start()
    //    {
    //        Generate();

    //    }
    //    void Generate()
    //    {
    //        if (_node1!=null && _node2!=null)
    //        {
    //            transform.position = (_node1.position + _node2.position) / 2;
    //            transform.rotation = Quaternion.FromToRotation(Vector3.right, _node2.position - _node1.position);

    //            Vector3 startPositionLS=transform.InverseTransformPoint(_node1.position);
    //            Vector3 endPositionLS = transform.InverseTransformPoint(_node2.position);
    //            Vector3 tangentLS = (endPositionLS - startPositionLS).normalized;

    //            var blueprint = ScriptableObject.CreateInstance<ObiRopeBlueprint>();

    //            blueprint.path.AddControlPoint(startPositionLS, -tangentLS, tangentLS, Vector3.up, .1f, .1f, 1, 1, Color.white, "_node1");
    //            blueprint.path.AddControlPoint(endPositionLS, -tangentLS, tangentLS, Vector3.up, .1f, .1f, 1, 1, Color.white, "_node2");
    //            blueprint.path.FlushEvents();

    //            blueprint.GenerateImmediate();
    //            var rope = gameObject.AddComponent<ObiRope>();
    //            var ropeRenderer = gameObject.AddComponent<ObiRopeExtrudedRenderer>();
    //            var attachment1 = gameObject.AddComponent<ObiParticleAttachment>();
    //            var attachment2 = gameObject.AddComponent<ObiParticleAttachment>();

    //            ropeRenderer.section = Resources.Load<ObiRopeSection>("DefaultRopeSection");

    //            rope.ropeBlueprint = blueprint;

    //            attachment1.target = _node1;
    //            attachment2.target = _node2;
    //            attachment1.particleGroup = blueprint.groups[0];
    //            attachment2.particleGroup = blueprint.groups[1];

    //            //transform.SetParent(_solver.transform);


    //        }
    //    }
    //    private void Update()
    //    {

    //    }
}
