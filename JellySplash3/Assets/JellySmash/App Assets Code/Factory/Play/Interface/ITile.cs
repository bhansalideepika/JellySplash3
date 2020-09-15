namespace JellySmash.Factory.Screen.Play
{
    public interface ITile : IMarker
    {
        int Row { get; }
        int Column { get; }
    }
}
