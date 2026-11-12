using System;
using SDL3;

namespace RootBeer_CS;

public class RootBeer_TextFontSystem
{
    public static nint CurrentFont;

    public static void SetCurrentFont(nint _Font)
    {
        CurrentFont = _Font;
    }

    public static void DrawText(string _Text, int _PositionX, int _PositionY)
    {
        nint TextSurface = SDL3.TTF.RenderTextSolid(CurrentFont, _Text, 0, new SDL.Color(){ R = 255, G = 255, B = 255, A = 255 });
        nint TextTexture = SDL.CreateTextureFromSurface(RootBeer_RenderDrawSystem.CurrentRenderer, TextSurface);

        SDL3.TTF.GetStringSize(CurrentFont, _Text, 0, out int TextPixelWidth, out int TextPixelHeight);

        SDL.FRect TextDrawRect = new SDL.FRect()
        {
            X = _PositionX,
            Y = _PositionY,
            W = TextPixelWidth,
            H = TextPixelHeight
        };

        SDL.RenderTexture(RootBeer_RenderDrawSystem.CurrentRenderer, TextTexture, IntPtr.Zero, TextDrawRect);

        SDL.DestroyTexture(TextTexture);
        SDL.DestroySurface(TextSurface);
    }
}