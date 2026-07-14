using System.Numerics;
using Raylib_cs;

namespace BezierCurves
{
    public class Program
    {
        public static Vector2 Lerp(Vector2 pointA, Vector2 pointB, float t)
        {
            return new Vector2(pointA.X+(pointB.X-pointA.X)*t, pointA.Y+(pointB.Y-pointA.Y)*t);
        }

        public static Vector2 DeCasteljau(List<Vector2> points, float t)
        {
            while (points.Count > 1)
            {
                List<Vector2> next = new List<Vector2>();
                for(int i=0;i<points.Count-1; i++)
                {
                    next.Add(Lerp(points[i], points[i+1], t));
                }

                points = next;
            }
            return points.FirstOrDefault();
        }

        static void Main(string[] args)
        {
            const int width = 800;
            const int height = 480;
            const string text = "Bezier Curves";
            Raylib.InitWindow(width,height,text);
            Raylib.SetTargetFPS(60);

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

                Vector2 previous = DeCasteljau(rectangles, 0.0f);
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Raylib.DrawRectangle((int)rectangles[i].X, (int)rectangles[i].Y, 20, 20, Color.Red);
                }

                for(int i =rectangles.Count-1; i >=1; i--)
                {
                    Raylib.DrawLineDashed(new Vector2(rectangles[i].X+10, rectangles[i].Y+10), new Vector2(rectangles[i-1].X+10, rectangles[i-1].Y+10), 15, 15, Color.Red);
                }

                for (float t = 0.01f; t <= 1.0f; t += 0.001f)
                {
                    Vector2 current = DeCasteljau(rectangles, t);
                    Raylib.DrawLine((int)previous.X + 10, (int)previous.Y + 10, (int)current.X + 10, (int)current.Y + 10, Color.Blue);
                    previous = current;
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
