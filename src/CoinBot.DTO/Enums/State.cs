using System.ComponentModel;

namespace CoinBot.DTO.Enums;

public enum State
{
    [Description("Нет состояния")]
    None,

    [Description("Доход")]
    Income,

    [Description("Расход")]
    Consumption
}

