namespace Domanin.Commom.Errors;
using ErrorOr;
public static partial class Errors
{
    public static class  Authentication
    {
        public static Error InvalidCrendentials => Error.Validation(code:
            "nvalidCrendentials",
            description:" nvalidCrendentials"
        );
        
    }
    
}