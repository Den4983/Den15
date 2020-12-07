using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace G15
{
    class Game
    {
      public static List<int> list = new List<int>();

        int size;
        int[,] map;
        int space_x;
        int space_y;
        Random rnd = new Random();
        public Game(int size)
      {
            this.size = size;
            map = new int[size, size];

      }
       
        public void start()
        {
            list.Clear();
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coords_to_pos(x, y)+1;
            space_x = size - 1;
            space_y = size - 1;
            map[space_x, space_y]= 0;
        }
        public void shift(int pos)
        {
            int x, y;
            pos_to_coords(pos,out x,out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) == 1)
            {
                map[space_x, space_y] = map[x, y];
                map[x, y] = 0;
                space_x = x;
                space_y = y;
            }

        }
        public void Addlist(int pos)
        {
            int x, y;
            pos_to_coords(pos, out x, out y);
            if (y - space_y == 0)
            {
                if (x - space_x == 1)
                    list.Add(1);
                if (x - space_x == -1)
                    list.Add(0);
            }
            if (x - space_x == 0)
            {
                if (y - space_y == 1)
                    list.Add(3);
                if (y - space_y == -1)
                    list.Add(2);
            }
        }
        public void sborka()
        {
            int x = space_x;
            int y = space_y;
            int a = list[list.Count-1];
            switch (a)
            {
                case 0: x++;  break;
                case 1: x--;  break;
                case 2: y++;  break;
                case 3: y--;  break;
            }
            shift(coords_to_pos(x, y));
            list.RemoveAt(list.Count-1);
        }
        public void shift_rand()
        {
        M1:
            bool c=false;
            int b=0;
            int a = rnd.Next(0, 4);
            int x = space_x;
            int y = space_y;
            switch(a)
            {

                case 0: x--;b = 0;  break;
                case 1: x++;;b = 1;  break;
                case 2: y--;b = 2; break;
                case 3: y++;b = 3;  break;
            }
                list.Add(b);
          
            if (x < 0) { x +=2; list.RemoveAt(list.Count - 1);list.Add(1); }
            if (x > size - 1) { x -=2; list.RemoveAt(list.Count - 1); list.Add(0); }
            if (y < 0) { y += 2; list.RemoveAt(list.Count - 1); list.Add(3); }
            if (y > size - 1) { y -= 2; list.RemoveAt(list.Count - 1); list.Add(2); }


            try {
                if ((list[list.Count - 1] == 0 && list[list.Count - 2] == 1) || (list[list.Count - 1] == 1 && list[list.Count - 2] == 0) ||
                  (list[list.Count - 1] == 2 && list[list.Count - 2] == 3) || (list[list.Count - 1] == 3 && list[list.Count - 2] == 2))
                { c = true; }
                  // c= list[list.Count - 1] == list[list.Count - 2];
                }
            catch 
            {
                
            }
            if (c)
            {
                list.RemoveAt(list.Count - 1);
                goto M1;

            }

            shift(coords_to_pos(x, y));
        }

        public int get_number(int pos)
        {
            int x, y;
            pos_to_coords(pos, out x, out y);
            return map[x, y];
        }
        private int coords_to_pos(int x,int y)
        {
           
            return y * size + x;
        }
        private void pos_to_coords(int pos, out int x,out int y)
        {
            x = pos % size;
            y = pos / size;
        }
        public bool chekc_nmb()
        {
            if (!(space_x == size - 1 && space_y == size - 1))
                return false;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (!(x == size - 1 && y == size - 1))
                    {
                        if (map[x, y] != coords_to_pos(x, y) + 1)
                            return false;
                    }
                }
            }
            return true;

        }

    }
    
    
}
