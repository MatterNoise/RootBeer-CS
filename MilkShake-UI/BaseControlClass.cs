using System;
using SDL3;
using RootBeer_CS;

namespace MilkShakeUI;
public class BaseControlClass : BaseTemplateClass
{
    public float PositionX;
    public float PositionY;
    public float SizeWidth;
    public float SizeHeight;

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