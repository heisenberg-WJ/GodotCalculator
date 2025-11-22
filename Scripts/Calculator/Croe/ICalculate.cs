using System;

public interface ICalculate
{
   public double Calculate(double left,double rigth);
}

public class Add : ICalculate {
    public double Calculate(double left, double rigth)
    {
        throw new NotImplementedException();
    }
      
}
