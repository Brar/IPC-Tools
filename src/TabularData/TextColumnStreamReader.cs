namespace IpcTools.TabularData;

internal class TextColumnStreamReader : IAsyncEnumerable<ITextDataField>
{
    readonly Stream _stream;
    readonly TextStreamConfiguration _configuration;
    readonly CancellationToken _outerCancellationToken;
    FieldEnumerator? _enumerator;
    CancellationTokenSource? _combinedCancellationTokenSource;

    public TextColumnStreamReader(Stream stream, TextStreamConfiguration configuration, CancellationToken cancellationToken)
    {
        _stream = stream;
        _configuration = configuration;
        _outerCancellationToken = cancellationToken;
    }

    public IAsyncEnumerator<ITextDataField> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        if (_enumerator != null)
            return _enumerator;

        _combinedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(_outerCancellationToken, cancellationToken);
        return _enumerator = new FieldEnumerator(_stream, _configuration, _combinedCancellationTokenSource.Token);
    }

    private class FieldEnumerator : IAsyncEnumerator<ITextDataField>
    {
        BufferTextDataField _current = new();
        readonly Stream _stream;
        readonly TextStreamConfiguration _configuration;
        readonly CancellationToken _cancellationToken;

        public FieldEnumerator(Stream stream, TextStreamConfiguration configuration, CancellationToken cancellationToken)
        {
            _stream = stream;
            _configuration = configuration;
            _cancellationToken = cancellationToken;
        }

        public ITextDataField Current => _current;

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> MoveNextAsync()
        {
            throw new NotImplementedException();
        }
    }
}
