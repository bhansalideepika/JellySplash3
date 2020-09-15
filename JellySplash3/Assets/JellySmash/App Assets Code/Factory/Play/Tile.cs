namespace JellySmash.Factory.Screen.Play.Data
{
    public class Tile : ITile
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Tile()
        {
        }

        public Tile(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
