using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.EventManager
{
    public class EventMediator
    {
        private static EventMediator _instance;

        //  creates a new singleton instance of EventMediator if one did not already exist
        //  without having to create a new instance of EventMediator in the class itself in any classes that use it
        //  This gave me the benefits of a static class for a global state while staying alive during application run time to manage events
        public static EventMediator Instance => _instance ?? (_instance = new EventMediator());

        private readonly Dictionary<string, List<Action<object>>> _events;

        private EventMediator() { _events = new Dictionary<string, List<Action<object>>>(); }

        public void Subscribe(string eventName, Action<object> callback)
        {
            if (!_events.ContainsKey(eventName))
            {
                _events[eventName] = new List<Action<object>>();
            }

            _events[eventName].Add(callback);

        }

        public void Unsubscribe(string eventName, Action<object> callback)
        {
            if (_events.ContainsKey(eventName))
            {
                _events[eventName].Remove(callback);
            }
        }

        public void Publish(string eventName, object data = null)
        {
            if (_events.ContainsKey(eventName))
            {
                foreach (var callback in _events[eventName])
                {
                    callback(data);
                }
            }
        }

        public void LogEvents()
        {
            foreach (var eventPair in _events)
            {
                Console.WriteLine($"Event Name: {eventPair.Key}");

                foreach (var callback in eventPair.Value)
                {
                    Console.WriteLine($"  Callback: {callback.Method.Name}"); 
                }
            }
        }
    }
}
