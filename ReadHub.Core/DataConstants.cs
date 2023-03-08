using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core
{
    public class DataConstants
    {
        public class User
        {
            public const int FirstNameMinLenght = 3;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 20;
        }

        public class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 100;

            public const int DescriptionMinLength = 0;
        }
    }
}
