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

            public const int LanguageMinLength = 10;
            public const int LanguageMaxLength = 40;

            public const int NationalityMinLength = 4;
            public const int NationalityMaxLength = 60;

            public const string PriceRangeMin = "0.00";
            public const string PriceRangeMax = "250.00";
        }

        public class Publisher
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 20;

            public const int DescriptionMinLength = 100;
            public const int DescriptionMaxLength = 500;
        }

        public class Review
        {
            public const int RatingRangeMin = 1;
            public const int RatingRangeMax = 5;

            public const int CommentMaxLength = 100;
        }

        public class Author
        {
            public const int FirstNameMinLenght = 3;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 20;

            public const int PhoneNumberMinLength = 11;
            public const int PhoneNumberMaxLength = 14;
        }
    }
}
