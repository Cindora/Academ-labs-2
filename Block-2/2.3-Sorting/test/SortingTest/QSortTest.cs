using Microsoft.VisualBasic;
using NUnit.Framework;
using Sorting;

namespace SortingTest;

public class Tests
{
    [Test]
    public void GenericQuickSortIntTest()
    {
        var sort = new GenericQuickSort();
        var array = new int[] { 36, 8, 80, 78, 100, 61, 24 };
        var result = new int[] { 8, 24, 36, 61, 78, 80, 100 };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortShortTest()
    {
        var sort = new GenericQuickSort();
        var array = new short[] { 36, 8, 80, 78, 100, 61, 24 };
        var result = new short[] { 8, 24, 36, 61, 78, 80, 100 };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortByteTest()
    {
        var sort = new GenericQuickSort();
        var array = new byte[] { 36, 8, 80, 78, 100, 61, 24 };
        var result = new byte[] { 8, 24, 36, 61, 78, 80, 100 };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortFloatTest()
    {
        var sort = new GenericQuickSort();
        var array = new float[] { 89.65F, 59.32F, 74.19F, 33.21F, 92.75F, 81.9F, 55.98F };
        var result = new float[] { 33.21F, 55.98F, 59.32F, 74.19F, 81.9F, 89.65F, 92.75F };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortDoubleTest()
    {
        var sort = new GenericQuickSort();
        var array = new double[] { 5.6, 4.02, 4.12, 7.384, 8.36, 1.9, 5.46, 1.2, 5.45 };
        var result = new double[] { 1.2, 1.9, 4.02, 4.12, 5.45, 5.46, 5.6, 7.384, 8.36 };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortDecimalTest()
    {
        var sort = new GenericQuickSort();
        var array = new decimal[] { 5.6M, 4.02M, 4.12M, 7.384M, 8.36M, 1.9M, 5.46M, 1.2M, 5.45M };
        var result = new decimal[] { 1.2M, 1.9M, 4.02M, 4.12M, 5.45M, 5.46M, 5.6M, 7.384M, 8.36M };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortCharTest()
    {
        var sort = new GenericQuickSort();
        var array = new char[] { 'l', 'e', 'h', 'a', 'g', 'w', 's', 'p' };
        var result = new char[] { 'a', 'e', 'g', 'h', 'l', 'p', 's', 'w' };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void ReverseGenericQuickSortStringTest()
    {
        var sort = new GenericQuickSort();
        var array = new string[] { "lj", "ef", "hg", "as", "gd", "wl", "sb", "pk" };
        var result = new string[] { "as", "ef", "gd", "hg", "lj", "pk", "sb", "wl" };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }

    [Test]
    public void GenericQuickSortBoolTest()
    {
        var sort = new GenericQuickSort();
        var array = new bool[] { true, true, false, false, true, false, true, false };
        var result = new bool[] { false, false, false, false, true, true, true, true };

        sort.QuickSort(array);

        Assert.AreEqual(result, array);
    }
}