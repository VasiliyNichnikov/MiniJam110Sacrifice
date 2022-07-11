using System;

namespace SettlementObjects.Errors
{
    public class BuilderError : Exception
    {
    }

    public class ObjectIsNotBuilder : BuilderError
    {
    }

    public class AllSeatsAreOccupied : BuilderError
    {
    }
}