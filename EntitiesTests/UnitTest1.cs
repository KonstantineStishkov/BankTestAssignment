using Entities.Models;

namespace EntitiesTests
{
    public class Tests
    {
        public static object[] FioSources =
        {
            new object[]{ "Скворцов Юрий Владимирович", "Skvortsov Yuriy Vladimirovich" },
            new object[]{ "Конашев Юрий Александрович", "Konashev Yuriy Aleksandrovich" },
            new object[]{ "Елисавецкая Юлия Николаевна", "Elisavetskaya Yuliya Nikolayevna" },
            new object[]{ "Аверьянов Эдуард Александрович", "Averyanov Eduard Aleksandrovich" },
            new object[]{ "Сафаров Хайридин Салохович", "Safarov Khayridin Salokhovich" },
            new object[]{ "Горин Фёдор Николаевич", "Gorin F'odor Nikolayevich" },
            new object[]{ "Давыдова Татьяна Олеговна", "Davidova Tatyana Olegovna" },
            new object[]{ "Кочмина Светлана Валерьевна", "Kochmina Svetlana Valeryevna" },
            new object[]{ "Кузьмин Сергей Борисович", "Kuzmin Sergey Borisovich" },
            new object[]{ "Донцов Андрей Андреевич", "Dontsov Andrey Andreyevich" },
        };

        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(nameof(FioSources))]
        public void LatinTest(string source, string expected)
        {
           string actual = User.ToLat(source);
            Assert.AreEqual(expected, actual);
        }
    }
}