namespace PhysicValuesLib;

/// <summary>
/// Интерфейс физической величины
/// </summary>
public interface IValue
{
    string GetValueName();
    /// <summary>
    /// Метод возвращает список единиц измерения
    /// </summary>
    /// <returns></returns>
    List<string> GetMeasureList();

    /// <summary>
    /// Метод возвращает конвертированное значение
    /// </summary>
    /// <returns></returns>
    double GetConvertedValue(double value, string from, string to);

    /// <summary>
    /// Метод переводит в систему СИ
    /// </summary>
    void ToSi();

    /// <summary>
    /// Метод конвертирует в нужные единицы измерения
    /// </summary>
    void ToRequired();
}
