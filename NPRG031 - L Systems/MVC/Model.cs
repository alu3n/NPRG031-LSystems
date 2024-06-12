namespace NPRG031___L_Systems;

public class Model
{
    public ModelConfiguration configuration { get; set; } = new();

    public void DeriveSentence()
    {
        configuration.derivedSentence = configuration.lSystem.Derivation(configuration.axiom, configuration.stepCount);
    }

    public void ClearConfiguration()
    {
        configuration = new ModelConfiguration();
    }

}