

Console.WriteLine("*** Welcome to Tales C# Test ***");


Console.WriteLine("Please enter data:");

List<string> data = ReadData();

List<int> dataToRemove = DataToRemove(data);

Console.WriteLine("Thank you for entering data");
string dataToRemoveString = string.Join(",", dataToRemove);
Console.WriteLine($"The following elements will need to be removed: {dataToRemoveString}");

static List<string> ReadData()
{
    List<string> data = new List<string>();
    string? currentLine;
    do
    {
        currentLine = Console.ReadLine();
        data.Add(currentLine);
    } while (!string.IsNullOrEmpty(currentLine));
    return data;
}

static List<int> DataToRemove(List<string> data)
{
    bool parseSuccess = int.TryParse(data[0], out int dataLength);

    if (!parseSuccess)
    {
        Console.WriteLine("Invalid data length");
        return null;
    }


    List<Data> filteredData = new List<Data>();
    List<int> elementsToRemove = [];

    for (int i = 1; i < dataLength; i++)
    {
        string[] dataElementFragments = data[i].Split(",");
        Data dataItem = new(dataElementFragments);
        filteredData.Add(dataItem);
        if (!Data.IsValidData(dataItem) && filteredData.FirstOrDefault(filteredDataItem => filteredDataItem == filteredData[i]) != null)
        {
            elementsToRemove.Add(i);
        }
    }

    return elementsToRemove;
}
