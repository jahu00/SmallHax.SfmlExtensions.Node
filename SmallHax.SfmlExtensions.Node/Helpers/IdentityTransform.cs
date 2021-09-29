using SFML.Graphics;

namespace SmallHax.SfmlExtensions.Helpers
{
    public static class IdentityMatrix
    {
        public static Transform GetTransform()
        {
            return new Transform
            (
                1, 0, 0,
                0, 1, 0,
                0, 0, 1
            );
        }
    }
}
