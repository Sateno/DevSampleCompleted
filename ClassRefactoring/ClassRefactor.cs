using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, 
        European 
    }
     
    public enum SwallowLoad
    {
        None, 
        Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    // The simplest refactoring I could see that can possibly work "assuming we want readability"
    // while respecting the public interface as instructed, is by modifying the GetAirspeedVelocity
    // to use a switch expression with patterns using tupples 
    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            return (Type, Load) switch
            {
                (SwallowType.African, SwallowLoad.None) => 22,
                (SwallowType.African, SwallowLoad.Coconut) => 18,
                (SwallowType.European, SwallowLoad.None) => 20,
                (SwallowType.European, SwallowLoad.Coconut) => 16,
                _ => throw new InvalidOperationException("Invalid swallow type or load"),
            };
        }
    }
}