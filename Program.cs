using System.Text;

const string filepath = "textfile.txt";

const int bufferSize = 2;
byte[] buffer = new byte[bufferSize];
int bytesRead;
string fromBytes;
int intValue;
byte byteVal;
List<byte> allBytes = new List<byte>();
int totalBytesRead = 0;

using (var inputStream = new FileStream(filepath, FileMode.Open))
{
    do
    {
        bytesRead = inputStream.Read(buffer, 0, bufferSize);
        totalBytesRead += bytesRead;
        fromBytes = Encoding.ASCII.GetString(buffer);
        intValue = int.Parse(fromBytes, System.Globalization.NumberStyles.HexNumber);
        byteVal = Convert.ToByte(intValue);
        Console.WriteLine($"{fromBytes} -> {intValue} -> {Convert.ToChar(intValue)}");
        allBytes.Add(byteVal);
    } while (bytesRead > 0);
}

Console.WriteLine($"Caught {allBytes.Count} total bytes");

File.WriteAllBytes("C:\\Temp\\test.bmp", allBytes.ToArray());