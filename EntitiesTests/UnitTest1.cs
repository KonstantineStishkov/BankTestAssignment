using Entities.Models;

namespace EntitiesTests
{
    public class Tests
    {
        public static object[] FioSources =
        {
            new object[]{ "�������� ���� ������������", "Skvortsov Yuriy Vladimirovich" },
            new object[]{ "������� ���� �������������", "Konashev Yuriy Aleksandrovich" },
            new object[]{ "����������� ���� ����������", "Elisavetskaya Yuliya Nikolayevna" },
            new object[]{ "��������� ������ �������������", "Averyanov Eduard Aleksandrovich" },
            new object[]{ "������� �������� ���������", "Safarov Khayridin Salokhovich" },
            new object[]{ "����� Ը��� ����������", "Gorin F'odor Nikolayevich" },
            new object[]{ "�������� ������� ��������", "Davidova Tatyana Olegovna" },
            new object[]{ "������� �������� ����������", "Kochmina Svetlana Valeryevna" },
            new object[]{ "������� ������ ���������", "Kuzmin Sergey Borisovich" },
            new object[]{ "������ ������ ���������", "Dontsov Andrey Andreyevich" },
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