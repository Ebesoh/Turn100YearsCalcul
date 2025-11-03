using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn100YearsCalcul
{
    public class NameAgeCal
    {
        public string Name { get; set; } = string.Empty;
        public float Age { get; set; }

        public void SetNameAge(string name, float age)
        {
            Name = name;
            Age = age;
        }

        public float CalculateYearWhen100()
        {
            float currentYear = DateTime.Now.Year;
            return currentYear + (100 - Age);
        }
    }
}
