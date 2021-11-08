using System.ComponentModel;

namespace PredictionApiChecker.Data.Models.Football
{
    public enum OddType : byte
    {
        [Description("1")]
        First = 0,

        [Description("2")]
        Second = 1,

        [Description("12")]
        Any = 2,

        [Description("X")]
        Draw = 3,

        [Description("1X")]
        FirstOrDraw = 4,

        [Description("X2")]
        SecondOrDraw = 5
    }
}