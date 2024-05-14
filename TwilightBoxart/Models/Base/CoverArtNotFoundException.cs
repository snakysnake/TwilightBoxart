using System;

namespace TwilightBoxart.Models.Base
{
    public class CoverArtNotFoundException(string message) : Exception(message)
    {
    }
}
