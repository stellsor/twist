using System;

namespace A;

internal sealed class BackpackEquipmentException : Exception
{
    public BackpackEquipmentException(string message) : base(message)
    {
    }
}
