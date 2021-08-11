using JetBrains.Annotations;

namespace Equilibrium.Models.Objects.Math {
    [PublicAPI]
    public record struct Rect(float X, float Y, float W, float H) {
        public static Rect Zero { get; } = new(0, 0, 0, 0);
    }
}
