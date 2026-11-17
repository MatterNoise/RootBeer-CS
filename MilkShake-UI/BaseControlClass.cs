using System;
using SDL3;
using RootBeer_CS;
using EventHandler;

namespace MilkShakeUI;
public class BaseControlClass : BaseTemplateClass
{
    public event IEventHandler<string> ControlEvent;

    public float PositionX = 0;
    public float PositionY = 0;
    public float SizeWidth = 16;
    public float SizeHeight = 16;

    public void ThrowControlEvent(string _EventName)
    {
        ControlEvent?.Invoke(this, _EventName);
    }

    public bool IsMouseHovering()
    {
        //SDL.GetMouseState(out float MousePositionX, out float MousePositionY);
        RootBeer_MouseSystem.GetWindowMousePosition(MainProgram.MainRenderingWindow.Window, out float MousePositionX, out float MousePositionY, out bool IsMouseOutside);

        if (IsMouseOutside == true)
        {
            return false;
        }

        if (
                MousePositionX > PositionX &&
                MousePositionY > PositionY &&
                MousePositionX < PositionX + SizeWidth &&
                MousePositionY < PositionY + SizeHeight
            )
        {
            return true;
        }
        
        return false;
    }

}