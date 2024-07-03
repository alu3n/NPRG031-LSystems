namespace NPRG031___L_Systems;

public record class ModelConfiguration
{
    public string axiom { get; set; } = new("");
    public string derivedSentence { get; set; } = new("");
    public uint stepCount { get; set; } = 0;
    public float distance { get; set; } = 1;
    public float angle { get; set; } = float.Pi / 8;
    public LSystem lSystem { get; set; } = new();

    public ModelConfiguration(string axiom, string derivedSentence, uint stepCount, float distance, float angle, LSystem lSystem)
    {
        this.axiom = axiom;
        this.derivedSentence = derivedSentence;
        this.stepCount = stepCount;
        this.distance = distance;
        this.angle = angle;
        this.lSystem = lSystem;
    }

    public ModelConfiguration()
    {
        
    }
}