using System;

namespace ValidationAttributes.Models.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _minValue;
        private int _maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("Invalid data type");
            }

            if ((int)obj < _minValue || (int)obj > _maxValue)
            {
                return false;
            }
            return true;
        }
    }
}
