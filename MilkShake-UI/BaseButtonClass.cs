using System;
using SDL3;
using RootBeer_CS;

namespace MilkShakeUI;
class BaseButtonClass : BaseControlClass
{
    public override void Update()
    {
        if (IsMouseHovering())
        {
            if (RootBeer_MouseSystem.IsMouseButtonHolded(SDL.ButtonLeft))
            {
                _IsHolded();
            }
            if (RootBeer_MouseSystem.IsMouseButtonPressed(SDL.ButtonLeft))
            {
                _IsPressed();
            }
            if (RootBeer_MouseSystem.IsMouseButtonReleased(SDL.ButtonLeft))
            {
                _IsReleased();
            }
        }
    }
    public override void Draw()
    {
        if (IsMouseHovering())
        {
            if (RootBeer_MouseSystem.IsMouseButtonHolded(SDL.ButtonLeft))
            {
                RootBeer_RenderDrawSystem.SetDrawColor(
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.R,
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.G,
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.B,
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.A
                );
            } else
            {
                RootBeer_RenderDrawSystem.SetDrawColor(
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.R,
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.G,
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.B,
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.A
                );
            }
        }
        else
        {
            RootBeer_RenderDrawSystem.SetDrawColor(
                DefaultUITheme.BUTTON_BASE_IDLE_COLOR.R,
                DefaultUITheme.BUTTON_BASE_IDLE_COLOR.G,
                DefaultUITheme.BUTTON_BASE_IDLE_COLOR.B,
                DefaultUITheme.BUTTON_BASE_IDLE_COLOR.A
            );
        }
        
        RootBeer_RenderDrawSystem.DrawRectFill(
            PositionX,
            PositionY,
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