namespace Battle_of_the_Professor
{
    // contains all neccessary Map components, displaying images based on clicks.
    public class Map
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public int At(int Row, int Col) => map[Row, Col]; // expression-bodied method.

        public string Top() => map[Row - 1, Col] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string TopLeft() => map[Row - 1, Col - 1] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string TopRight() => map[Row - 1, Col + 1] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string Left() => map[Row, Col - 1] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string Right() => map[Row, Col + 1] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string Bottom() => map[Row + 1, Col] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string BottomLeft() => map[Row + 1, Col - 1] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";
        public string BottomRight() => map[Row + 1, Col + 1] == 0 ? @"\Map\Open.PNG" : @"\Map\Closed.PNG";

        public Map(int Row, int Col)
        {
            this.Row = Row;
            this.Col = Col;
        }

        // map instantiation.
        public int[,] map = new int[15, 20] {
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

        // checks if the spaces are moveable.
        public bool RightCheck => map[Row, Col + 1] == 0 ? true : false;
        public bool LeftCheck => map[Row, Col - 1] == 0 ? true : false;
        public bool UpCheck => map[Row - 1, Col] == 0 ? true : false;
        public bool DownCheck => map[Row + 1, Col] == 0 ? true : false;
    }
}
