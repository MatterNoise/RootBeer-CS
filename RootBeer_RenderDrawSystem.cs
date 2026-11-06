using System;
using SDL3;

namespace RootBeer_CS;
public class RootBeer_RenderDrawSystem
{
    public static nint CurrentRenderer;

    public static void SetCurrentRenderer(nint _Renderer)
    {
        CurrentRenderer = _Renderer;
    }

    public static void UpdateRenderer()
    {
        SDL.RenderPresent(CurrentRenderer);
    }

    public static void SetDrawColor(byte _Red, byte _Green, byte _Blue, byte _Alpha)
    {
        SDL.SetRenderDrawColor(CurrentRenderer, _Red, _Green, _Blue, _Alpha);
    }

    public static void ClearScreen()
    {
        SDL.RenderClear(CurrentRenderer);
    }

    public static void DrawPoint(float _PointX, float _PointY)
    {
        SDL.RenderPoint(CurrentRenderer, _PointX, _PointY);
    }

    public static void DrawLine(float _LineStartX, float _LineStartY, float _LineEndX, float _LineEndY)
    {
        SDL.RenderLine(CurrentRenderer,  _LineStartX, _LineStartY, _LineEndX, _LineEndY);
    }

    public static void DrawRect(float _RectangleX, float _RectangleY, float _RectangleW, float _RectangleH)
    {
        SDL.FRect DrawRectVar = new SDL.FRect();
        DrawRectVar.X = _RectangleX;
        DrawRectVar.Y = _RectangleY;
        DrawRectVar.W = _RectangleW;
        DrawRectVar.H = _RectangleH;

        SDL.RenderRect(CurrentRenderer, DrawRectVar);
    }

    public static void DrawRectFill(float _RectangleX, float _RectangleY, float _RectangleW, float _RectangleH)
    {
        SDL.FRect DrawRectVar = new SDL.FRect();
        DrawRectVar.X = _RectangleX;
        DrawRectVar.Y = _RectangleY;
        DrawRectVar.W = _RectangleW;
        DrawRectVar.H = _RectangleH;

        SDL.RenderFillRect(CurrentRenderer, DrawRectVar);
    }

    public static void DrawRectTexture(nint _RectangleTexture, float _RectangleX, float _RectangleY, float _RectangleW, float _RectangleH, float _TextureX, float _TextureY, float _TextureW, float _TextureH)
    {
        SDL.FRect DrawRectVar = new SDL.FRect();
        DrawRectVar.X = _RectangleX;
        DrawRectVar.Y = _RectangleY;
        DrawRectVar.W = _RectangleW;
        DrawRectVar.H = _RectangleH;

        SDL.FRect TextureRectVar = new SDL.FRect();
        TextureRectVar.X = _TextureX;
        TextureRectVar.Y = _TextureY;
        TextureRectVar.W = _TextureW;
        TextureRectVar.H = _TextureH;

        SDL.RenderTexture(CurrentRenderer, _RectangleTexture, TextureRectVar, DrawRectVar);
    }
}