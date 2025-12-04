namespace JetFlow.Products.Api.EndPoints;

public interface IEndPoint
{
    static abstract void Map(RouteGroupBuilder group);
}