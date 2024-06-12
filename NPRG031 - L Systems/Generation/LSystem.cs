namespace NPRG031___L_Systems;

public record class LSystem
{
    public Dictionary<char, string> rules { get; set; } = new();

    public void AddRule(char leftHandSide, string rightHandSide)
    {
        if (rules.ContainsKey(leftHandSide))
        {
            rules[leftHandSide] = rightHandSide;
        }
        else
        {
            rules.Add(leftHandSide, rightHandSide);
        }
        
    }

    // This method does a single step of DOLSystem derivation
    //  If there exists a rule for certain character, it applies the rule
    //  Otherwise it applies identity transformation (i.e. X->X)
    public string DirectDerivation(string sentence)
    {
        string derivedSentence = new("");
        
        for (int i = 0; i < sentence.Length; ++i)
        {
            if(rules.ContainsKey(sentence[i]))
            {
                derivedSentence += rules[sentence[i]];
            }
            else
            {
                // If there isn't such rule, apply identity.
                derivedSentence += sentence[i];
            }
        }

        return derivedSentence;
    }

    // This method applies "stepCount" times the DirectDerivation method
    public string Derivation(string sentence, uint stepCount)
    {
        for (int i = 0; i < stepCount; ++i)
        {
            sentence = this.DirectDerivation(sentence);
        }

        return sentence;
    }
}