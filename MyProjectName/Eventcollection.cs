using System.Collections;

namespace DefaultNamespace;

public class Eventcollection : IEnumerable<Event>
{
    private List<Event> _events = new List<Event>();
    
    public void Add(Event ev)
    {
        _events.Add(ev);
    }

    public IEnumerator<Event> GetEnumerator()
    {
        var sortedEvents = _events.OrderBy(e => e.MoveNumber);
        foreach (var ev in sortedEvents)
        {
            yield return ev;
        }
    }
    
    public IEnumerable<Event> GetEventsByType(string type)
    {
        foreach (var ev in _events)
        {
            if (ev.Type.Equals(type))
            {
                yield return ev;
            }
        }
    }
    
    public IEnumerable<Event> GetLastEventsN(int n)
    {
        int skipCount = _events.Count - n;

        if (skipCount < 0)
        {
            skipCount = 0;
        }
        var lastEvents = _events.Skip(skipCount);

        foreach (var ev in lastEvents)
        {
            yield return ev;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}