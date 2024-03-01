namespace Kspace.Result.Tests;

public class MapTests
{
    [Fact]
    public void Success_Map_MatchSuccessPart()
    {
        var result = Result<Model>.Success(new Model());
        var mapResult = Result<object>.Success(new object());

        var mapResponse = result.Map<object>(_ => mapResult);

        mapResponse.Should().Be(mapResult);
    }

    [Fact]
    public void StaticSuccess_Map_MatchSuccessPart()
    {
        var result = Result.Success(new Model());
        var mapResult = Result<object>.Success(new object());

        var mapResponse = result.Map<object>(_ => mapResult);

        mapResponse.Should().Be(mapResult);
    }

    [Fact]
    public void Error_Map_MatchSuccessPart()
    {
        var result = Result<Model>.Error(new Exception());
        var mapResult = Result<object>.Success(new object());

        var mapResponse = result.Map<object>(_ => mapResult);

        mapResponse.Should().NotBe(mapResult);
    }

    [Fact]
    public async Task Success_MapAsync_MatchSuccessPart()
    {
        var result = Result<Model>.Success(new Model());
        var mapResult = Result<object>.Success(new object());

        var mapResponse = await result.MapAsync<object>(async _ => mapResult);

        mapResponse.Should().Be(mapResult);
    }

    [Fact]
    public async Task Error_MapAsync_MatchSuccessPart()
    {
        var result = Result<Model>.Error(new Exception());
        var mapResult = Result<object>.Success(new object());

        var mapResponse = await result.MapAsync<object>(async _ => mapResult);

        mapResponse.Should().NotBe(mapResult);
    }
}