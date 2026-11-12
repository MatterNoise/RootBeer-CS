using System;
using SDL3;
using RootBeer_CS;

public class BaseTemplateClass
{
    public virtual void Init() { }
    public virtual void Close() { }

    public virtual void Update() { }
    public virtual void Draw() { }
}