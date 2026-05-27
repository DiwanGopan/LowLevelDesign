using ConceptPractice.OOPS;
using ConceptPractice.SOLIDPrinciples.LSP;
using ConceptPractice.SOLIDPrinciples.LSP.LSPRules.SignatureRules;
using ConceptPractice.SOLIDPrinciples.OCP;
using ConceptPractice.SOLIDPrinciples.SRP;

namespace ConceptPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // OOPS

            //Abstraction.Run();
            //Encapsulation.Run();
            //Inheritance.Run();
            //StaticAndDynamicPolymorphism.Run();


            // SOLID Principles

            //SRPViolated.Run();
            //SRPFollowed.Run();

            //OCPViolated.Run();
            //OCPFollowed.Run();
            
            //LSPViolated.Run();
            //LSPFollowedWrongly.Run();
            //LSPFollowed.Run();

            MethodArgumentRule.Run();
        }
    }
}