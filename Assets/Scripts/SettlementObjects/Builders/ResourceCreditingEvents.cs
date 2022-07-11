using System;
using SettlementObjects.Resource;

namespace SettlementObjects.Builders
{
    public static class ResourceCreditingEvents
    {
        public static Action<int, IResource> UpdateResource;
        public static Action<int, IResource> UpdateResourceFromVictim;
    }
}