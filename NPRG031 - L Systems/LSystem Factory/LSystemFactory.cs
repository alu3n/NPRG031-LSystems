namespace NPRG031___L_Systems.LSystem_Factory;

public static class LSystemFactory
{
    //Source: https://en.wikipedia.org/wiki/Koch_snowflake
    public static ModelConfiguration KochSnowflake()
    {
        ModelConfiguration configuration = new ModelConfiguration();

        configuration.stepCount = 4;
        configuration.angle = float.Pi / 3;
        configuration.lSystem.AddRule('F',"F+F--F+F");
        configuration.axiom = "F+F+F+F+F+F";
        
        return configuration;
    }
    
    //Source: http://algorithmicbotany.org/papers/#abop
    public static ModelConfiguration KochIsland()
    {
        ModelConfiguration configuration = new ModelConfiguration();

        configuration.stepCount = 2;
        configuration.angle = float.Pi / 2;
        configuration.lSystem.AddRule('F',"F+FF-FF-F-F+F+FF-F-F+F+FF+FF-F");
        configuration.axiom = "F-F-F-F";
        
        return configuration;
    }
    
    //Source: https://en.wikipedia.org/wiki/Hilbert_curve
    public static ModelConfiguration HilbertCurve2D()
    {
        ModelConfiguration configuration = new ModelConfiguration();
        
        configuration.stepCount = 6;
        configuration.angle = float.Pi / 2;
        configuration.lSystem.AddRule('A',"+BF-AFA-FB+");
        configuration.lSystem.AddRule('B',"-AF+BFB+FA-");
        configuration.axiom = "A";
        
        return configuration;
    }
    
    //Source: http://algorithmicbotany.org/papers/#abop
    public static ModelConfiguration HilbertCurve3D()
    {
        ModelConfiguration configuration = new ModelConfiguration();
        
        configuration.stepCount = 3;
        configuration.angle = float.Pi / 2;
        configuration.lSystem.AddRule('A',"B-F+CFC+F-D&F^D-F+&&CFC+F+B//");
        configuration.lSystem.AddRule('B',"A&F^CFB^F^D^^-F-D^|F^B|FC^F^A//");
        configuration.lSystem.AddRule('C',"|D^|F^B-F+C^F^A&&FA&F^C+F+B^F^D//");
        configuration.lSystem.AddRule('D',"|CFB-F+B|FA&F^A&&FB-F+B|FC//");
        configuration.axiom = "A";
        
        return configuration;
    }
    
    //Source: http://algorithmicbotany.org/papers/#abop
    public static ModelConfiguration Tree2D()
    {
        ModelConfiguration configuration = new ModelConfiguration();
        
        configuration.stepCount = 4;
        configuration.angle = float.Pi * (float)0.125;
        configuration.lSystem.AddRule('F',"FF-[-F+F+F]+[+F-F-F]");
        configuration.axiom = "F";
        
        return configuration;
    }
    
    //Source: http://algorithmicbotany.org/papers/#abop
    public static ModelConfiguration Tree3D()
    {
        ModelConfiguration configuration = new ModelConfiguration();
    
        configuration.stepCount = 7;
        configuration.angle = float.Pi * (float)0.125;
        configuration.lSystem.AddRule('A',"[&FA]/////[&FA]///////[&FA]");
        configuration.lSystem.AddRule('F',"F/////S");
        configuration.lSystem.AddRule('S',"FL");
        configuration.lSystem.AddRule('L',"[^^-f+f+f-|-f+f+f]");
        configuration.axiom = "A";
        
        return configuration;
    }
}