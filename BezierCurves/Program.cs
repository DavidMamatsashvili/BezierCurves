using System.Numerics;
using Raylib_cs;

namespace BezierCurves
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int width = 800;
            const int height = 480;
            const string text = "bezier curves";
            Raylib.InitWindow(width,height,text);
            List<Vector2> rectangles = new List<Vector2>();

            int markedRectangle = -1;

            while (!Raylib.WindowShouldClose())
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    rectangles.Add(new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY()));
                }

                if (Raylib.IsMouseButtonPressed(MouseButton.Right))
                {
                    for (int i = 0; i < rectangles.Count; i++)
                    {
                        if (Raylib.GetMouseX() >= rectangles[i].X && Raylib.GetMouseX() <= rectangles[i].X + 20 &&
                            Raylib.GetMouseY() >= rectangles[i].Y && Raylib.GetMouseY() <= rectangles[i].Y + 20)
                        {
                            markedRectangle = i;
                            break;
                        }
                    }
                }

                if(Raylib.IsMouseButtonDown(MouseButton.Right) && markedRectangle != -1)
                {
                    rectangles[markedRectangle] = new Vector2(Raylib.GetMouseX()-10, Raylib.GetMouseY()-10);
                }

                if (Raylib.IsMouseButtonReleased(MouseButton.Right))
                {
                    markedRectangle = -1;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Raylib.DrawRectangle((int)rectangles[i].X, (int)rectangles[i].Y, 20, 20, Color.Red);
                }
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
