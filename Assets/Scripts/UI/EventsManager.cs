using System;
using Economy.Resource;

namespace UI
{
    public static class EventsManager
    {
        public static Action<int, IResource> AdditionResource;
        public static Action<int, IResource> SubtractionResource;
    }
}