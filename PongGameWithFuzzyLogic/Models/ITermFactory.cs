using PongGameWithFuzzyLogic.Models.FuzzyLogic.Terms;

namespace PongGameWithFuzzyLogic.Models
{
    public interface ITermFactory
    {
        public ITerm GetTerm(string termName);
    }
}
