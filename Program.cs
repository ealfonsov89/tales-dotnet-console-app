

Console.WriteLine("*** Welcome to Tales C# Test ***");


Console.WriteLine("Please enter data:");

List<string> data = ReadData();

int[] dataToRemove = DataToRemove(data);

Console.WriteLine("Thank you for entering data");
string dataToRemoveString = string.Join(",", dataToRemove);
Console.WriteLine($"The following elements will need to be removed: {dataToRemoveString}");

static List<string> ReadData()
{
    string datalength = Console.ReadLine();
    List<string> data = new();
    bool parseSuccess = int.TryParse(datalength, out int dataLength);
    for (int i = 0; i < dataLength; i++)
    {
        string currentLine = Console.ReadLine();
        data.Add(currentLine);
    }
    return data;
}

static int[] DataToRemove(List<string> data)
{
    List<Data> filteredData = new List<Data>();
    List<int> elementsToRemove = [];

    for (int i = 0; i < data.Count; i++)
    {
        string[] dataElementFragments = data[i].Split(",");
        Data dataItem = new(dataElementFragments);
        if (!Data.IsValidData(dataItem) || filteredData.FirstOrDefault(filteredDataItem => filteredDataItem.Equals(dataItem)) != null)
        {
            elementsToRemove.Add(dataItem.scanId);
        }
        filteredData.Add(dataItem);
    }

    return elementsToRemove.Order().ToArray();
}
