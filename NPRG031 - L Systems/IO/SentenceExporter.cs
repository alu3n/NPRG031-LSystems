namespace NPRG031___L_Systems;

public static class SentenceExporter
{
    public static void ExportAsText(ModelConfiguration configuration, string filePath)
    {
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            outputFile.WriteLine(configuration.derivedSentence);
        }
    }
}