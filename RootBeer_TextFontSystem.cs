using System;
using SDL3;

namespace RootBeer_CS;

public class RootBeer_TextFontSystem
{
    public static nint CurrentFont;

    public void SetCurrentFont(nint _Font)
    {
        CurrentFont = _Font;
    }

    public void DrawText(string _Text, int _PositionX, int _PositionY)
    {
        nint TextSurface = SDL3.TTF.RenderTextSolid(CurrentFont, "Hello world!");

        SDL.DestroySurface(TextSurface);
    }
}