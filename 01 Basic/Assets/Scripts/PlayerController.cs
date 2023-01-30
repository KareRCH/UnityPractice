using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

struct MyVector
{
    public float x;
    public float y;
    public float z;

    public float magnitude {  get {  return Mathf.Sqrt(x*x + y*y + z*z); } }
    public MyVector normalized {  get { return new MyVector ( x / magnitude, y / magnitude, z / magnitude ); } }

    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y* d, a.z * d);
    }
}

    public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        MyVector to = new MyVector(10.0f, 10.0f, 10.0f);
        MyVector from = new MyVector(5.05f, 0.0f, 0.0f);
        MyVector dir = to - from;

        dir = dir.normalized;

        MyVector newPos = from + dir * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);

        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
    }
}
