using System;

namespace SettlementObjects.Errors
{
    public class BuilderError : Exception
    {
    }

    public class ObjectIsNotBuilding : BuilderError
    {
    }

    public class AllSeatsAreOccupied : BuilderError
    {
    }
}