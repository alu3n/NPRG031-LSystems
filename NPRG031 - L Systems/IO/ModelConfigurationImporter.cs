namespace NPRG031___L_Systems;

public static class ModelConfigurationImporter
{
    public static ModelConfiguration LoadConfiguration(string fileName)
    {
        ModelConfiguration configuration = new ModelConfiguration();
        StreamReader configurationStream = new StreamReader(fileName);

        LoadHeader(configurationStream,configuration);
        LoadRules(configurationStream,configuration);
        
        return configuration;
    }

    private static void LoadHeader(StreamReader configurationStream, ModelConfiguration configuration)
    {
        string line = configurationStream.ReadLine();

        if (line == null)
        {
            throw new InvalidConfigurationHeaderException("Header configuration wasn't specified!");
        }

        string[] headerComponents = line.Split(';');

        if (headerComponents.Length != 4)
        {
            throw new InvalidConfigurationHeaderException("Header does not contain exactly 4 components!");
        }

        configuration.distance = float.Parse(headerComponents[0]);
        configuration.angle = float.Parse(headerComponents[1]);
        configuration.axiom = headerComponents[2];
        configuration.stepCount = uint.Parse(headerComponents[3]);

        if (configuration.distance.ToString() != headerComponents[0] | configuration.distance <= 0)
        {
            throw new InvalidConfigurationHeaderException("Distance is invalid!");
        }
        
        if (configuration.angle.ToString() != headerComponents[1] | configuration.angle <= 0)
        {
            throw new InvalidConfigurationHeaderException("Angle is invalid!");
        }
        
        if (configuration.stepCount.ToString() != headerComponents[3])
        {
            throw new InvalidConfigurationHeaderException("Step count is invalid!");
        }
    }

    private static void LoadRules(StreamReader configurationStream, ModelConfiguration configuration)
    {
        string line = configurationStream.ReadLine();

        while (line != null)
        {
            LoadRule(line,configuration);
            line = configurationStream.ReadLine();
        }
    }

    private static void LoadRule(string rule, ModelConfiguration configuration)
    {
        string[] ruleComponents = rule.Split("->");

        if (ruleComponents.Length != 2)
        {
            throw new InvalidRuleConfigurationException("There is a rule that does not have format [left hand side]->[right hand side]");
        }

        if (ruleComponents[0].Length != 1)
        {
            throw new InvalidRuleConfigurationException(
                "There is a rule that does not have a single symbol on the left hand side");
        }
        
        configuration.lSystem.AddRule(ruleComponents[0][0],ruleComponents[1]);
    }
}

public class InvalidRuleConfigurationException : Exception
{
    public InvalidRuleConfigurationException()
    {
        
    }

    public InvalidRuleConfigurationException(string message) : base(message)
    {
        
    }
}

public class InvalidConfigurationHeaderException : Exception
{
    public InvalidConfigurationHeaderException()
    {
        
    }

    public InvalidConfigurationHeaderException(string message) : base(message)
    {
        
    }
}

/*
Input file should have the following formating

FILE FORMAT:
Line 0: [Distance];[Angle];[Initial Sentence];[Number of Steps]
Line 1: [Char C1]->[Sentence S1]
Line 2: [Char C2]->[Sentence S2]
...
Line n+1: [Char Cn]->[Sentence Sn]

INDIVIDUAL COMPONENTS:
[Distance]: Floating point number in the format X,Y, where X is an integer number and Y is a sequence of numbers 0,...,9 and is greater than 0
[Angle]: Same as distance
[Initial Sequence]: Sequence of ASCII characters
[Number of Steps]: Natural number {0,1,2,...}
[Char Ci]: Single ASCII character
[Sentence Si]: Sequence of ASCII characters
*/