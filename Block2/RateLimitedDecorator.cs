class RateLimitedClientDecorator : IClient
{
    private readonly IClient _client;
    private readonly int _limit;
    private readonly TimeSpan _interval;
    private DateTime _lastCallTime;
    private int _callCount;

    public RateLimitedClientDecorator(IClient client, int limit, TimeSpan interval)
    {
        this._client = client;
        this._limit = limit;
        this._interval = interval;
        _lastCallTime = DateTime.MinValue;
        _callCount = 0;
    }

    public string GetId()
    {
        return _client.GetId();
    }

    public string GetContent(string id)
    {
        if (CanCallMethod())
        {
            _callCount++;
            return _client.GetContent(id);
        }
        else
        {
            throw new InvalidOperationException("Rate limit exceeded");
        }
    }

    private bool CanCallMethod()
    {
        if (DateTime.Now - _lastCallTime >= _interval)
        {
            _lastCallTime = DateTime.Now;
            _callCount = 0;
        }
        return _callCount < _limit;
    }
}