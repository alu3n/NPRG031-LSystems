using System.Security.Cryptography;

namespace NPRG031___L_Systems;

public class TurtleInterpreter(float alpha, float delta)
{
    public List<PolygonalLine> InterpretSentence(string sentence)
    {
        List<PolygonalLine> lines = new();
        PolygonalLine currentLine = new();
        Stack<Turtle> turtlesStack = new();

        Turtle turtle = new();
        
        for (int i = 0; i < sentence.Length; ++i)
        {
            switch (sentence[i])
            {
                case 'F':
                    if (currentLine.empty)
                    {
                        currentLine.AddPoint(turtle.position);
                    }
                    turtle.MoveForward(delta);
                    currentLine.AddPoint(turtle.position);
                    break;
                case 'f':
                    if (!currentLine.empty)
                    {
                        lines.Add(currentLine);
                        currentLine = new PolygonalLine();
                    }
                    turtle.MoveForward(delta);
                    break;
                case '+':
                    turtle.TurnLeft(alpha);
                    break;
                case '-':
                    turtle.TurnRight(alpha);
                    break;
                case '&':
                    turtle.PitchDown(alpha);
                    break;
                case '^':
                    turtle.PitchUp(alpha);
                    break;
                case (char)92:
                    turtle.RollLeft(alpha);
                    break;
                case '/':
                    turtle.RollRight(alpha);
                    break;
                case '|':
                    turtle.TurnAround();
                    break;
                case '[':
                    turtlesStack.Push(turtle);
                    break;
                case ']':
                    turtle = turtlesStack.Pop();
                    lines.Add(currentLine);
                    currentLine = new PolygonalLine();
                    break;
                default:
                    break;
            }
        }

        if (!currentLine.empty)
        {
            lines.Add(currentLine);
        }
        return lines;
    }
}