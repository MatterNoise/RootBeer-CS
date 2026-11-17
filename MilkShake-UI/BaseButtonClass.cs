using System;
using SDL3;
using RootBeer_CS;

namespace MilkShakeUI;
class BaseButtonClass : BaseControlClass
{
    public override void Update()
    {
        if (RootBeer_MouseSystem.IsMouseButtonPressed(SDL.ButtonLeft))
        {
            _IsPressed();
        }
    }
    public override void Draw()
    {
        RootBeer_RenderDrawSystem.SetDrawColor(255, 255, 255, 255);
        RootBeer_RenderDrawSystem.DrawRectFill(
            PositionX,
            PositionX,
            SizeWidth,
            SizeHeight
        );
    }

    public virtual void _IsPressed()
    {
    }

    public virtual void _IsHolded()
    {
    }

    public virtual void _IsReleased()
    {
    }
}