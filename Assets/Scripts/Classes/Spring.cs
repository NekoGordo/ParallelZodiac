using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///A spring solver system, using Vector3 values. Generates the smoothest possible procedural motion
///</summary>
public class VecSpring
{
    ///<summary>
    ///Euler's number
    ///</summary>
    private float e = 2.718281828459045f;

    ///<summary>
    ///Why isn't this built in?
    ///</summary>
    private Vector3 Multiply(Vector3 a, Vector3 b)
    {
        float x0 = a.x;
        float y0 = a.y;
        float z0 = a.z;
        float x1 = b.x;
        float y1 = b.y;
        float z1 = b.z;

        return new Vector3(x0 * x1, y0 * y1, z0 * z1);
    }

    ///<summary>
    ///Damper, or the bouncyness of the spring.
    ///</summary>
    private float d = 0;

    ///<summary>
    ///Speed, or how quickly the point reaches the target.
    ///</summary>
    private float s = 0;

    ///<summary>
    ///The current point of the spring.
    ///</summary>
    private Vector3 p0 = new Vector3();

    ///<summary>
    ///The current target position of the spring.
    ///</summary>
    private Vector3 p1 = new Vector3();

    ///<summary>
    ///The current velocity of the spring.
    ///</summary>
    private Vector3 v0 = new Vector3();

    ///<summary>
    ///The target velocity of the spring.
    ///</summary>
    private Vector3 v1 = new Vector3();

    ///<summary>
    ///Last time that the spring updated at.
    ///</summary>
    private float t0 = 0;

    //Functions

    ///<summary>
    ///Update the position and velocity of the spring, also returns the updated position.
    ///</summary>
    void posvel(float d, float s, Vector3 p0, Vector3 v0, Vector3 p1, Vector3 v1, float x, out Vector3 nP, out Vector3 nV)
    {
        if (s == 0) //Don't do extra math lul
        {
            nP = p0;
            nV = v0;
        }

        else if (d < 1 - 1e-8f)
        {
            float h = Mathf.Pow((1 - d * d), .5f);
            Vector3 c1 = (p0 - p1 + 2 * d / s * v1);
            Vector3 c2 = d / h * (p0 - p1) + v0 / (h * s) + (2 * d * d - 1) / (h * s) * v1;
            float co = Mathf.Cos(h * s * x);
            float si = Mathf.Sin(h * s * x);
            float ex = Mathf.Pow(e, d * s * x);

            nP = co / ex * c1 + si / ex * c2 + p1 + (x - 2 * d / s) * v1;
            nV = s * (co * h - d * si) / ex * c2 - s * (co * d + h * si) / ex * c1 + v1;

        }

        else if (d > 1 - 1e-8f)
        {
            Vector3 c1 = p0 - p1 + 2 / s * v1;
            Vector3 c2 = p0 - p1 + (v0 + v1) / s;
            float ex = Mathf.Pow(e, s * x);

            nP = (c1 + c2 * s * x) / ex + p1 + (x - 2 / s) * v1;
            nV = v1 - s / ex * (c1 + (s * x - 1) * c2);
        }
        else
        {
            float h = Mathf.Pow((d * d - 1), .5f);
            Vector3 x0 = (v1 - v0) / (2 * s * h);
            Vector3 x1 = d / s * v1 - (p1 - p0) / 2;
            Vector3 c1 = (1 - d / h) * x1 + x0;
            Vector3 c2 = (1 + d / h) * x1 - x0;
            float co = Mathf.Pow(e, (-(h + d) * s * x));
            float si = Mathf.Pow(e, (h + d) * s * x);

            nP = c1 * co + c2 * si + p1 + (x - 2 * d / s) * v1;
            nV = si * (h - d) * s * c2 - co * (d + h) * s * c1 + v1;

        }
    }

    ///<summary>
    ///Get an updated target position
    ///</summary>
    void Targpv(out Vector3 nP, out Vector3 nV)
    {
        float x = Time.time - t0;
        nP = p1 + x * v1;
        nV = v1;
    }

    //Public Stuff
    ///<summary>
    ///The current point of the spring.
    ///</summary>
    public Vector3 Position
    {
        //get => posvel(d,s,p0,v0,p1,v1,Time.time-t0); Unity doesn't recognise.
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); t0 = Time.time; return p0; }
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            p0 = value;
            Targpv(out p1, out v1);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The current velocity of the spring.
    ///</summary>
    public Vector3 Velocity
    {
        get
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            t0 = Time.time;
            return v0;
        }
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            v0 = value;
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The current target position of the spring.
    ///</summary>
    public Vector3 Target
    {
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); Targpv(out p1, out v1); t0 = Time.time; return p1; }
        set
        {
            float x = Time.time - t0;
            p1 = value;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The target velocity of the spring.
    ///</summary>
    public Vector3 TargetVelocity
    {
        get { return v1; }
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            v1 = value;
            Targpv(out p1, out v1);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The bouncyness of the spring.
    ///</summary>
    public float Damper
    {
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); t0 = Time.time; return d; }
        set
        {
            d = value;
            posvel(d, s, p0, v0, p1, v1, Time.time - t0, out p0, out v0);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///How quickly the point reaches the target.
    ///</summary>
    public float Speed
    {
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); t0 = Time.time; return s; }
        set
        {
            float x = Time.time - t0;
            s = value;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///Add acceleration to the spring.
    ///</summary>
    public Vector3 Acceleration
    {
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            Targpv(out p1, out v1);
            v0 = v0 + value;
            t0 = Time.time;
        }
    }
}

