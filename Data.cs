// See https://aka.ms/new-console-template for more information
using System.Globalization;

public enum DocumentType
{
    P,
    ID,
    DL
}


public class Data
{
    public static string[] acceptedCountries = { "ESP", "FRA", "POR", "AND", "MOR" };
    public int scanId { get; set; }
    public DocumentType DocumentType { get; set; }
    public string IssuingCountry { get; set; }
    public string LastName { get; set; }

    public string FirstName { get; set; }
    public string DocumentNumber { get; set; }
    public string Nationality { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateOfExpiry { get; set; }

    public Data(string[] dataElementFragments)
    {
        MapDocumentType(dataElementFragments);
        scanId = int.Parse(dataElementFragments[0]);
        IssuingCountry = dataElementFragments[2][..3];
        LastName = dataElementFragments[3];
        FirstName = dataElementFragments[4];
        DocumentNumber = dataElementFragments[5];
        Nationality = dataElementFragments[6][..3];
        try
        {
            DateOfBirth = DateTime.ParseExact(dataElementFragments[7], "yyMMdd", CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            DateOfBirth = null;
        }
        try
        {
            DateOfExpiry = DateTime.ParseExact(dataElementFragments[8], "yyMMdd", CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            DateOfExpiry = null;
        }
    }

    private void MapDocumentType(string[] dataElementFragments)
    {
        switch (dataElementFragments[1])
        {
            case "P":
                DocumentType = DocumentType.P;
                break;
            case "ID":
                DocumentType = DocumentType.ID;
                break;
            case "DL":
                DocumentType = DocumentType.DL;
                break;
            default:
                throw new ArgumentException("Invalid document type");
        }
    }
    public static bool IsValidData(Data data)
    {
        return data.DateOfExpiry != null && data.DateOfBirth != null && data.DateOfExpiry > DateTime.Now &&
                acceptedCountries.Contains(data.IssuingCountry) &&
                acceptedCountries.Contains(data.Nationality);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Data data = (Data)obj;
        return (
            DocumentNumber == data.DocumentNumber &&
            IssuingCountry == data.IssuingCountry &&
            DocumentType == data.DocumentType
        ) || (
            FirstName == data.FirstName &&
            LastName == data.LastName &&
            Nationality == data.Nationality &&
            DateOfBirth == data.DateOfBirth
        );
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, Nationality, DateOfBirth, DocumentNumber, IssuingCountry, DocumentType);
    }
}

