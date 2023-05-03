using System.ComponentModel;

namespace CoinBot.Domain.Enums;

public enum State
{
    [Description("Нет состояния")]
    None,

    [Description("Доход")]
    Income,

    [Description("Расход")]
    Consumption
}

