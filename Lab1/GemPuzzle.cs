using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class GemPuzzle
    {
        private int[,] field;
        private int length;
        private int cursorPosX, cursorPosY;

        public int[,] Field => field;
        public int Length => length;
        public int CursorPosX => cursorPosX;
        public int CursorPosY => cursorPosY;

        public enum Move { Up, Down, Left, Right };

        public bool Victory()
        {
            bool ans = true;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    if ((!(i == j && i == length - 1)) && (field[i, j] != i * length + j + 1))
                        ans = false;
            return ans;
        }
        public string Redraw()
        {
            string write = "";
            write += '\n';
            write += ("   ");
            write += ("╔");
            for (int j = 0; j < length; j++)
                write += String.Format("══{0}", (j < length - 1 ? "╦" : "╗"));
            write += '\n';
            for (int i = 0; i < length; i++)
            {
                write += ("   ");
                for (int j = 0; j < length; j++)
                    write += String.Format("║{0, 2}", (field[i, j] == 0 ? " " : field[i, j].ToString()));
                write += ("║");
                write += '\n';
                if (i < length - 1)
                {
                    write += ("   ");
                    write += ("╠");
                    for (int j = 0; j < length; j++)
                        write += String.Format("══{0}", (j < length-1 ? "╬" : "╣"));
                    write += '\n';
                }
            }
            write += ("   ");
            write += ("╚");
            for (int j = 0; j < length; j++)
                write += String.Format("══{0}", (j < length - 1 ? "╩" : "╝"));
            write += '\n';
            write += '\n';
            return write;
        }
        public void MakeMove(Move direction)
        {
            switch (direction)
            {
                case Move.Up:
                    if (cursorPosX > 0)
                    {
                        field[cursorPosX, cursorPosY] = field[cursorPosX - 1, cursorPosY];
                        field[--cursorPosX, cursorPosY] = 0;
                    }
                    break;
                case Move.Down:
                    if (cursorPosX < length - 1)
                    {
                        field[cursorPosX, cursorPosY] = field[cursorPosX + 1, cursorPosY];
                        field[++cursorPosX, cursorPosY] = 0;
                    }
                    break;
                case Move.Left:
                    if (cursorPosY > 0)
                    {
                        field[cursorPosX, cursorPosY] = field[cursorPosX, cursorPosY - 1];
                        field[cursorPosX, --cursorPosY] = 0;
                    }
                    break;
                case Move.Right:
                    if (cursorPosY < length - 1)
                    {
                        field[cursorPosX, cursorPosY] = field[cursorPosX, cursorPosY + 1];
                        field[cursorPosX, ++cursorPosY] = 0;
                    }
                    break;
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < 1e6; i++)
            {
                int tmp = rand.Next(4);
                switch (tmp)
                {
                    case 0:
                        MakeMove(Move.Up);
                        break;
                    case 1:
                        MakeMove(Move.Down);
                        break;
                    case 2:
                        MakeMove(Move.Left);
                        break;
                    case 3:
                        MakeMove(Move.Right);
                        break;
                }
            }
        }
        public void CreateField(int fieldSize)
        {
            if (fieldSize < 3 || 9 < fieldSize)
            {
                throw new Exception("Неправильный размер поля");
            }
            field = new int[fieldSize, fieldSize];
            length = fieldSize;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = (i * fieldSize) + j + 1;
                }
            }
            cursorPosX = cursorPosY = fieldSize - 1;
            field[cursorPosX, cursorPosY] = 0;
        }
    }
}
