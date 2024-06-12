namespace NPRG031___L_Systems;

public record struct Matrix(Vector col0, Vector col1, Vector col2)
{
    public void Transpose()
    {
        Vector newCol0 = new(col0.x, col1.x, col2.x);
        Vector newCol1 = new(col0.y, col1.y, col2.y);
        Vector newCol2 = new(col0.z, col1.z, col2.z);

        col0 = newCol0;
        col1 = newCol1;
        col2 = newCol2;
    }

    public static Matrix operator *(Matrix A, Matrix B)
    {
        A.Transpose();
        
        return new Matrix(
            new Vector(A.col0 * B.col0, A.col1 * B.col0, A.col2 * B.col0),
            new Vector(A.col0 * B.col1, A.col1 * B.col1, A.col2 * B.col1),
            new Vector(A.col0 * B.col2, A.col1 * B.col2, A.col2 * B.col2)
        );
    }
    
    static public Matrix RotationMatrixAxisX(float angle)
    {
        //Clockwise rotation around X Axis
        
        Vector X = new(1,0,0);
        Vector Y = new(0, float.Cos(angle), -float.Sin(angle));
        Vector Z = new(0,float.Sin(angle),float.Cos(angle));

        return new Matrix(X, Y, Z);
    }

    static public Matrix RotationMatrixAxisY(float angle)
    {
        //Clockwise rotation around Y Axis
        
        Vector X = new(float.Cos(angle), 0, -float.Sin(angle));
        Vector Y = new(0, 1, 0);
        Vector Z = new(float.Sin(angle), 0, float.Cos(angle));

        return new Matrix(X, Y, Z);
    }

    static public Matrix RotationMatrixAxisZ(float angle)
    {
        //Clockwise rotation around Z Axis
        
        Vector X = new(float.Cos(angle),float.Sin(angle),0);
        Vector Y = new(-float.Sin(angle),float.Cos(angle),0);
        Vector Z = new(0,0,1);

        return new Matrix(X, Y, Z);
    }
}