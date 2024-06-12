namespace NPRG031___L_Systems;

using System.Globalization;


public static class TurtleInterpretationExporter
{
    public static void ExportAsObj(List<PolygonalLine> lines,string filePath)
    {
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            
            int ptID = 1;
            foreach (var line in lines)
            {
                string printLine = new("l ");
                foreach (var pt in line.points)
                {
                    outputFile.WriteLine("v {0} {1} {2}",pt.x.ToString(culture),pt.y.ToString(culture),pt.z.ToString(culture));
                    printLine += " " + ptID.ToString();
                    ptID++;
                }
                outputFile.WriteLine(printLine);
            }
        }
    }
}