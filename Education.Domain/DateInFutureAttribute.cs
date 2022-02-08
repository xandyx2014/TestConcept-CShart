using System;
using System.ComponentModel.DataAnnotations;


namespace Education.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _datetimeNowProvider;

        public DateInFutureAttribute() : this(() => DateTime.Now)
        { }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _datetimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "La fecha debe ser del futuro";
        }


#pragma warning disable CS8765
        public override bool IsValid(object value)
#pragma warning restore CS8765
        {
            bool isValid = false;
            if (value is DateTime dateTime)
            {
                isValid = dateTime > _datetimeNowProvider();
            }

            return isValid;
        }

    }
}
