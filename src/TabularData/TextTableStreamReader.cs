namespace IpcTools.TabularData;

public class TextTableStreamReader : IAsyncEnumerable<IAsyncEnumerable<ITextDataField>>
{
    readonly Stream _stream;
    readonly TextStreamConfiguration _configuration;
    RowEnumerator? _enumerator;

    public TextTableStreamReader(Stream stream, TextStreamConfiguration configuration)
    {
        _stream = stream;
        _configuration = configuration;
    }

    public IAsyncEnumerator<IAsyncEnumerable<ITextDataField>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => _enumerator ??= new RowEnumerator(_stream, _configuration, cancellationToken);

    private class RowEnumerator : IAsyncEnumerator<IAsyncEnumerable<ITextDataField>>
    {
        readonly TextColumnStreamReader _columnReader;

        public RowEnumerator(Stream stream, TextStreamConfiguration configuration, CancellationToken cancellationToken)
        {
            _columnReader = new(stream, configuration, cancellationToken);
        }

        public IAsyncEnumerable<ITextDataField> Current => _columnReader;

        public async ValueTask<bool> MoveNextAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
