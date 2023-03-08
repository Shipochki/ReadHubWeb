﻿using System;
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

            public const int DescriptionMinLength = 250;
            public const int DescriptionMaxLength = 1000;

            public const int ImageUrlLinkMinLength = 20;
            public const int ImageUrlLinkMaxLength = 100;

            public const int LanguageMinLength = 10;
            public const int LanguageMaxLength = 40;

            public const int NationalityMinLength = 4;
            public const int NationalityMaxLength = 60;

            public const decimal PriceRangeMin = 0.00m;
            public const decimal PriceRangeMax = 250.00m;
        }

        public class Publisher
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;
        }
    }
}
