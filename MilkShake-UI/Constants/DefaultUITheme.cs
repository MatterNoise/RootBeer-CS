using System;
using SDL3;
using RootBeer_CS;

namespace MilkShakeUI;
class DefaultUITheme
{
    public static SDL.Color BUTTON_BASE_IDLE_COLOR = new SDL.Color() { R = 255, G = 255, B = 255, A = 255 };
    public static SDL.Color BUTTON_BASE_HOVER_COLOR = new SDL.Color() { R = 0, G = 255, B = 255, A = 255 };
    public static SDL.Color BUTTON_BASE_HOLDED_COLOR = new SDL.Color() { R = 86, G = 86, B = 86, A = 255 };
}