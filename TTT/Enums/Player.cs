using System.ComponentModel;

namespace TTT.Enums
{
    public enum Player
    {
        [Description("-")]
        None,
        [Description("X")]
        Human,
        [Description("O")]
        Computer
    }
}
