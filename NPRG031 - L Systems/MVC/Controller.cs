using NPRG031___L_Systems.LSystem_Factory;

namespace NPRG031___L_Systems;

public class Controller
{
    private Model model = new Model();

    public void ProcessRequest(string request)
    {
        Console.Clear();
        try
        {
            if (!ProcessSimpleRequests(request))
            {
                if (!ProcessComplexRequests(request))
                {
                    throw new InvalidRequestException();
                }
            }
        }
        catch (Exception exception)
        {
            if (exception.GetType() == typeof(InvalidRuleConfigurationException))
            {
                View.LoadExceptionRule(exception);
            }
            else if (exception.GetType() == typeof(InvalidConfigurationHeaderException))
            {
                View.LoadExceptionHeader(exception);
            }
            else if (exception.GetType() == typeof(InvalidRuleException))
            {
                View.AddingRuleException(exception);
            }
            else if (exception.GetType() == typeof(InvalidStepCountException))
            {
                View.SettingStepCountFailed(exception);
            }
            else if (exception.GetType() == typeof(SavingTurtleInterpretationFailedException))
            {
                View.SavingTurtleFailed(exception);
            }
            else if (exception.GetType() == typeof(InvalidTemplateException))
            {
                View.InvalidTemplate(exception);
            }
            else
            {
                View.InvalidRequest(exception);
            }
        }
    }

    private bool ProcessSimpleRequests(string request)
    {
        switch (request)
        {
            case "help":
                ProcessHelpRequest();
                return true;
            case "display current configuration":
                ProcessDisplayCurrentConfigurationRequest();
                return true;
            case "derive sentence":
                ProcessDeriveSentenceRequest();
                return true;
            case "display derived sentence":
                ProcessDisplayDerivedSentenceRequest();
                return true;
            case "clear configuration":
                ProcessClearConfigurationRequest();
                return true;
            case "templates":
                ProcessTemplatesRequest();
                return true;
        }
        
        return false;
    }

    private bool ProcessComplexRequests(string request)
    {
        string[] words = request.Split(' ');

        switch (words.Length)
        {
            case 2:
                return ProcessBinaryRequest(words);
            case 3:
                return ProcessTernaryProcessRequest(words);
            case 4:
                return ProcessQuaternaryRequestRequest(words);
            default:
                return false;
        }
    }

    private bool ProcessBinaryRequest(string[] words)
    {
        if (words[0] != "template")
        {
            throw new InvalidRequestException();
        }

        switch (words[1])
        {
            case "KochSnowflake":
                model.configuration = LSystemFactory.KochSnowflake();
                break;
            case "KochIsland":
                model.configuration = LSystemFactory.KochIsland();
                break;
            case "HilbertCurve2D":
                model.configuration = LSystemFactory.HilbertCurve2D();
                break;
            case "HilbertCurve3D":
                model.configuration = LSystemFactory.HilbertCurve3D();
                break;
            case "Tree2D":
                model.configuration = LSystemFactory.Tree2D();
                break;
            case "Tree3D":
                model.configuration = LSystemFactory.Tree3D();
                break;
            default:
                throw new InvalidTemplateException("This template does not exist!");
        }
        View.TemplateLoaded(words[1]);
        
        return true;
    }
    private bool ProcessTernaryProcessRequest(string[] words)
    {
        if (words[0] == "set" & words[1] == "axiom")
        {
            return ProcessSetAxiomRequest(words[2]);
        }
        
        if (words[0] == "add" & words[1] == "rule")
        {
            return ProcessAddRuleRequest(words[2]);
        }

        if (words[0] == "load" & words[1] == "configuration")
        {
            return ProcessLoadConfigurationRequest(words[2]);
        }

        return false;
    }

    private bool ProcessQuaternaryRequestRequest(string[] words)
    {
        if (words[0] == "set" & words[1] == "step" & words[2] == "count")
        {
            return ProcessSetStepCountRequest(words[3]);
        }

        if (words[0] == "save" & words[1] == "turtle" & words[2] == "interpretation")
        {
            return ProcessSaveTurtleInterpretationRequest(words[3]);
        }

        if (words[0] == "save" & words[1] == "derived" & words[2] == "sentence")
        {
            return ProcessSaveDerivedSentenceRequest(words[3]);
        }

        return false;
    }

