using System;
using Economy.Resource;
using SettlementObjects.Resource;

namespace SettlementObjects.Builders
{
    public static class ResourceCreditingEvents
    {
        public static Action<int, IResource> UpdateResource;
    }
}