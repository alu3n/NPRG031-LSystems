using System.Runtime.CompilerServices;

namespace NPRG031___L_Systems;

public static class View
{
    public static void DisplayHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("- help");
        Console.WriteLine("- templates");
        Console.WriteLine("- template [template name]");
        Console.WriteLine("- display current configuration");
        Console.WriteLine("- derive sentence");
        Console.WriteLine("- display derived sentence");
        Console.WriteLine("- clear configuration");
        Console.WriteLine("- set axiom [axiom]");
        Console.WriteLine("- add rule [{CHAR}->{STRING}]");
        Console.WriteLine("- load configuration [{filename}.txt]");
        Console.WriteLine("- set step count [integer]");
        Console.WriteLine("- save turtle interpretation [{filename}.obj]");
        Console.WriteLine("- save derived sentence [{filename}.txt]");
    }

    public static void DisplayConfiguration(ModelConfiguration configuration)
    {
        Console.WriteLine("Axiom: '{0}'", configuration.axiom);
        Console.WriteLine("Step Count: {0}", configuration.stepCount);
        Console.WriteLine("Distance: {0}", configuration.distance);
        Console.WriteLine("Angle: {0}", configuration.angle);

        if (configuration.lSystem.rules.Count == 0)
        {
            Console.WriteLine("Rules: {}");
            return;
        }

        Console.WriteLine("Rules: {");
        foreach (var rule in configuration.lSystem.rules)
        {
            Console.WriteLine("   {0}->{1}",rule.Key,rule.Value);
        }
        Console.WriteLine("}");
        
    }

    public static void InvalidRequest(Exception exception)
    {
        Console.WriteLine("There was an problem in processing your request");
        Console.WriteLine(exception.Message);
    }

    public static void DerivationComplete(string derivedSentence)
    {
        Console.WriteLine("Derivation was successful!");
    }

    public static void DisplayDerivedSentence(string derivedSentence)
    {
        Console.WriteLine("Your derived sentence is:");
        Console.WriteLine(derivedSentence);
    }

    public static void ConfigurationLoadComplete(ModelConfiguration configuration)
    {
        Console.WriteLine("Your configuration was loaded successfully!");
        Console.WriteLine("This is your current configuration:");
        DisplayConfiguration(configuration);
    }

    public static void ConfigurationCleared(ModelConfiguration configuration)
    {
        Console.WriteLine("Your configuration was cleared successfully!");
        Console.WriteLine("This is your current configuration:");
        DisplayConfiguration(configuration);
    }

    public static void RuleAdded(char leftHandSide, string rightHandSide)
    {
        Console.WriteLine("Rule {0}->{1} was added successfully!",leftHandSide,rightHandSide);
    }

    public static void AxiomSet(string axiom)
    {
        Console.WriteLine("You have successfully set '{0}' as your axiom!",axiom);
    }

    public static void StepCountSet(uint stepCount)
    {
        Console.WriteLine("You have successfully set step count to {0}", stepCount);
    }

    public static void TurtleSaved(string fileName)
    {
        Console.WriteLine("Turtle interpretation of the derived sentence was successfully saved to file " + fileName);
    }

    public static void SentenceSaved(string fileName)
    {
        Console.WriteLine("You have successfully save your derived sentence to file "+ fileName);
    }

    public static void LoadExceptionRule(Exception exception)
    {
        Console.WriteLine("Loading configuration failed while loading rules.");
        Console.WriteLine(exception.Message);
    }

    public static void LoadExceptionHeader(Exception exception)
    {
        Console.WriteLine("Loading configuration failed while loading header.");
        Console.WriteLine(exception.Message);
    }
    
    public static void AddingRuleException(Exception exception)
    {
        Console.WriteLine("Adding your rule failed.");
        Console.WriteLine(exception.Message);
    }
    
    public static void SettingStepCountFailed(Exception exception)
    {
        Console.WriteLine("Setting step count failed.");
        Console.WriteLine(exception.Message);
    }

    public static void SavingTurtleFailed(Exception exception)
    {
        Console.WriteLine("Saving turtle failed.");
        Console.WriteLine(exception.Message);
    }

    public static void InvalidTemplate(Exception exception)
    {
        Console.WriteLine("Loading template failed.");
        Console.WriteLine(exception.Message);
    }

    public static void ProcessTemplatesRequest()
    {
        Console.WriteLine("Available templates are:");
        Console.WriteLine("- KochSnowflake");
        Console.WriteLine("- KochIsland");
        Console.WriteLine("- HilbertCurve2D");
        Console.WriteLine("- HilbertCurve3D");
        Console.WriteLine("- Tree2D");
        Console.WriteLine("- Tree3D");
        Console.WriteLine("To use template use the following syntax: template [template name]");
    }

    public static void TemplateLoaded(string templateName)
    {
        Console.WriteLine("Template {0} was successfully loaded!", templateName);
    }
}