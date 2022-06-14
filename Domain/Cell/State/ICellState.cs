namespace DPAT_eindopdracht.Domain.Cell.State;

public interface ICellState
{
    public string state { get; }
    void SetFixedValue(int? value);

    void SetHelperValue(int? helperValue);
}