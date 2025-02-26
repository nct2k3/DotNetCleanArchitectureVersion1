using ErrorOr;

namespace Domanin.Commom.Errors;

public static partial class Errors
{
    public static class User
    {

        public static Error DuplicateEmail => Error.Conflict(code:
            "user duplication email already exists",
            description:" duplication  email already exists"
            );
    }
}