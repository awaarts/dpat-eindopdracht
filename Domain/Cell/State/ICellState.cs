namespace DPAT_eindopdracht.Domain.Cell.State;

public interface ICellState
{
    void SetFixedValue(int? value);

    void SetHelperValue(int helperValue);
}