    private void ProcessHelpRequest()
    {
        View.DisplayHelp();
    }

    private void ProcessTemplatesRequest()
    {
        View.ProcessTemplatesRequest();
    }

    private void ProcessDisplayCurrentConfigurationRequest()
    {
        View.DisplayConfiguration(model.configuration);
    }

    private void ProcessDeriveSentenceRequest()
    {
        model.DeriveSentence();
        View.DerivationComplete(model.configuration.derivedSentence);
    }

    private void ProcessDisplayDerivedSentenceRequest()
    {
        View.DisplayDerivedSentence(model.configuration.derivedSentence);
    }

    private void ProcessClearConfigurationRequest()
    {
        model.ClearConfiguration();
        View.ConfigurationCleared(model.configuration);
    }

    private bool ProcessSetAxiomRequest(string request)
    {
        model.configuration.axiom = request;
        View.AxiomSet(request);
        return true;
    }

    private bool ProcessAddRuleRequest(string request)
    {
        string[] ruleComponents = request.Split("->");

        if (ruleComponents.Length != 2)
        {
            throw new InvalidRuleException("This rule does not have the correct format [left hand side]->[right hand side]");
        }

        if (ruleComponents[0].Length != 1)
        {
            throw new InvalidRuleException("This rule does not have a single symbol on the left hand side");
        }
        model.configuration.lSystem.AddRule(ruleComponents[0][0],ruleComponents[1]);
        
        View.RuleAdded(ruleComponents[0][0],ruleComponents[1]);
        
        return true;
    }

    private bool ProcessLoadConfigurationRequest(string request)
    {
        model.configuration = ModelConfigurationImporter.LoadConfiguration(request);
        View.ConfigurationLoadComplete(model.configuration);
        return true;
    }

    private bool ProcessSetStepCountRequest(string request)
    {
        try
        {
            uint newStepCount = uint.Parse(request);
            if (newStepCount.ToString() == request)
            {
                model.configuration.stepCount = newStepCount;
                View.StepCountSet(newStepCount);
            }
            else
            {
                throw new Exception();
            }
        }
        catch
        {
            throw new InvalidStepCountException("The step count you've entered isn't formatted properly.");
        }
        
        return true;
    }

    private bool ProcessSaveTurtleInterpretationRequest(string request)
    {
        try
        {
            TurtleInterpreter turtleInterpreter = new TurtleInterpreter(model.configuration.angle, model.configuration.distance);
            List<PolygonalLine> lines = turtleInterpreter.InterpretSentence(model.configuration.derivedSentence);
            TurtleInterpretationExporter.ExportAsObj(lines,request);
            View.TurtleSaved(request);
        }
        catch
        {
            throw new SavingTurtleInterpretationFailedException("Saving turtle interpretation to the file " + request + " was unsuccessful.");
        }
        
        return true;
    }

    private bool ProcessSaveDerivedSentenceRequest(string request)
    {
        SentenceExporter.ExportAsText(model.configuration,request);
        View.SentenceSaved(request);
        return true;
    }




}

public class InvalidRequestException : Exception
{
    public InvalidRequestException()
    {
        
    }

    public InvalidRequestException(string message) : base(message)
    {
        
    }
}

public class InvalidRuleException : Exception
{
    public InvalidRuleException()
    {
        
    }

    public InvalidRuleException(string message) : base(message)
    {
        
    }
}

public class InvalidStepCountException : Exception
{
    public InvalidStepCountException()
    {
        
    }

    public InvalidStepCountException(string message) : base(message)
    {
        
    }
}

public class SavingTurtleInterpretationFailedException : Exception
{
    public SavingTurtleInterpretationFailedException()
    {
        
    }

    public SavingTurtleInterpretationFailedException(string message) : base(message)
    {
        
    }
}

public class InvalidTemplateException : Exception
{
    public InvalidTemplateException()
    {
        
    }

    public InvalidTemplateException(string message) : base(message)
    {
        
    }
}