///<summary>
///A spring solver system, using Float values. Generates the smoothest possible procedural motion
///</summary>
public class FSpring
{
    ///<summary>
    ///Euler's number
    ///</summary>
    private float e = 2.718281828459045f;

    ///<summary>
    ///Damper, or the bouncyness of the spring.
    ///</summary>
    private float d = 0;

    ///<summary>
    ///Speed, or how quickly the point reaches the target.
    ///</summary>
    private float s = 0;

    ///<summary>
    ///The current point of the spring.
    ///</summary>
    private float p0 = new float();

    ///<summary>
    ///The current target position of the spring.
    ///</summary>
    private float p1 = new float();

    ///<summary>
    ///The current velocity of the spring.
    ///</summary>
    private float v0 = new float();

    ///<summary>
    ///The target velocity of the spring.
    ///</summary>
    private float v1 = new float();

    ///<summary>
    ///Last time that the spring updated at.
    ///</summary>
    private float t0 = 0;

    //Functions

    ///<summary>
    ///Update the position and velocity of the spring, also returns the updated position.
    ///</summary>
    void posvel(float d, float s, float p0, float v0, float p1, float v1, float x, out float nP, out float nV)
    {
        if (s == 0) //Don't do extra math lul
        {
            nP = p0;
            nV = v0;
        }

        else if (d < 1 - 1e-8f)
        {
            float h = Mathf.Pow((1 - d * d), .5f);
            float c1 = (p0 - p1 + 2 * d / s * v1);
            float c2 = d / h * (p0 - p1) + v0 / (h * s) + (2 * d * d - 1) / (h * s) * v1;
            float co = Mathf.Cos(h * s * x);
            float si = Mathf.Sin(h * s * x);
            float ex = Mathf.Pow(e, d * s * x);

            nP = co / ex * c1 + si / ex * c2 + p1 + (x - 2 * d / s) * v1;
            nV = s * (co * h - d * si) / ex * c2 - s * (co * d + h * si) / ex * c1 + v1;

        }

        else if (d > 1 - 1e-8f)
        {
            float c1 = p0 - p1 + 2 / s * v1;
            float c2 = p0 - p1 + (v0 + v1) / s;
            float ex = Mathf.Pow(e, s * x);

            nP = (c1 + c2 * s * x) / ex + p1 + (x - 2 / s) * v1;
            nV = v1 - s / ex * (c1 + (s * x - 1) * c2);
        }
        else
        {
            float h = Mathf.Pow((d * d - 1), .5f);
            float x0 = (v1 - v0) / (2 * s * h);
            float x1 = d / s * v1 - (p1 - p0) / 2;
            float c1 = (1 - d / h) * x1 + x0;
            float c2 = (1 + d / h) * x1 - x0;
            float co = Mathf.Pow(e, (-(h + d) * s * x));
            float si = Mathf.Pow(e, (h + d) * s * x);

            nP = c1 * co + c2 * si + p1 + (x - 2 * d / s) * v1;
            nV = si * (h - d) * s * c2 - co * (d + h) * s * c1 + v1;

        }
    }

    ///<summary>
    ///Get an updated target position
    ///</summary>
    void Targpv(out float nP, out float nV)
    {
        float x = Time.time - t0;
        nP = p1 + x * v1;
        nV = v1;
    }

    //Public Stuff
    ///<summary>
    ///The current point of the spring.
    ///</summary>
    public float Position
    {
        //get => posvel(d,s,p0,v0,p1,v1,Time.time-t0); Unity doesn't recognise.
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); t0 = Time.time; return p0; }
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            p0 = value;
            Targpv(out p1, out v1);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The current velocity of the spring.
    ///</summary>
    public float Velocity
    {
        get
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            t0 = Time.time;
            return v0;
        }
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            v0 = value;
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The current target position of the spring.
    ///</summary>
    public float Target
    {
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); Targpv(out p1, out v1); t0 = Time.time; return p1; }
        set
        {
            float x = Time.time - t0;
            p1 = value;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The target velocity of the spring.
    ///</summary>
    public float TargetVelocity
    {
        get { return v1; }
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            v1 = value;
            Targpv(out p1, out v1);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///The bouncyness of the spring.
    ///</summary>
    public float Damper
    {
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); t0 = Time.time; return d; }
        set
        {
            d = value;
            posvel(d, s, p0, v0, p1, v1, Time.time - t0, out p0, out v0);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///How quickly the point reaches the target.
    ///</summary>
    public float Speed
    {
        get { float x = Time.time - t0; posvel(d, s, p0, v0, p1, v1, x, out p0, out v0); t0 = Time.time; return s; }
        set
        {
            float x = Time.time - t0;
            s = value;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            t0 = Time.time;
        }
    }

    ///<summary>
    ///Add acceleration to the spring.
    ///</summary>
    public float Acceleration
    {
        set
        {
            float x = Time.time - t0;
            posvel(d, s, p0, v0, p1, v1, x, out p0, out v0);
            Targpv(out p1, out v1);
            v0 = v0 + value;
            t0 = Time.time;
        }
    }
}
