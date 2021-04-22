namespace Battle_of_the_Professor
{
    class Map
    {
        public int Row; //{ get; set; }
        public int Col; //{ get; set; }
        public Map(int Row, int Col) //this will be changed later, but for testing this is what i am using
        {
            this.Row = Row;
            this.Col = Col;
        }
        public int[,] map = new int[15, 20] { //initializes map, not official map just a test map for easy movement
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1},
            { 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1},
            { 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1},
            { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1},
            { 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1},
            { 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1},
            { 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
            { 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
            { 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1},
            { 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1},
            { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1},
            { 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1},
            { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            };

        //these will check if the spaces are moveable and return true if they are
        public bool RightCheck(int Row, int Col)
        {
            if (map[Row, Col + 1] == 0) { return true; }
            else return false;
        }
        public bool LeftCheck(int Row, int Col)
        {
            if (map[Row, Col - 1] == 0) { return true; }
            else return false;
        }
        public bool UpCheck(int Row, int Col)
        {
            if (map[Row - 1, Col] == 0) { return true; }
            else return false;
        }
        public bool DownCheck(int Row, int Col)
        {
            if (map[Row + 1, Col] == 0) { return true; }
            else return false;
        }

    }
}
