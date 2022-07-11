using System;

namespace SettlementObjects.Errors
{
    public class MovementError : Exception
    {
    }

    public class MovementIsNotPossible : MovementError
    {
    }
}