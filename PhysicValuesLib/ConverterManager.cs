﻿using PhysicValuesLib.Values;
using System.Reflection;

namespace PhysicValuesLib;

public class ConverterManager
{
    public ConverterManager()
    {
        SetValuesList();
    }

    private static List<IValue> _physicValuesList = new List<IValue>();

    /// <summary>
    /// Метод погружает список величин из библиотеки классов
    /// </summary>
    private static void SetValuesList()
    {
        Assembly asm = Assembly.LoadFrom("PhysicValuesLib.dll");        // создание сборки из библиотеки классов
        Type[] types = asm.GetTypes();                                  // выгрузка классов в массив
        foreach (Type type in types)                                   
        {
            if ((type.IsInterface == false)
                && (type.IsAbstract == false)
                && (type.GetInterface("IValue") != null))              
            {
                IValue value = (IValue)Activator.CreateInstance(type);
                _physicValuesList.Add(value);                                               
            }
        }
    }

    private IValue _myValue;

    private void SetIValue(string valueName)
    {
        foreach(var value in _physicValuesList)
        {
            if (value.GetValueName() == valueName)
            {
                _myValue = value;
            }            
        }
    }

    public List<string> GetPhysicValuesList()
    {      
        List<string> physicValuesList = new List<string>();
        foreach (IValue value in _physicValuesList)
        {
            physicValuesList.Add(value.GetValueName());
        }
        return physicValuesList;
    }

    public List<string> GetMeasureList(string physicValue)
    {
        SetIValue(physicValue);
        return _myValue.GetMeasureList();
    }    

    public double GetConvertedValue(
        string physicValue,
        double value,
        string from,
        string to)
    {
        SetIValue(physicValue);
        return _myValue.GetConvertedValue(value, from, to);
     }
    
}
