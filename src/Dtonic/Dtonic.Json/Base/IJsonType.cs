﻿namespace Dtonic.Json.Base;

public interface IJsonType
{
    bool IsSet { get; }

    bool IsNull { get; }
}