using System;

namespace EventHandler
{
    public delegate void IEventHandler<TEvent>(object sender, TEvent data);
}