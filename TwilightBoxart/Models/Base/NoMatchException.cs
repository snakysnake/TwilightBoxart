using System;

namespace TwilightBoxart.Models.Base
{
    public class NoMatchException(string message) : Exception(message)
    {
    }
}
