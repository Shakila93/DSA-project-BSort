using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace BubbleSort
{

    public class Bar
    {
        RectangleShape shape;
       // Vector2f Destination;
        Font font;
        Text text;
        public int value;
        const int minHeight = 10;
        const int maxHeight = 500;
        const float AnimateDuration = 1;
        float elapsedTime = 0;
        bool IsAnimating = false;
        float start = 0;
        float end = 0;
        public Bar(float x, float y, float width, float height, Color FillColor, int LineWidth, Color OutlineColor, int value)
        {
            //creating the shape
            shape = new RectangleShape();
            setSize(width, value);
            text = new Text(value.ToString(), font);
            setPosition(x, y);
            shape.FillColor = FillColor;
            shape.OutlineColor = OutlineColor;
            shape.OutlineThickness = LineWidth;
            this.value = value;

            start = x;
            end = x;


            


            font = new Font("C:/Windows/Fonts/arial.ttf");


            text.Font = font;
            text.FillColor = Color.White;
            text.CharacterSize = 20;

        }
        public void setPosition(float x, float y)
        {
            shape.Origin = new Vector2f(shape.Size.X / 2, shape.Size.Y);
            shape.Position = new Vector2f(x, y);
            Console.WriteLine($"{shape.Position.X}, {shape.Position.Y}");
            text.Origin = new Vector2f(shape.Origin.X, 0);
            text.Position = shape.Position;

        }
        public void setDestination(float Position)
        {
            IsAnimating = true;
            //this.Destination = Position;
            this.elapsedTime = AnimateDuration;
            
            start = end;
            end = Position;
        }
        public void setSize(float x, float y)
        {
            float HeightOfBar = y*4.9f;
                //(maxHeight - minHeight) * y;
            this.shape.Size = new Vector2f(x, HeightOfBar);

        }
        public void Draw(RenderWindow window)
        {
            window.Draw(shape);
            window.Draw(text);

        }
        public void Update(float delta)
        {
            // lerp
            if (IsAnimating)
            {
                this.elapsedTime -= delta;
                if(elapsedTime < 0)
                {
                    IsAnimating = false;
                }
                //float timePercent = delta / AnimateDuration;
                float timePercent = 1f-(elapsedTime / AnimateDuration);

                //full lerp
                float lerp = start + timePercent * (end- start);
                shape.Position = new Vector2f(lerp, shape.Position.Y);
                
            }
         
            text.Position = shape.Position;




        }
        public Vector2f getPosition()
        {
            return shape.Position;
        }
    }
}
