namespace NPRG031___L_Systems;

public struct Turtle
{
    public Turtle()
    {
        
    }
    public Vector position { get; private set; }

    private Matrix basis = new(
        new Vector(0, 1, 0), //Default "up"
        new Vector(1, 0, 0), //Default "forward"
        new Vector(0, 0, 1) //Default "right"
        );

    public void MoveForward(float distance)
    {
        this.position = position + (distance * basis.col0);
    }
    
    public void TurnLeft(float angle)
    {
        basis = basis * Matrix.RotationMatrixAxisZ(angle);
    }

    public void TurnRight(float angle)
    {
        basis = basis * Matrix.RotationMatrixAxisZ(-angle);
    }

    public void PitchDown(float angle)
    {
        basis = basis * Matrix.RotationMatrixAxisY(angle);
    }

    public void PitchUp(float angle)
    {
        basis = basis * Matrix.RotationMatrixAxisY(-angle);
    }

    public void RollLeft(float angle)
    {
        basis = basis * Matrix.RotationMatrixAxisX(angle);
    }

    public void RollRight(float angle)
    {
        basis = basis * Matrix.RotationMatrixAxisX(-angle);
    }

    public void TurnAround()
    {
        basis = basis * Matrix.RotationMatrixAxisZ(float.Pi);
    }
}