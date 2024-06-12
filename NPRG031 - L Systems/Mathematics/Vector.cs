namespace NPRG031___L_Systems;

public record struct Vector(float x, float y, float z)
{
    // Matrix-style vector multiplication
    public static float operator *(Vector a, Vector b)
    {
        return a.x * b.x + a.y * b.y +  a.z * b.z;
    }
    
    // Scalar-vector multiplication
    public static Vector operator *(float a, Vector v)
    {
        return new Vector(a * v.x, a * v.y, a * v.z);
    }

    // Element-wise vector addition
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
}