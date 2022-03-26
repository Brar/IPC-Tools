using System.Text;

namespace IpcTools.TabularData;

public record TextStreamConfiguration
{
    public TextStreamConfiguration(char delimiter = '\t', bool header = true, char quote = '"', char? escape = null, Encoding? encoding = null, bool useBom = true, int? bufferSize = null, string? defaultDateFormat = null)
    {
        Delimiter = delimiter;
        Header = header;
        Quote = quote;
        Escape = escape ?? quote;
        Encoding = encoding ?? Encoding.UTF8;
        UseBom = useBom;
        BufferSize = bufferSize;
        DefaultDateFormat = defaultDateFormat;
    }

    public char Delimiter { get; }
    public bool Header { get; }
    public char Quote { get; }
    public char Escape { get; }
    public Encoding Encoding { get; }
    public bool UseBom { get; }
    public int? BufferSize { get; }
    public string? DefaultDateFormat { get; }
}
