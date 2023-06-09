﻿namespace Snake.Core
{
    public interface ICellsField
    {
        int SizeX { get; }
        int SizeY { get; }

        ICell GetCell(int x, int y);
        void ReplaceCell(ICell cell);
    }
}