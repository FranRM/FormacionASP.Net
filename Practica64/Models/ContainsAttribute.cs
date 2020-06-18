using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practica64.Models
{
    public class ContainsAttribute : ValidationAttribute
    {
        private readonly string _letra;
        public ContainsAttribute(string letra)
        {
            _letra = letra;
        }
        public override bool IsValid(object value)
        {
            var str = value?.ToString();
            return str?.Contains(_letra) ?? false;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, _letra);
        }
    }
}
