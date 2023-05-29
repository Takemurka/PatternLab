class Client : IClient
{
    private string _id;

    public Client(string id)
    {
        this._id = id;
    }

    public string GetId()
    {
        return _id;
    }

    public string GetContent(string id)
    {
        return $"Content for id '{id}'";
    }
}