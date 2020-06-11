using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;

public class slingRope : MonoBehaviour {

    public Transform StartPoint;
    public Transform EndPoint;
    public float springForce = 25000f;
    public float linDrag = 50f;
    
    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.25f;
    private int segmentLength = 35;
    private float lineWidth = 0.1f;

    private bool canDo = false;
    //Sling shot 
    private bool moveToMouse = false;
    private Vector3 mousePositionWorld;
    private int indexMousePos;
    private GameObject toThrow = null;
    private EdgeCollider2D col;
    private bool grabbed = false;
    private SpringJoint2D sp;
    private bool isPressed = false;
    private float springDelay;
    private GameObject player;
    private Vector2 springDir;
    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = StartPoint.position;

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }

        // sp = gameObject.AddComponent<SpringJoint2D>();
        // sp.anchor = new Vector2(mid.x - transform.position.x, mid.y - transform.position.y);
        // sp.enabled = false;
        sp = GetComponent<SpringJoint2D>();
        springDelay = 1 / (sp.frequency * 4);
        col = gameObject.AddComponent<EdgeCollider2D>();
        col = GetComponent<EdgeCollider2D>();
        col.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toThrow = other.gameObject;
        }

    }

    private void setSpring()
    {
        sp.enabled = true;
        sp.connectedBody = toThrow.GetComponent<Rigidbody2D>();
        col.enabled = true;
    }

    private void releaseSpring()
    {
        sp.enabled = false;
        toThrow = null;
        col.enabled = false;
    }

    private IEnumerator Release()
    {
        yield return new WaitForSeconds(springDelay);
        col.enabled = true;
        sp.enabled = false;
    }

    private void OnMouseDown()
    {
        isPressed = true;
        sp.enabled = true;
        grabbed = true;
        GetComponent<SpringJoint2D>().connectedBody = toThrow.GetComponent<Rigidbody2D>();
        toThrow.GetComponent<Rigidbody2D>().isKinematic = true;
        
    }

    private void OnMouseUp()
    {
        isPressed = false;
        // releaseSpring();
        grabbed = false;
        toThrow.GetComponent<Rigidbody2D>().isKinematic = false;
        StartCoroutine(Release());
        toThrow = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canDo = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canDo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canDo = false;
            player = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.DrawRope();
        if (canDo && player.GetPhotonView().IsMine)
        {
            mine();
        }
        // mine();
    }

    private void mine()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            this.moveToMouse = true;
            isPressed = true;
            col.enabled = true;
            grabbed = true;
            toThrow.GetComponent<Rigidbody2D>().gravityScale = 0;
        } else if (Input.GetMouseButtonUp(0)) {
            this.moveToMouse = false;
            isPressed = false;
            col.enabled = false;
            if (toThrow)
            {
                var mid = (StartPoint.transform.position + EndPoint.transform.position) / 2;
                springDir = (mid - toThrow.transform.position);
                // toThrow.GetComponent<Rigidbody2D>().fo
                // toThrow.GetComponent<ConstantForce2D>().enabled = true;
                toThrow.GetComponent<Rigidbody2D>().AddForce(springForce * springDir);
                // toThrow.GetComponent<Rigidbody2D>().velocity = (springForce * springDir);
                // toThrow.GetComponent<Rigidbody2D>().AddConstantForce(springDir * springDir);
                StartCoroutine(Release());
                toThrow.GetComponent<Rigidbody2D>().gravityScale = 2;
                // toThrow.GetComponent<ConstantForce2D>().force = Vector2.zero;
                // // toThrow.GetComponent<ConstantForce2D>().enabled = false;
                // toThrow.GetComponent<Rigidbody2D>().gravityScale = 10;
                // toThrow.GetComponent<Rigidbody2D>().drag = linDrag;
            }
            
            grabbed = false;
            toThrow = null;
        }
        
        Vector3 screenMousePos = Input.mousePosition;
        
        if (isPressed)
        {
            if (toThrow)
            {
                toThrow.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenMousePos.x, screenMousePos.y + 30, 10));
            }
        }

        float xStart = StartPoint.position.x;
        float xEnd = EndPoint.position.x;
        this.mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(screenMousePos.x, screenMousePos.y, 10));
        float currX = this.mousePositionWorld.x;

        float ratio = (currX - xStart) / (xEnd - xStart);
        if (ratio > 0) {
            this.indexMousePos = (int)(this.segmentLength * ratio);
        }
    }
    private void FixedUpdate()
    {
        this.Simulate();
        
        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }
        
        // Vector3[] rope/Positions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }
        Vector2[] colliders = new Vector2[ropePositions.Length];
        // Vector2[] colliders = new Vector2[2];
        // colliders[0] = new Vector2(ropePositions[0].x, ropePositions[0].y);
        // colliders[1] = new Vector2(ropePositions[34].x, ropePositions[34].y);
        for (int i = 0; i < ropePositions.Length; i++)
        {
            colliders[i] = new Vector2(ropePositions[i].x - transform.position.x, ropePositions[i].y - transform.position.y);
        }
        // colliders[colliders.Length-1] = colliders[0];
        col.points = colliders.ToArray();
    }

    private void Simulate()
    {
        // SIMULATION
        Vector2 forceGravity = new Vector2(0f, -1f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
        }

        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            this.ApplyConstraint();
        }
        
    }

    private void ApplyConstraint()
    {
        //Constrant to First Point 
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.StartPoint.position;
        this.ropeSegments[0] = firstSegment;


        //Constrant to Second Point 
        RopeSegment endSegment = this.ropeSegments[this.ropeSegments.Count - 1];
        endSegment.posNow = this.EndPoint.position;
        this.ropeSegments[this.ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector2 changeDir = Vector2.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector2 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }

            if (this.moveToMouse && indexMousePos > 0 && indexMousePos < this.segmentLength - 1 && i == indexMousePos) {
                RopeSegment segment = this.ropeSegments[i];
                RopeSegment segment2 = this.ropeSegments[i + 1];
                segment.posNow = new Vector2(this.mousePositionWorld.x, this.mousePositionWorld.y);
                segment2.posNow = new Vector2(this.mousePositionWorld.x, this.mousePositionWorld.y);
                this.ropeSegments[i] = segment;
                this.ropeSegments[i + 1] = segment2;
            }
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
        
    }

    public struct RopeSegment
    {
        public Vector2 posNow;
        public Vector2 posOld;

        public RopeSegment(Vector2 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }
}