using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace BubbleSort
{
    public class BSort
    {
        int i, j;
        Bar[] bars;
        Draw hands;
        bool IsSorted = false;
        Text text;

        public BSort(Bar[] bars)
        {
            i = j = 0;
            this.bars = bars;
            hands = new Draw();
            hands.setPostion(new Vector2f(38, 630)); //set initial postion
            Font font = new Font("C:/Windows/Fonts/arial.ttf");
            text = new Text("Sorted", font);
            text.Position = new Vector2f(50, 50);
            text.CharacterSize = 20;
            text.FillColor = Color.Yellow;


        }
        public void steps()
        {
            if (IsSorted)
            {
                return;
            }

            //validating the numbers
            if (bars[j].value>bars[j + 1].value)
            {
               

                bars[j + 1].setDestination((j + 1) * 70 - 32);
                bars[j].setDestination((j + 2) * 70 - 32);
                hands.setPostion(new Vector2f((j+1)*70-32, 630));
                // swap temp and bars[i]
                Bar temp = bars[j];
                bars[j] = bars[j + 1];
                bars[j + 1] = temp;
            }
            j++;
            if (j == bars.Length -1)
            {
                j = 0;
                i++;
                if(i == bars.Length)
                {
                    IsSorted = true;
                }
            }

        }
        public void draw(RenderWindow window)
        {
            hands.draw(window);
            if (IsSorted)
            {
                window.Draw(text);
            }
        }
        public void update(float delta)
        {
            hands.update(delta);

        }
        
        
    }
}
