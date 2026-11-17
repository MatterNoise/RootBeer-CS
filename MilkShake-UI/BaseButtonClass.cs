using System;
using SDL3;
using RootBeer_CS;

namespace MilkShakeUI;
class BaseButtonClass : BaseControlClass
{
    private int CurrentButtonState = BaseButtonConstants.BUTTON_IDLE;

    public override void Update()
    {
        /*CurrentButtonState = BaseButtonConstants.BUTTON_IDLE;
        if (IsMouseHovering())
        {
            CurrentButtonState = BaseButtonConstants.BUTTON_HOVER;
            if (RootBeer_MouseSystem.IsMouseButtonHolded(SDL.ButtonLeft))
            {
                CurrentButtonState = BaseButtonConstants.BUTTON_HOLDED;

                _IsHolded();

                //GlobalUIVariables.CurrentProcessedButton = this;
            }
            if (RootBeer_MouseSystem.IsMouseButtonPressed(SDL.ButtonLeft))
            {
                _IsPressed();
            }
            if (RootBeer_MouseSystem.IsMouseButtonReleased(SDL.ButtonLeft))
            {
                _IsReleased();
            }
        }*/

        

        if (
                IsMouseHovering() &&
                RootBeer_MouseSystem.IsMouseButtonPressed(SDL.ButtonLeft)
            )
        {
            if (GlobalUIVariables.CurrentProcessedButton == null)
            {
                ThrowControlEvent("_IsPressed");
                
            }

            GlobalUIVariables.CurrentProcessedButton = this;
        }

        if (
                GlobalUIVariables.CurrentProcessedButton != null &&
                RootBeer_MouseSystem.IsMouseButtonReleased(SDL.ButtonLeft)
            )
        {
            if (GlobalUIVariables.CurrentProcessedButton == this)
            {
                ThrowControlEvent("_IsReleased");
            }

            GlobalUIVariables.CurrentProcessedButton = null;
        }

        //Console.WriteLine(GlobalUIVariables.CurrentProcessedButton);

        CurrentButtonState = BaseButtonConstants.BUTTON_IDLE;
        if (GlobalUIVariables.CurrentProcessedButton == this)
        {
            CurrentButtonState = BaseButtonConstants.BUTTON_HOLDED;

            ThrowControlEvent("_IsHolded");

            return;
        }

        if (
                IsMouseHovering() &&
                GlobalUIVariables.CurrentProcessedButton == null
            )
        {
            CurrentButtonState = BaseButtonConstants.BUTTON_HOVER;
        }
    }
    public override void Draw()
    {
        switch (CurrentButtonState)
        {
            case BaseButtonConstants.BUTTON_IDLE:
                RootBeer_RenderDrawSystem.SetDrawColor(
                    DefaultUITheme.BUTTON_BASE_IDLE_COLOR.R,
                    DefaultUITheme.BUTTON_BASE_IDLE_COLOR.G,
                    DefaultUITheme.BUTTON_BASE_IDLE_COLOR.B,
                    DefaultUITheme.BUTTON_BASE_IDLE_COLOR.A
                );

                break;
            case BaseButtonConstants.BUTTON_HOVER:
                RootBeer_RenderDrawSystem.SetDrawColor(
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.R,
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.G,
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.B,
                    DefaultUITheme.BUTTON_BASE_HOVER_COLOR.A
                );

                break;
            case BaseButtonConstants.BUTTON_HOLDED:
                RootBeer_RenderDrawSystem.SetDrawColor(
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.R,
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.G,
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.B,
                    DefaultUITheme.BUTTON_BASE_HOLDED_COLOR.A
                );

                break;
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