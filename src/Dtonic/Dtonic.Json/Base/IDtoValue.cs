namespace Dtonic.Dto.Base;

public interface IDtoValue : IDtonic
{
    bool IsSpecified { get; }

    bool IsNull { get; }
}
