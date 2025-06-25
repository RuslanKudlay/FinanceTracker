namespace DAL;

public class Enums
{
    public enum TransactionSource
    {
        Manual, //ручне створення транзакції
        Bank, //банкова транзакція
    }
    
    public enum TransactionType
    {
        Income, //прибуток 
        Expense, //витрати
    }
    
    public enum DataType
    {
        Decimal,
        DateTime,
        Integer,
        String,
        Date,
        Time,
        ListString,
        Bool
    }
}