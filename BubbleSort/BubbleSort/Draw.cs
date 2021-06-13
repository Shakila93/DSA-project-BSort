using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace BubbleSort
{
    public class Draw
    {
        //animation . elapesed time,
        //set position , ramp up its opacity, at the half way mark we ramp up its opacity as our animation time continues
        RectangleShape LeftHand;
        RectangleShape RightHand;
        float animationTime = 1;
        float elapsedTime = 0;
        

        public Draw()
        {
            LeftHand = new RectangleShape();
            RightHand = new RectangleShape();
            Texture tex = new Texture(BubbleSort.Properties.Resources.hand);
            LeftHand.Texture = tex;
            RightHand.Texture = tex;
            LeftHand.FillColor = Color.White;
            LeftHand.Size = new Vector2f(50, 50);
            RightHand.Size = new Vector2f(50, 50);


        }
        public void setPostion(Vector2f position)
        {
            position.X -= 25;
            LeftHand.Position = position;
            position.X += 70;
            RightHand.Position = position;
            elapsedTime = animationTime;

            
        }
        public void draw(RenderWindow window)
        {

            window.Draw(LeftHand);
            window.Draw(RightHand);
        }
        public void update(float delta)
        {
            elapsedTime = Math.Max(0, elapsedTime - delta); //makes sure elapes time doesnt go more then zero
            float opacity = (elapsedTime / animationTime)*2-1;  //create value between -1 and positive 1
            opacity = 1 - Math.Abs(opacity); //take Origanal  value , converted to 0 & 1 value.

            if (opacity > 0.9)
            {
                opacity = 1;
            }
            LeftHand.FillColor = new Color(255, 255, 255,(byte) Math.Round(opacity * 255));
            RightHand.FillColor = new Color(255, 255, 255, (byte)Math.Round(opacity * 255));

        }
        
    }
}
